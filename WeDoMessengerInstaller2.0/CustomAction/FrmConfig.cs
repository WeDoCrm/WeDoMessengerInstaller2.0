using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration.Install;
using System.IO;
using WeDoCommon;
using System.Diagnostics;

namespace CustomAction
{
    public partial class FrmConfig : Form
    {
        System.Configuration.Install.InstallContext formContext = null;
        InstallController ctrl = null;

        public delegate void DelAppendStatusMsg(string msg);
        DelAppendStatusMsg delAppendStatusMsg = null;

        public FrmConfig()
        {
            InitializeComponent();
        }

        //폼 우측상단 버튼 안보임
        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        public FrmConfig(System.Configuration.Install.InstallContext context, InstallController ctrl)
        {
            formContext = context;
            this.ctrl = ctrl;
            InitializeComponent();
            this.CenterToScreen();
        }

        /// <summary>
        /// 회사코드가 변경된 경우는 db재설치를 한경우
        /// 신규이거나 변경사항 없으면 패스
        /// 등록한 라이센스파일을 C:\eclues\AppData\config로 복사. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            int dbPort = Convert.ToInt16(TextBoxDbPort.Text);
            int crmPort = Convert.ToInt16(TextBoxCrmPort.Text);
            int msgrPort = Convert.ToInt16(TextBoxMsgrPort.Text);
            int ftpPort = Convert.ToInt16(TextBoxFTPPort.Text);

            if (dbPort != ctrl.DbPort || crmPort != ctrl.CrmPort || msgrPort != ctrl.MsgrPort || ftpPort != ctrl.FtpPort)
            {
                if (MessageBox.Show("포트값이 수정되었습니다." + Environment.NewLine + "변경된 포트값을 적용하시겠습니까?"
                                    , "포트 변경"
                                    , MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    DialogResult = DialogResult.None;
                    TextBoxMsgrPort.Focus();
                    return;
                }
            }
            ctrl.DbPort = dbPort;
            ctrl.CrmPort = crmPort;
            ctrl.MsgrPort = msgrPort;
            ctrl.FtpPort = ftpPort;
            ctrl.KeepPrevConfig = CkBoxKeepConfig.Checked;
        }

        public void OnStatusWrite(object sender, StringEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                Logger.info(e.EventString);
            });
        }

        private void TextBoxDbPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void FrmConfig_Shown(object sender, EventArgs e)
        {
            //wedo가 설치된게 있는지 확인한다.
            //있는경우 
            //하단 질문을 보여준다.
            SetPrevWeDoInfo();
        }

        public void SetPrevWeDoInfo()
        {
            //기존에 설치된 파일이 있는지 확인
            //있는 경우 설치제거를 가이드한다.
            if (ctrl.IsPrevConfigDifferent())
            {
                panel1.Enabled = false;
                panel2.Enabled = false;
                panel3.Visible = true;
                ButtonNext.Enabled = false;
            }
            else
            {
                if (ctrl.prevWeDoExists())
                {
                    panel1.Visible = true;
                    CkBoxKeepConfig.Checked = true;
                }
                else
                {
                    panel1.Visible = false;
                }
            }
        }

        public bool KeepConfig()
        {
            return CkBoxKeepConfig.Checked;
        }
    }
}
