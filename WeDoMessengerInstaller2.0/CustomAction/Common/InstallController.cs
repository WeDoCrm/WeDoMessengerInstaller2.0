using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using WeDoCommon;
using System.Management;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Data;

namespace CustomAction
{
    public class InstallController
    {
        bool needWinpcapInstall = false;

        private FirewallHandler firewallHandler = new FirewallHandler();
        private WindowServiceHandler serviceHandler = new WindowServiceHandler();
        private SocketHandler socketHandler = new SocketHandler();
        private ConfigFileHandler configFileHandler = new ConfigFileHandler(ConstDef.WEDO_MSGR_DIR, ConstDef.WEDO_CLIENT_EXE);

        int dbPort = 3306;
        public int DbPort { get { return dbPort; } set { dbPort = value; } }

        int msgrPort = 8888;
        public int MsgrPort { get { return msgrPort; } set { msgrPort = value; } }

        int crmPort = 8886;
        public int CrmPort { get { return crmPort; } set { crmPort = value; } }

        int ftpPort = 8887;
        public int FtpPort { get { return ftpPort; } set { ftpPort = value; } }
        
        bool keepPrevConfig = false;

        public bool KeepPrevConfig
        {
            get { return keepPrevConfig; }
            set { keepPrevConfig = value; }
        }

        public bool PortAlreadyUsed(int port)
        {
            Logger.info("PortAlreadyUsed:"+port);
            return socketHandler.IsTcpPortInUse(port);
        }
        
        /// <summary>
        /// 현재 설치된 WeDo Server가 있는지 확인한다.
        /// 확인방법: backup config 파일
        /// </summary>
        /// <returns></returns>
        public bool prevWeDoExists()
        {
            Logger.info("CheckPrevWeDoExists");
            bool result = false;

            try
            {
                if (!configFileHandler.PrevConfigExists())
                {
                    Logger.info("WeDo 미설치상태");
                }
                else
                {
                    Logger.info("WeDo 설치상태");
                    result = true;
                }
            }
            catch (Exception e)
            {
                Logger.error("WeDo 미설치상태");
                result = false;
            }
            return result;
        }
        /// <summary>
        /// Port값 3306,8886,8888을 config파일에만 적용.
        /// </summary>
        /// <returns></returns>
        public bool UpdatePorts()
        {
            Logger.info("UpdatePorts");
            bool result = false;

            try
            {
                OnWriteLog(string.Format("config파일 CRM Port 설정==>{0}", crmPort));
                configFileHandler.SetValue(ConstDef.CONFIG_CRM_PORT_NAME, Convert.ToString(crmPort));

                OnWriteLog(string.Format("config파일 MSGR Port 설정==>{0}", msgrPort));
                configFileHandler.SetValue(ConstDef.CONFIG_MSGR_PORT_NAME, Convert.ToString(msgrPort));

                OnWriteLog(string.Format("config파일 FTP Port 설정==>{0}", ftpPort));
                configFileHandler.SetValue(ConstDef.CONFIG_FTP_PORT_NAME, Convert.ToString(ftpPort));

                OnWriteLog(string.Format("config파일 DB Port 설정==>{0}", dbPort));
                configFileHandler.SetValue(ConstDef.CONFIG_DB_PORT_NAME, Convert.ToString(dbPort));

                result = true;
            }
            catch (Exception ex)
            {
                Logger.error("config파일 복구중 에러:" + ex.ToString());
                throw new Exception("config파일 복구중 설치취소");
            }
            return result;
        }

        /// <summary>
        /// backup된 config정보를 실제 config에 반영
        /// </summary>
        /// <returns></returns>
        public bool RecoverConfigFile()
        {
            Logger.info("RecoverConfigFile");
            bool result = false;

            try
            {
                OnWriteLog("백업된 config파일 복구");
                configFileHandler.RecoverConfig();
                result = true;
            }
            catch (Exception e)
            {
                Logger.error("config파일 복구중 에러");
            }
            return result;
        }

        /// <summary>
        /// 설치된 WeDo의 config파일이 이전버전인지 확인
        /// </summary>
        /// <returns></returns>
        public bool IsPrevConfigDifferent()
        {
            bool result = true;

            try
            {
                result = !configFileHandler.KeyExistsInCurrentConfig("SocketPortMsgr");
            }
            catch (Exception e)
            {
                Logger.error("IsPrevConfigDifferent 오류" + e.ToString());
                result = true;
            }
            return result;

        }

        //1. 위두서버 방화벽확인 및 설치
        //2. 디비서버 방화벽확인 및 설치
        public bool RegisterFirewall()
        {
            bool result = false;

            OnWriteLog("<< 방화벽 설정 >>");
            OnWriteLog("----------------------------------------");
            Logger.info("RegisterFirewall");

            try
            {
                OnWriteLog("- CRM Port 방화벽 등록 확인");
                string crmPortStatus = firewallHandler.GetByPort(crmPort);
                if (crmPortStatus == null)
                {
                    OnWriteLog("======> 미등록상태\n CRM Port를 방화벽 예외등록합니다.");
                    if (firewallHandler.AddPort(ConstDef.WEDO_CRM_PORT_FIREWALL_NAME, crmPort, false))
                        OnWriteLog("======> 등록 완료");
                    else
                    {
                        OnWriteLog("======> 등록 실패");
                        throw new Exception("CRM Port 방화벽 예외등록중 오류발생");
                    }
                }
                else
                    OnWriteLog("이미 등록되어 있습니다.");

                OnWriteLog("----------------------------------------");

                OnWriteLog("- Messenger Port 방화벽 등록 확인");
                string msgrPortStatus = firewallHandler.GetByPort(msgrPort);
                if (msgrPortStatus == null)
                {
                    OnWriteLog("======> 미등록상태\n Messenger Port를 방화벽 예외등록합니다.");
                    if (firewallHandler.AddPort(ConstDef.WEDO_MSGR_PORT_FIREWALL_NAME, msgrPort, false))
                        OnWriteLog("======> 등록 완료");
                    else
                    {
                        OnWriteLog("======> 등록 실패");
                        throw new Exception("Messenger Port 방화벽 예외등록중 오류발생");
                    }
                }
                else
                    OnWriteLog("이미 등록되어 있습니다.");
                
                OnWriteLog("----------------------------------------");

                OnWriteLog("- FTP Port 방화벽 등록 확인");
                string ftpPortStatus = firewallHandler.GetByPort(ftpPort);
                if (ftpPortStatus == null)
                {
                    OnWriteLog("======> 미등록상태\n FTP Port를 방화벽 예외등록합니다.");
                    if (firewallHandler.AddPort(ConstDef.WEDO_FTP_PORT_FIREWALL_NAME, ftpPort, false))
                        OnWriteLog("======> 등록 완료");
                    else
                    {
                        OnWriteLog("======> 등록 실패");
                        throw new Exception("FTP Port 방화벽 예외등록중 오류발생");
                    }
                }
                else
                    OnWriteLog("이미 등록되어 있습니다.");

                OnWriteLog("----------------------------------------");

                OnWriteLog("- DB Port 방화벽 등록 확인");
                string dbPortStatus = firewallHandler.GetByPort(dbPort);
                if (dbPortStatus == null)
                {
                    OnWriteLog("======> 미등록상태\n DB Port를 방화벽 예외등록합니다.");
                    if (firewallHandler.AddPort(ConstDef.WEDO_DB_PORT_FIREWALL_NAME, dbPort, false))
                        OnWriteLog("======> 등록 완료");
                    else
                    {
                        OnWriteLog("======> 등록 실패");
                        throw new Exception("DB Port 방화벽 예외등록중 오류발생");
                    }
                }
                else
                    OnWriteLog("이미 등록되어 있습니다.");
                
                OnWriteLog("----------------------------------------");

                result = true;
            }

            catch (Exception ex)
            {
                Logger.error(ex.ToString());
                result = false;
            }
            return result;
        }

        public event EventHandler<StringEventArgs> LogWriteHandler;

        public virtual void OnWriteLog(string msg)
        {
            Logger.info(msg);
            EventHandler<StringEventArgs> handler = this.LogWriteHandler;
            if (this.LogWriteHandler != null)
            {
                handler(this, new StringEventArgs(msg));
            }
        }

    }
}
