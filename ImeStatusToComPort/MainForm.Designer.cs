namespace Shapoco.ImeStatusToComPort
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabMain_Settings = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkRegisterToStartup = new System.Windows.Forms.CheckBox();
            this.lnkStartupFolder = new System.Windows.Forms.LinkLabel();
            this.lnkOpenAppDataFolder = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.optPortFindMethod_FullName = new System.Windows.Forms.RadioButton();
            this.optPortFindMethod_DeviceName = new System.Windows.Forms.RadioButton();
            this.optPortFindMethod_PortName = new System.Windows.Forms.RadioButton();
            this.lnkReloadPortList = new System.Windows.Forms.LinkLabel();
            this.cmbPortList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkAssignment_Error_Rts = new System.Windows.Forms.CheckBox();
            this.chkAssignment_ImeOn_Rts = new System.Windows.Forms.CheckBox();
            this.chkAssignment_ImeOff_Rts = new System.Windows.Forms.CheckBox();
            this.chkAssignment_Shutdown_Rts = new System.Windows.Forms.CheckBox();
            this.chkAssignment_Error_Dtr = new System.Windows.Forms.CheckBox();
            this.chkAssignment_ImeOn_Dtr = new System.Windows.Forms.CheckBox();
            this.chkAssignment_ImeOff_Dtr = new System.Windows.Forms.CheckBox();
            this.chkAssignment_Shutdown_Dtr = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabMain_State = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cmnTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnTrayMenu_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnTrayMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbBlinkCount_ImeOff = new System.Windows.Forms.ComboBox();
            this.cmbBlinkCount_ImeOn = new System.Windows.Forms.ComboBox();
            this.cmbBlinkCount_Error = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkDontBlinkOnNormalToggle = new System.Windows.Forms.CheckBox();
            this.tabMain.SuspendLayout();
            this.tabMain_Settings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabMain_State.SuspendLayout();
            this.cmnTrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabMain_Settings);
            this.tabMain.Controls.Add(this.tabMain_State);
            this.tabMain.Location = new System.Drawing.Point(12, 13);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(455, 537);
            this.tabMain.TabIndex = 0;
            // 
            // tabMain_Settings
            // 
            this.tabMain_Settings.Controls.Add(this.groupBox3);
            this.tabMain_Settings.Controls.Add(this.lnkOpenAppDataFolder);
            this.tabMain_Settings.Controls.Add(this.groupBox2);
            this.tabMain_Settings.Controls.Add(this.groupBox1);
            this.tabMain_Settings.Location = new System.Drawing.Point(4, 24);
            this.tabMain_Settings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain_Settings.Name = "tabMain_Settings";
            this.tabMain_Settings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain_Settings.Size = new System.Drawing.Size(447, 509);
            this.tabMain_Settings.TabIndex = 0;
            this.tabMain_Settings.Text = "設定";
            this.tabMain_Settings.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkRegisterToStartup);
            this.groupBox3.Controls.Add(this.lnkStartupFolder);
            this.groupBox3.Location = new System.Drawing.Point(20, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(411, 77);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "起動";
            // 
            // chkRegisterToStartup
            // 
            this.chkRegisterToStartup.AutoSize = true;
            this.chkRegisterToStartup.Location = new System.Drawing.Point(17, 22);
            this.chkRegisterToStartup.Name = "chkRegisterToStartup";
            this.chkRegisterToStartup.Size = new System.Drawing.Size(266, 19);
            this.chkRegisterToStartup.TabIndex = 0;
            this.chkRegisterToStartup.Text = "Windowsの起動時、自動的に本ソフトを起動する";
            this.chkRegisterToStartup.UseVisualStyleBackColor = true;
            // 
            // lnkStartupFolder
            // 
            this.lnkStartupFolder.AutoSize = true;
            this.lnkStartupFolder.Location = new System.Drawing.Point(290, 45);
            this.lnkStartupFolder.Name = "lnkStartupFolder";
            this.lnkStartupFolder.Size = new System.Drawing.Size(102, 15);
            this.lnkStartupFolder.TabIndex = 3;
            this.lnkStartupFolder.TabStop = true;
            this.lnkStartupFolder.Text = "スタートアップフォルダ";
            // 
            // lnkOpenAppDataFolder
            // 
            this.lnkOpenAppDataFolder.AutoSize = true;
            this.lnkOpenAppDataFolder.Location = new System.Drawing.Point(332, 478);
            this.lnkOpenAppDataFolder.Name = "lnkOpenAppDataFolder";
            this.lnkOpenAppDataFolder.Size = new System.Drawing.Size(99, 15);
            this.lnkOpenAppDataFolder.TabIndex = 3;
            this.lnkOpenAppDataFolder.TabStop = true;
            this.lnkOpenAppDataFolder.Text = "設定ファイルの場所";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblStatus);
            this.groupBox2.Controls.Add(this.optPortFindMethod_FullName);
            this.groupBox2.Controls.Add(this.optPortFindMethod_DeviceName);
            this.groupBox2.Controls.Add(this.optPortFindMethod_PortName);
            this.groupBox2.Controls.Add(this.lnkReloadPortList);
            this.groupBox2.Controls.Add(this.cmbPortList);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(20, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 132);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "COMポート";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblStatus.Location = new System.Drawing.Point(38, 99);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 15);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "-";
            // 
            // optPortFindMethod_FullName
            // 
            this.optPortFindMethod_FullName.AutoSize = true;
            this.optPortFindMethod_FullName.Location = new System.Drawing.Point(193, 46);
            this.optPortFindMethod_FullName.Name = "optPortFindMethod_FullName";
            this.optPortFindMethod_FullName.Size = new System.Drawing.Size(49, 19);
            this.optPortFindMethod_FullName.TabIndex = 4;
            this.optPortFindMethod_FullName.TabStop = true;
            this.optPortFindMethod_FullName.Text = "両方";
            this.optPortFindMethod_FullName.UseVisualStyleBackColor = true;
            // 
            // optPortFindMethod_DeviceName
            // 
            this.optPortFindMethod_DeviceName.AutoSize = true;
            this.optPortFindMethod_DeviceName.Location = new System.Drawing.Point(112, 46);
            this.optPortFindMethod_DeviceName.Name = "optPortFindMethod_DeviceName";
            this.optPortFindMethod_DeviceName.Size = new System.Drawing.Size(75, 19);
            this.optPortFindMethod_DeviceName.TabIndex = 4;
            this.optPortFindMethod_DeviceName.TabStop = true;
            this.optPortFindMethod_DeviceName.Text = "デバイス名";
            this.optPortFindMethod_DeviceName.UseVisualStyleBackColor = true;
            // 
            // optPortFindMethod_PortName
            // 
            this.optPortFindMethod_PortName.AutoSize = true;
            this.optPortFindMethod_PortName.Location = new System.Drawing.Point(41, 46);
            this.optPortFindMethod_PortName.Name = "optPortFindMethod_PortName";
            this.optPortFindMethod_PortName.Size = new System.Drawing.Size(65, 19);
            this.optPortFindMethod_PortName.TabIndex = 4;
            this.optPortFindMethod_PortName.TabStop = true;
            this.optPortFindMethod_PortName.Text = "ポート名";
            this.optPortFindMethod_PortName.UseVisualStyleBackColor = true;
            // 
            // lnkReloadPortList
            // 
            this.lnkReloadPortList.AutoSize = true;
            this.lnkReloadPortList.Location = new System.Drawing.Point(303, 99);
            this.lnkReloadPortList.Name = "lnkReloadPortList";
            this.lnkReloadPortList.Size = new System.Drawing.Size(89, 15);
            this.lnkReloadPortList.TabIndex = 3;
            this.lnkReloadPortList.TabStop = true;
            this.lnkReloadPortList.Text = "リスト再読み込み";
            // 
            // cmbPortList
            // 
            this.cmbPortList.FormattingEnabled = true;
            this.cmbPortList.Location = new System.Drawing.Point(41, 72);
            this.cmbPortList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPortList.Name = "cmbPortList";
            this.cmbPortList.Size = new System.Drawing.Size(351, 23);
            this.cmbPortList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "選択された名前が一致するCOMポートを使用します :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chkAssignment_Error_Rts);
            this.groupBox1.Controls.Add(this.chkAssignment_ImeOn_Rts);
            this.groupBox1.Controls.Add(this.chkAssignment_ImeOff_Rts);
            this.groupBox1.Controls.Add(this.chkAssignment_Shutdown_Rts);
            this.groupBox1.Controls.Add(this.cmbBlinkCount_Error);
            this.groupBox1.Controls.Add(this.cmbBlinkCount_ImeOn);
            this.groupBox1.Controls.Add(this.cmbBlinkCount_ImeOff);
            this.groupBox1.Controls.Add(this.chkAssignment_Error_Dtr);
            this.groupBox1.Controls.Add(this.chkAssignment_ImeOn_Dtr);
            this.groupBox1.Controls.Add(this.chkAssignment_ImeOff_Dtr);
            this.groupBox1.Controls.Add(this.chkDontBlinkOnNormalToggle);
            this.groupBox1.Controls.Add(this.chkAssignment_Shutdown_Dtr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(20, 240);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(411, 234);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "割り当て";
            // 
            // label7
            // 
            this.label7.Image = global::Shapoco.Properties.Resources.CircuitExample;
            this.label7.Location = new System.Drawing.Point(242, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 134);
            this.label7.TabIndex = 4;
            // 
            // chkAssignment_Error_Rts
            // 
            this.chkAssignment_Error_Rts.AutoSize = true;
            this.chkAssignment_Error_Rts.Location = new System.Drawing.Point(133, 143);
            this.chkAssignment_Error_Rts.Name = "chkAssignment_Error_Rts";
            this.chkAssignment_Error_Rts.Size = new System.Drawing.Size(15, 14);
            this.chkAssignment_Error_Rts.TabIndex = 3;
            this.chkAssignment_Error_Rts.UseVisualStyleBackColor = true;
            // 
            // chkAssignment_ImeOn_Rts
            // 
            this.chkAssignment_ImeOn_Rts.AutoSize = true;
            this.chkAssignment_ImeOn_Rts.Location = new System.Drawing.Point(133, 118);
            this.chkAssignment_ImeOn_Rts.Name = "chkAssignment_ImeOn_Rts";
            this.chkAssignment_ImeOn_Rts.Size = new System.Drawing.Size(15, 14);
            this.chkAssignment_ImeOn_Rts.TabIndex = 3;
            this.chkAssignment_ImeOn_Rts.UseVisualStyleBackColor = true;
            // 
            // chkAssignment_ImeOff_Rts
            // 
            this.chkAssignment_ImeOff_Rts.AutoSize = true;
            this.chkAssignment_ImeOff_Rts.Location = new System.Drawing.Point(133, 93);
            this.chkAssignment_ImeOff_Rts.Name = "chkAssignment_ImeOff_Rts";
            this.chkAssignment_ImeOff_Rts.Size = new System.Drawing.Size(15, 14);
            this.chkAssignment_ImeOff_Rts.TabIndex = 3;
            this.chkAssignment_ImeOff_Rts.UseVisualStyleBackColor = true;
            // 
            // chkAssignment_Shutdown_Rts
            // 
            this.chkAssignment_Shutdown_Rts.AutoSize = true;
            this.chkAssignment_Shutdown_Rts.Location = new System.Drawing.Point(133, 168);
            this.chkAssignment_Shutdown_Rts.Name = "chkAssignment_Shutdown_Rts";
            this.chkAssignment_Shutdown_Rts.Size = new System.Drawing.Size(15, 14);
            this.chkAssignment_Shutdown_Rts.TabIndex = 3;
            this.chkAssignment_Shutdown_Rts.UseVisualStyleBackColor = true;
            // 
            // chkAssignment_Error_Dtr
            // 
            this.chkAssignment_Error_Dtr.AutoSize = true;
            this.chkAssignment_Error_Dtr.Location = new System.Drawing.Point(91, 143);
            this.chkAssignment_Error_Dtr.Name = "chkAssignment_Error_Dtr";
            this.chkAssignment_Error_Dtr.Size = new System.Drawing.Size(15, 14);
            this.chkAssignment_Error_Dtr.TabIndex = 3;
            this.chkAssignment_Error_Dtr.UseVisualStyleBackColor = true;
            // 
            // chkAssignment_ImeOn_Dtr
            // 
            this.chkAssignment_ImeOn_Dtr.AutoSize = true;
            this.chkAssignment_ImeOn_Dtr.Location = new System.Drawing.Point(91, 118);
            this.chkAssignment_ImeOn_Dtr.Name = "chkAssignment_ImeOn_Dtr";
            this.chkAssignment_ImeOn_Dtr.Size = new System.Drawing.Size(15, 14);
            this.chkAssignment_ImeOn_Dtr.TabIndex = 3;
            this.chkAssignment_ImeOn_Dtr.UseVisualStyleBackColor = true;
            // 
            // chkAssignment_ImeOff_Dtr
            // 
            this.chkAssignment_ImeOff_Dtr.AutoSize = true;
            this.chkAssignment_ImeOff_Dtr.Location = new System.Drawing.Point(91, 93);
            this.chkAssignment_ImeOff_Dtr.Name = "chkAssignment_ImeOff_Dtr";
            this.chkAssignment_ImeOff_Dtr.Size = new System.Drawing.Size(15, 14);
            this.chkAssignment_ImeOff_Dtr.TabIndex = 3;
            this.chkAssignment_ImeOff_Dtr.UseVisualStyleBackColor = true;
            // 
            // chkAssignment_Shutdown_Dtr
            // 
            this.chkAssignment_Shutdown_Dtr.AutoSize = true;
            this.chkAssignment_Shutdown_Dtr.Location = new System.Drawing.Point(91, 168);
            this.chkAssignment_Shutdown_Dtr.Name = "chkAssignment_Shutdown_Dtr";
            this.chkAssignment_Shutdown_Dtr.Size = new System.Drawing.Size(15, 14);
            this.chkAssignment_Shutdown_Dtr.TabIndex = 3;
            this.chkAssignment_Shutdown_Dtr.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "取得エラー";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "IME ON";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(14, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 26);
            this.label6.TabIndex = 2;
            this.label6.Text = "チェックされた信号に Hi が出力されます :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "IME OFF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "消灯";
            // 
            // tabMain_State
            // 
            this.tabMain_State.Controls.Add(this.txtLog);
            this.tabMain_State.Location = new System.Drawing.Point(4, 24);
            this.tabMain_State.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain_State.Name = "tabMain_State";
            this.tabMain_State.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMain_State.Size = new System.Drawing.Size(414, 461);
            this.tabMain_State.TabIndex = 1;
            this.tabMain_State.Text = "ログ";
            this.tabMain_State.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLog.Location = new System.Drawing.Point(6, 7);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(398, 468);
            this.txtLog.TabIndex = 1;
            // 
            // cmnTrayMenu
            // 
            this.cmnTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnTrayMenu_Settings,
            this.toolStripSeparator1,
            this.cmnTrayMenu_Exit});
            this.cmnTrayMenu.Name = "cmnTrayMenu";
            this.cmnTrayMenu.Size = new System.Drawing.Size(99, 54);
            // 
            // cmnTrayMenu_Settings
            // 
            this.cmnTrayMenu_Settings.Name = "cmnTrayMenu_Settings";
            this.cmnTrayMenu_Settings.Size = new System.Drawing.Size(98, 22);
            this.cmnTrayMenu_Settings.Text = "設定";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(95, 6);
            // 
            // cmnTrayMenu_Exit
            // 
            this.cmnTrayMenu_Exit.Name = "cmnTrayMenu_Exit";
            this.cmnTrayMenu_Exit.Size = new System.Drawing.Size(98, 22);
            this.cmnTrayMenu_Exit.Text = "終了";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "DTR";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(124, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "RTS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(180, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "点滅";
            // 
            // cmbBlinkCount_ImeOff
            // 
            this.cmbBlinkCount_ImeOff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlinkCount_ImeOff.FormattingEnabled = true;
            this.cmbBlinkCount_ImeOff.Location = new System.Drawing.Point(167, 87);
            this.cmbBlinkCount_ImeOff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBlinkCount_ImeOff.Name = "cmbBlinkCount_ImeOff";
            this.cmbBlinkCount_ImeOff.Size = new System.Drawing.Size(60, 23);
            this.cmbBlinkCount_ImeOff.TabIndex = 1;
            // 
            // cmbBlinkCount_ImeOn
            // 
            this.cmbBlinkCount_ImeOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlinkCount_ImeOn.FormattingEnabled = true;
            this.cmbBlinkCount_ImeOn.Location = new System.Drawing.Point(167, 112);
            this.cmbBlinkCount_ImeOn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBlinkCount_ImeOn.Name = "cmbBlinkCount_ImeOn";
            this.cmbBlinkCount_ImeOn.Size = new System.Drawing.Size(60, 23);
            this.cmbBlinkCount_ImeOn.TabIndex = 1;
            // 
            // cmbBlinkCount_Error
            // 
            this.cmbBlinkCount_Error.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlinkCount_Error.FormattingEnabled = true;
            this.cmbBlinkCount_Error.Location = new System.Drawing.Point(167, 137);
            this.cmbBlinkCount_Error.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBlinkCount_Error.Name = "cmbBlinkCount_Error";
            this.cmbBlinkCount_Error.Size = new System.Drawing.Size(60, 23);
            this.cmbBlinkCount_Error.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "状態";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label12.Location = new System.Drawing.Point(14, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(213, 1);
            this.label12.TabIndex = 2;
            this.label12.Text = "状態";
            // 
            // chkDontBlinkOnNormalToggle
            // 
            this.chkDontBlinkOnNormalToggle.AutoSize = true;
            this.chkDontBlinkOnNormalToggle.Location = new System.Drawing.Point(17, 199);
            this.chkDontBlinkOnNormalToggle.Name = "chkDontBlinkOnNormalToggle";
            this.chkDontBlinkOnNormalToggle.Size = new System.Drawing.Size(272, 19);
            this.chkDontBlinkOnNormalToggle.TabIndex = 3;
            this.chkDontBlinkOnNormalToggle.Text = "点滅はフォーカスが移動した時とエラーの時だけにする";
            this.chkDontBlinkOnNormalToggle.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 563);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tabMain.ResumeLayout(false);
            this.tabMain_Settings.ResumeLayout(false);
            this.tabMain_Settings.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabMain_State.ResumeLayout(false);
            this.tabMain_State.PerformLayout();
            this.cmnTrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabMain_Settings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabMain_State;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbPortList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAssignment_Error_Rts;
        private System.Windows.Forms.CheckBox chkAssignment_ImeOn_Rts;
        private System.Windows.Forms.CheckBox chkAssignment_ImeOff_Rts;
        private System.Windows.Forms.CheckBox chkAssignment_Shutdown_Rts;
        private System.Windows.Forms.CheckBox chkAssignment_Error_Dtr;
        private System.Windows.Forms.CheckBox chkAssignment_ImeOn_Dtr;
        private System.Windows.Forms.CheckBox chkAssignment_ImeOff_Dtr;
        private System.Windows.Forms.CheckBox chkAssignment_Shutdown_Dtr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkReloadPortList;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.RadioButton optPortFindMethod_FullName;
        private System.Windows.Forms.RadioButton optPortFindMethod_DeviceName;
        private System.Windows.Forms.RadioButton optPortFindMethod_PortName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkRegisterToStartup;
        private System.Windows.Forms.LinkLabel lnkStartupFolder;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.LinkLabel lnkOpenAppDataFolder;
        private System.Windows.Forms.ContextMenuStrip cmnTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnTrayMenu_Settings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmnTrayMenu_Exit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBlinkCount_Error;
        private System.Windows.Forms.ComboBox cmbBlinkCount_ImeOn;
        private System.Windows.Forms.ComboBox cmbBlinkCount_ImeOff;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkDontBlinkOnNormalToggle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
    }
}

