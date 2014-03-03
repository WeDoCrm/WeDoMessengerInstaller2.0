using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;
using System.Configuration.Install;
using System.Windows.Forms;

namespace CustomAction
{
    public class FlowController
    {
        InstallController ctr = new InstallController();
        WindowWrapper wrapper;
        InstallContext context;

        public FlowController(WindowWrapper wrapper, InstallContext context)
        {
            this.wrapper = wrapper;
            this.context = context;
        }

        #region 메인 함수
        /// <summary>
        /// installer1에서 호출하여 
        /// </summary>
        public void DoMain()
        {
            FlowInfo flowInfo = new FlowInfo();
            while (true) {
                switch (flowInfo.NextStep)
                {
                    case Step.SET_CONFIG:
                        Logger.info("Step.SET_CONFIG");
                        flowInfo = doSetConfig(flowInfo);
                        break;
                    case Step.UPDATE_CONFIG:
                        Logger.info("Step.UPDATE_CONFIG");
                        flowInfo = doUpdateConfig(flowInfo);
                        break;
                    case Step.REGISTER_FIREWALL:
                        Logger.info("Step.REGISTER_FIREWALL");
                        flowInfo = doRegisterFirewall(flowInfo);
                        break;
                    case Step.NO_MORE_STEP:
                        Logger.info("Step.NO_MORE_STEP");
                        break;
                    case Step.NONE:
                        Logger.info("Step.NONE");
                        break;
                }
                if (flowInfo != null && flowInfo.NextStep == Step.NO_MORE_STEP)
                {
                    Logger.info("DoMain Exit.");
                    break;
                }
            }
        }
        #endregion 

        #region /* 설정값 지정 */
        private FlowInfo doSetConfig(FlowInfo flowInfo) {
            
            //포트등록 및 config 파일 백업
            FrmConfig frmConfig = new FrmConfig(this.context, ctr);
            //포트 등록 및 기존 config유지 선택
            flowInfo.PrevStep = Step.SET_CONFIG;
            DialogResult dialogResult = frmConfig.ShowDialog(wrapper);
            if (dialogResult == DialogResult.OK)
            {
                ctr.UpdatePorts();

                if (ctr.KeepPrevConfig)
                {
                    Logger.info("Config file정보 복원.");
                    flowInfo.NextStep = Step.UPDATE_CONFIG;
                }
                else
                {
                    Logger.info("Config file정보 복원하지 않음.");
                    flowInfo.NextStep = Step.REGISTER_FIREWALL;
                }
            }
            else
            {
                Logger.error("설정중 설치취소");
                throw new Exception("설정중 설치취소");
            }

            frmConfig.Dispose();

            return flowInfo;
        }
        #endregion

        #region /* 설정값 변경 */
        private FlowInfo doUpdateConfig(FlowInfo flowInfo) {
            ctr.RecoverConfigFile();
            flowInfo.PrevStep = Step.UPDATE_CONFIG;
            flowInfo.NextStep = Step.REGISTER_FIREWALL;
            return flowInfo;
        }
        #endregion

        #region /* 방화벽 등록 */
        private FlowInfo doRegisterFirewall(FlowInfo flowInfo) {
            FrmStatus frmStatusFirewall = new FrmStatus(this.context, ConstDef.mainTitle
                                                       , "방화벽설정을 등록합니다.", ctr.RegisterFirewall);

            if (frmStatusFirewall != null)
            {
                ctr.LogWriteHandler += frmStatusFirewall.OnStatusWrite;
                if (frmStatusFirewall.ShowDialog(wrapper) == DialogResult.OK)
                {
                    Logger.info("방화벽등록 완료");
                }
                else
                {
                    Logger.error("방화벽등록중 설치취소");
                    throw new Exception("방화벽등록중 설치취소");
                }
                ctr.LogWriteHandler -= frmStatusFirewall.OnStatusWrite;
                frmStatusFirewall.Dispose();
            }
            flowInfo.PrevStep = Step.REGISTER_FIREWALL;
            flowInfo.NextStep = Step.NO_MORE_STEP;

            return flowInfo;
        }
        #endregion
    }

    public class FlowInfo
    {
        Step prevStep = Step.NONE;
        public Step PrevStep
        {
            get { return prevStep; }
            set { prevStep = value; }
        }
        Step nextStep = Step.SET_CONFIG;
        public Step NextStep
        {
            get { return nextStep; }
            set { nextStep = value; }
        }
    }

    public enum Step
    {
        SET_CONFIG,              /* 설정값 지정(포트: 3306,8886,8888 */
        UPDATE_CONFIG,           /* 설정값 변경 */
        REGISTER_FIREWALL,       /* 방화벽 등록 */
        NO_MORE_STEP,            /* 추가 진행없음 */
        NONE                     /* 미설정 */
    }

    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        public IntPtr Handle
        {
            get { return _hwnd; }
        }

        private IntPtr _hwnd;
    }

}
