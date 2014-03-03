namespace CustomAction
{
    partial class FrmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxDbPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxCrmPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LabelMsg2 = new System.Windows.Forms.Label();
            this.TextBoxMsgrPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CkBoxKeepConfig = new System.Windows.Forms.CheckBox();
            this.LabelMsg = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxFTPPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Location = new System.Drawing.Point(32, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(540, 336);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.TextBoxFTPPort);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.TextBoxDbPort);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.TextBoxCrmPort);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.LabelMsg2);
            this.panel2.Controls.Add(this.TextBoxMsgrPort);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(13, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 194);
            this.panel2.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(508, 36);
            this.label7.TabIndex = 16;
            this.label7.Text = "WeDo 서버 설치시 기본 포트값을 변경하지 않았으면 아래 지정값을 변경하지 않도록 합니다.";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(238, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(272, 22);
            this.label6.TabIndex = 15;
            this.label6.Text = "DB 통신에 필요한 포트입니다.";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(238, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 22);
            this.label4.TabIndex = 14;
            this.label4.Text = "CRM프로그램이 서버통신에 필요한 포트입니다.";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(238, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "메신저간 통신에 필요한 포트입니다.";
            // 
            // TextBoxDbPort
            // 
            this.TextBoxDbPort.Location = new System.Drawing.Point(195, 156);
            this.TextBoxDbPort.MaxLength = 4;
            this.TextBoxDbPort.Name = "TextBoxDbPort";
            this.TextBoxDbPort.Size = new System.Drawing.Size(36, 21);
            this.TextBoxDbPort.TabIndex = 11;
            this.TextBoxDbPort.Text = "3306";
            this.TextBoxDbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxDbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDbPort_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "DB 포트       ( 기본값 3306 )   :";
            // 
            // TextBoxCrmPort
            // 
            this.TextBoxCrmPort.Location = new System.Drawing.Point(195, 103);
            this.TextBoxCrmPort.MaxLength = 4;
            this.TextBoxCrmPort.Name = "TextBoxCrmPort";
            this.TextBoxCrmPort.Size = new System.Drawing.Size(36, 21);
            this.TextBoxCrmPort.TabIndex = 8;
            this.TextBoxCrmPort.Text = "8886";
            this.TextBoxCrmPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxCrmPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDbPort_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "CRM 포트    ( 기본값 8886 )   :";
            // 
            // LabelMsg2
            // 
            this.LabelMsg2.AutoSize = true;
            this.LabelMsg2.Location = new System.Drawing.Point(5, 20);
            this.LabelMsg2.Name = "LabelMsg2";
            this.LabelMsg2.Size = new System.Drawing.Size(209, 12);
            this.LabelMsg2.TabIndex = 4;
            this.LabelMsg2.Text = "WeDo가 사용하는 포트를 지정합니다.";
            // 
            // TextBoxMsgrPort
            // 
            this.TextBoxMsgrPort.Location = new System.Drawing.Point(195, 77);
            this.TextBoxMsgrPort.MaxLength = 4;
            this.TextBoxMsgrPort.Name = "TextBoxMsgrPort";
            this.TextBoxMsgrPort.Size = new System.Drawing.Size(36, 21);
            this.TextBoxMsgrPort.TabIndex = 5;
            this.TextBoxMsgrPort.Text = "8888";
            this.TextBoxMsgrPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxMsgrPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDbPort_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "메신저 포트  ( 기본값 8888 )   :";
            // 
            // ButtonNext
            // 
            this.ButtonNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonNext.Location = new System.Drawing.Point(392, 374);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(87, 23);
            this.ButtonNext.TabIndex = 17;
            this.ButtonNext.Text = "다음 >";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(484, 374);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(87, 23);
            this.ButtonCancel.TabIndex = 16;
            this.ButtonCancel.Text = "취소";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "ini";
            this.openFileDialog1.Filter = "WeDo License 파일|*.ini";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CkBoxKeepConfig);
            this.panel1.Controls.Add(this.LabelMsg);
            this.panel1.Location = new System.Drawing.Point(13, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 65);
            this.panel1.TabIndex = 19;
            // 
            // CkBoxKeepConfig
            // 
            this.CkBoxKeepConfig.AutoSize = true;
            this.CkBoxKeepConfig.Location = new System.Drawing.Point(16, 35);
            this.CkBoxKeepConfig.Name = "CkBoxKeepConfig";
            this.CkBoxKeepConfig.Size = new System.Drawing.Size(96, 16);
            this.CkBoxKeepConfig.TabIndex = 5;
            this.CkBoxKeepConfig.Text = "기존설정유지";
            this.CkBoxKeepConfig.UseVisualStyleBackColor = true;
            // 
            // LabelMsg
            // 
            this.LabelMsg.AutoSize = true;
            this.LabelMsg.Location = new System.Drawing.Point(8, 11);
            this.LabelMsg.Name = "LabelMsg";
            this.LabelMsg.Size = new System.Drawing.Size(275, 12);
            this.LabelMsg.TabIndex = 4;
            this.LabelMsg.Text = "이전에 설치된 프로그램설정을 유지하시겠습니까?";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(238, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(272, 22);
            this.label8.TabIndex = 19;
            this.label8.Text = "메신저 파일전송에 필요한 포트입니다.";
            // 
            // TextBoxFTPPort
            // 
            this.TextBoxFTPPort.Location = new System.Drawing.Point(195, 129);
            this.TextBoxFTPPort.MaxLength = 4;
            this.TextBoxFTPPort.Name = "TextBoxFTPPort";
            this.TextBoxFTPPort.Size = new System.Drawing.Size(36, 21);
            this.TextBoxFTPPort.TabIndex = 17;
            this.TextBoxFTPPort.Text = "8887";
            this.TextBoxFTPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "FTP 포트    ( 기본값 8887 )   :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(13, 293);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(401, 37);
            this.panel3.TabIndex = 20;
            this.panel3.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(8, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(373, 24);
            this.label10.TabIndex = 4;
            this.label10.Text = "이전에 설치된 프로그램이 현재 설치할 프로그램과 버전이 다릅니다.\r\n이전 프로그램을 삭제후 설치를 하셔야 합니다.\r\n";
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 422);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmConfig";
            this.Text = "WeDo 설치 - 포트등록";
            this.Shown += new System.EventHandler(this.FrmConfig_Shown);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LabelMsg2;
        private System.Windows.Forms.TextBox TextBoxMsgrPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxDbPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxCrmPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox CkBoxKeepConfig;
        private System.Windows.Forms.Label LabelMsg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxFTPPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;

    }
}