namespace FROST_configManager
{
    partial class configManagerForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_DeviceInformation = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMeasurmentInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtSetNewPassword2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSetNewPassword1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabNetworking = new System.Windows.Forms.TabPage();
            this.groupBoxSetNetworkingSettings = new System.Windows.Forms.GroupBox();
            this.checkBox_NetworkSettingsRebootDevice = new System.Windows.Forms.CheckBox();
            this.panel_NetworkSettingsInputs = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIPAdress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGateWay = new System.Windows.Forms.TextBox();
            this.txtNetMask = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_DHCPorSTATIC_IP = new System.Windows.Forms.ComboBox();
            this.tabMySQL = new System.Windows.Forms.TabPage();
            this.groupBoxMySQLConfig = new System.Windows.Forms.GroupBox();
            this.panel_MySqlServerSettingsInputs = new System.Windows.Forms.Panel();
            this.checkBox_MySqlTableNameUseDeviceName = new System.Windows.Forms.CheckBox();
            this.txtMySqlServerTableName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMySqlServerDatabaseName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMySqlServerPassword = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMySqlServerUsername = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMySqlServerIP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox_DisableMySQL = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTempRangeMin = new System.Windows.Forms.TextBox();
            this.txtTempRangeMax = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tabEmail = new System.Windows.Forms.TabPage();
            this.listBox_EmailAdresses = new System.Windows.Forms.ListBox();
            this.btnSaveNewEmailAdress = new System.Windows.Forms.Button();
            this.btnDeleteSelectedEmailAdress = new System.Windows.Forms.Button();
            this.txtNewEmailAdress = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabNetworking.SuspendLayout();
            this.groupBoxSetNetworkingSettings.SuspendLayout();
            this.panel_NetworkSettingsInputs.SuspendLayout();
            this.tabMySQL.SuspendLayout();
            this.groupBoxMySQLConfig.SuspendLayout();
            this.panel_MySqlServerSettingsInputs.SuspendLayout();
            this.tabEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 57);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 39);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device information:";
            // 
            // richTextBox_DeviceInformation
            // 
            this.richTextBox_DeviceInformation.Location = new System.Drawing.Point(9, 20);
            this.richTextBox_DeviceInformation.Name = "richTextBox_DeviceInformation";
            this.richTextBox_DeviceInformation.ReadOnly = true;
            this.richTextBox_DeviceInformation.Size = new System.Drawing.Size(337, 160);
            this.richTextBox_DeviceInformation.TabIndex = 2;
            this.richTextBox_DeviceInformation.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Device name:";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(85, 195);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(261, 20);
            this.txtDeviceName.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMeasurmentInterval
            // 
            this.txtMeasurmentInterval.Location = new System.Drawing.Point(172, 224);
            this.txtMeasurmentInterval.Name = "txtMeasurmentInterval";
            this.txtMeasurmentInterval.Size = new System.Drawing.Size(174, 20);
            this.txtMeasurmentInterval.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Measurement interval (seconds):";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.btnExit);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(734, 537);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabEmail);
            this.tabControl1.Controls.Add(this.tabUsers);
            this.tabControl1.Controls.Add(this.tabNetworking);
            this.tabControl1.Controls.Add(this.tabMySQL);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(631, 537);
            this.tabControl1.TabIndex = 8;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.txtTempRangeMax);
            this.tabGeneral.Controls.Add(this.label19);
            this.tabGeneral.Controls.Add(this.txtTempRangeMin);
            this.tabGeneral.Controls.Add(this.label18);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.txtDeviceName);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.richTextBox_DeviceInformation);
            this.tabGeneral.Controls.Add(this.txtMeasurmentInterval);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(623, 511);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.groupBox1);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(623, 511);
            this.tabUsers.TabIndex = 1;
            this.tabUsers.Text = "Users & Passwords";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCurrentPassword);
            this.groupBox1.Controls.Add(this.txtSetNewPassword2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSetNewPassword1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 160);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set new password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "User:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(131, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(158, 20);
            this.txtUsername.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Current password:";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(131, 51);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(158, 20);
            this.txtCurrentPassword.TabIndex = 5;
            // 
            // txtSetNewPassword2
            // 
            this.txtSetNewPassword2.Location = new System.Drawing.Point(131, 101);
            this.txtSetNewPassword2.Name = "txtSetNewPassword2";
            this.txtSetNewPassword2.PasswordChar = '*';
            this.txtSetNewPassword2.Size = new System.Drawing.Size(158, 20);
            this.txtSetNewPassword2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Set new password:";
            // 
            // txtSetNewPassword1
            // 
            this.txtSetNewPassword1.Location = new System.Drawing.Point(131, 77);
            this.txtSetNewPassword1.Name = "txtSetNewPassword1";
            this.txtSetNewPassword1.PasswordChar = '*';
            this.txtSetNewPassword1.Size = new System.Drawing.Size(158, 20);
            this.txtSetNewPassword1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Retype new password:";
            // 
            // tabNetworking
            // 
            this.tabNetworking.Controls.Add(this.groupBoxSetNetworkingSettings);
            this.tabNetworking.Location = new System.Drawing.Point(4, 22);
            this.tabNetworking.Name = "tabNetworking";
            this.tabNetworking.Padding = new System.Windows.Forms.Padding(3);
            this.tabNetworking.Size = new System.Drawing.Size(623, 511);
            this.tabNetworking.TabIndex = 2;
            this.tabNetworking.Text = "Networking";
            this.tabNetworking.UseVisualStyleBackColor = true;
            // 
            // groupBoxSetNetworkingSettings
            // 
            this.groupBoxSetNetworkingSettings.Controls.Add(this.checkBox_NetworkSettingsRebootDevice);
            this.groupBoxSetNetworkingSettings.Controls.Add(this.panel_NetworkSettingsInputs);
            this.groupBoxSetNetworkingSettings.Controls.Add(this.label12);
            this.groupBoxSetNetworkingSettings.Controls.Add(this.label11);
            this.groupBoxSetNetworkingSettings.Controls.Add(this.comboBox_DHCPorSTATIC_IP);
            this.groupBoxSetNetworkingSettings.Location = new System.Drawing.Point(6, 6);
            this.groupBoxSetNetworkingSettings.Name = "groupBoxSetNetworkingSettings";
            this.groupBoxSetNetworkingSettings.Size = new System.Drawing.Size(319, 219);
            this.groupBoxSetNetworkingSettings.TabIndex = 0;
            this.groupBoxSetNetworkingSettings.TabStop = false;
            this.groupBoxSetNetworkingSettings.Text = "Network settings:";
            // 
            // checkBox_NetworkSettingsRebootDevice
            // 
            this.checkBox_NetworkSettingsRebootDevice.AutoSize = true;
            this.checkBox_NetworkSettingsRebootDevice.Location = new System.Drawing.Point(23, 64);
            this.checkBox_NetworkSettingsRebootDevice.Name = "checkBox_NetworkSettingsRebootDevice";
            this.checkBox_NetworkSettingsRebootDevice.Size = new System.Drawing.Size(205, 17);
            this.checkBox_NetworkSettingsRebootDevice.TabIndex = 9;
            this.checkBox_NetworkSettingsRebootDevice.Text = "Reboot the device after saving data? ";
            this.checkBox_NetworkSettingsRebootDevice.UseVisualStyleBackColor = true;
            // 
            // panel_NetworkSettingsInputs
            // 
            this.panel_NetworkSettingsInputs.Controls.Add(this.label8);
            this.panel_NetworkSettingsInputs.Controls.Add(this.txtIPAdress);
            this.panel_NetworkSettingsInputs.Controls.Add(this.label9);
            this.panel_NetworkSettingsInputs.Controls.Add(this.txtGateWay);
            this.panel_NetworkSettingsInputs.Controls.Add(this.txtNetMask);
            this.panel_NetworkSettingsInputs.Controls.Add(this.label10);
            this.panel_NetworkSettingsInputs.Location = new System.Drawing.Point(6, 97);
            this.panel_NetworkSettingsInputs.Name = "panel_NetworkSettingsInputs";
            this.panel_NetworkSettingsInputs.Size = new System.Drawing.Size(303, 105);
            this.panel_NetworkSettingsInputs.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ip-adress:";
            // 
            // txtIPAdress
            // 
            this.txtIPAdress.Location = new System.Drawing.Point(73, 11);
            this.txtIPAdress.Name = "txtIPAdress";
            this.txtIPAdress.Size = new System.Drawing.Size(213, 20);
            this.txtIPAdress.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Netmask:";
            // 
            // txtGateWay
            // 
            this.txtGateWay.Location = new System.Drawing.Point(73, 63);
            this.txtGateWay.Name = "txtGateWay";
            this.txtGateWay.Size = new System.Drawing.Size(213, 20);
            this.txtGateWay.TabIndex = 5;
            // 
            // txtNetMask
            // 
            this.txtNetMask.Location = new System.Drawing.Point(73, 37);
            this.txtNetMask.Name = "txtNetMask";
            this.txtNetMask.Size = new System.Drawing.Size(213, 20);
            this.txtNetMask.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Gateway:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(241, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Network configuration needs a reboot to activate:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Ip address type:";
            // 
            // comboBox_DHCPorSTATIC_IP
            // 
            this.comboBox_DHCPorSTATIC_IP.FormattingEnabled = true;
            this.comboBox_DHCPorSTATIC_IP.Items.AddRange(new object[] {
            "Dynamic (DHCP)",
            "Static"});
            this.comboBox_DHCPorSTATIC_IP.Location = new System.Drawing.Point(94, 24);
            this.comboBox_DHCPorSTATIC_IP.Name = "comboBox_DHCPorSTATIC_IP";
            this.comboBox_DHCPorSTATIC_IP.Size = new System.Drawing.Size(184, 21);
            this.comboBox_DHCPorSTATIC_IP.TabIndex = 6;
            this.comboBox_DHCPorSTATIC_IP.SelectedIndexChanged += new System.EventHandler(this.comboBox_DHCPorSTATIC_IP_SelectedIndexChanged);
            // 
            // tabMySQL
            // 
            this.tabMySQL.Controls.Add(this.groupBoxMySQLConfig);
            this.tabMySQL.Location = new System.Drawing.Point(4, 22);
            this.tabMySQL.Name = "tabMySQL";
            this.tabMySQL.Size = new System.Drawing.Size(623, 511);
            this.tabMySQL.TabIndex = 3;
            this.tabMySQL.Text = "Mysql";
            this.tabMySQL.UseVisualStyleBackColor = true;
            // 
            // groupBoxMySQLConfig
            // 
            this.groupBoxMySQLConfig.Controls.Add(this.panel_MySqlServerSettingsInputs);
            this.groupBoxMySQLConfig.Controls.Add(this.checkBox_DisableMySQL);
            this.groupBoxMySQLConfig.Location = new System.Drawing.Point(12, 15);
            this.groupBoxMySQLConfig.Name = "groupBoxMySQLConfig";
            this.groupBoxMySQLConfig.Size = new System.Drawing.Size(469, 369);
            this.groupBoxMySQLConfig.TabIndex = 1;
            this.groupBoxMySQLConfig.TabStop = false;
            this.groupBoxMySQLConfig.Text = "MySql configuration:";
            // 
            // panel_MySqlServerSettingsInputs
            // 
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.checkBox_MySqlTableNameUseDeviceName);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.txtMySqlServerTableName);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.label17);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.txtMySqlServerDatabaseName);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.label16);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.txtMySqlServerPassword);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.label15);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.txtMySqlServerUsername);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.label14);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.txtMySqlServerIP);
            this.panel_MySqlServerSettingsInputs.Controls.Add(this.label13);
            this.panel_MySqlServerSettingsInputs.Location = new System.Drawing.Point(23, 55);
            this.panel_MySqlServerSettingsInputs.Name = "panel_MySqlServerSettingsInputs";
            this.panel_MySqlServerSettingsInputs.Size = new System.Drawing.Size(440, 189);
            this.panel_MySqlServerSettingsInputs.TabIndex = 2;
            // 
            // checkBox_MySqlTableNameUseDeviceName
            // 
            this.checkBox_MySqlTableNameUseDeviceName.AutoSize = true;
            this.checkBox_MySqlTableNameUseDeviceName.Location = new System.Drawing.Point(16, 133);
            this.checkBox_MySqlTableNameUseDeviceName.Name = "checkBox_MySqlTableNameUseDeviceName";
            this.checkBox_MySqlTableNameUseDeviceName.Size = new System.Drawing.Size(256, 17);
            this.checkBox_MySqlTableNameUseDeviceName.TabIndex = 10;
            this.checkBox_MySqlTableNameUseDeviceName.Text = "Use Device name as table name (Recomended!)";
            this.checkBox_MySqlTableNameUseDeviceName.UseVisualStyleBackColor = true;
            this.checkBox_MySqlTableNameUseDeviceName.CheckedChanged += new System.EventHandler(this.checkBox_MySqlTableNameUseDeviceName_CheckedChanged);
            // 
            // txtMySqlServerTableName
            // 
            this.txtMySqlServerTableName.Location = new System.Drawing.Point(140, 150);
            this.txtMySqlServerTableName.Name = "txtMySqlServerTableName";
            this.txtMySqlServerTableName.Size = new System.Drawing.Size(177, 20);
            this.txtMySqlServerTableName.TabIndex = 9;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 153);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(100, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "MySQL table name:";
            // 
            // txtMySqlServerDatabaseName
            // 
            this.txtMySqlServerDatabaseName.Location = new System.Drawing.Point(141, 93);
            this.txtMySqlServerDatabaseName.Name = "txtMySqlServerDatabaseName";
            this.txtMySqlServerDatabaseName.Size = new System.Drawing.Size(177, 20);
            this.txtMySqlServerDatabaseName.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(121, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "MySQL database name:";
            // 
            // txtMySqlServerPassword
            // 
            this.txtMySqlServerPassword.Location = new System.Drawing.Point(113, 67);
            this.txtMySqlServerPassword.Name = "txtMySqlServerPassword";
            this.txtMySqlServerPassword.Size = new System.Drawing.Size(205, 20);
            this.txtMySqlServerPassword.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "MySQL password:";
            // 
            // txtMySqlServerUsername
            // 
            this.txtMySqlServerUsername.Location = new System.Drawing.Point(113, 41);
            this.txtMySqlServerUsername.Name = "txtMySqlServerUsername";
            this.txtMySqlServerUsername.Size = new System.Drawing.Size(205, 20);
            this.txtMySqlServerUsername.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "MySQL username:";
            // 
            // txtMySqlServerIP
            // 
            this.txtMySqlServerIP.Location = new System.Drawing.Point(73, 10);
            this.txtMySqlServerIP.Name = "txtMySqlServerIP";
            this.txtMySqlServerIP.Size = new System.Drawing.Size(245, 20);
            this.txtMySqlServerIP.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Server IP:";
            // 
            // checkBox_DisableMySQL
            // 
            this.checkBox_DisableMySQL.AutoSize = true;
            this.checkBox_DisableMySQL.Location = new System.Drawing.Point(23, 32);
            this.checkBox_DisableMySQL.Name = "checkBox_DisableMySQL";
            this.checkBox_DisableMySQL.Size = new System.Drawing.Size(134, 17);
            this.checkBox_DisableMySQL.TabIndex = 1;
            this.checkBox_DisableMySQL.Text = "Disable MySQL usage.";
            this.checkBox_DisableMySQL.UseVisualStyleBackColor = true;
            this.checkBox_DisableMySQL.CheckedChanged += new System.EventHandler(this.checkBox_DisableMySQL_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 270);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "Minimum allowed temperature:";
            // 
            // txtTempRangeMin
            // 
            this.txtTempRangeMin.Location = new System.Drawing.Point(169, 267);
            this.txtTempRangeMin.Name = "txtTempRangeMin";
            this.txtTempRangeMin.Size = new System.Drawing.Size(174, 20);
            this.txtTempRangeMin.TabIndex = 9;
            // 
            // txtTempRangeMax
            // 
            this.txtTempRangeMax.Location = new System.Drawing.Point(169, 295);
            this.txtTempRangeMax.Name = "txtTempRangeMax";
            this.txtTempRangeMax.Size = new System.Drawing.Size(174, 20);
            this.txtTempRangeMax.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 298);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(152, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Maximum allowed temperature:";
            // 
            // tabEmail
            // 
            this.tabEmail.Controls.Add(this.label20);
            this.tabEmail.Controls.Add(this.txtNewEmailAdress);
            this.tabEmail.Controls.Add(this.btnDeleteSelectedEmailAdress);
            this.tabEmail.Controls.Add(this.btnSaveNewEmailAdress);
            this.tabEmail.Controls.Add(this.listBox_EmailAdresses);
            this.tabEmail.Location = new System.Drawing.Point(4, 22);
            this.tabEmail.Name = "tabEmail";
            this.tabEmail.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmail.Size = new System.Drawing.Size(623, 511);
            this.tabEmail.TabIndex = 4;
            this.tabEmail.Text = "Mail adresses";
            this.tabEmail.UseVisualStyleBackColor = true;
            // 
            // listBox_EmailAdresses
            // 
            this.listBox_EmailAdresses.FormattingEnabled = true;
            this.listBox_EmailAdresses.Location = new System.Drawing.Point(17, 16);
            this.listBox_EmailAdresses.Name = "listBox_EmailAdresses";
            this.listBox_EmailAdresses.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_EmailAdresses.Size = new System.Drawing.Size(585, 316);
            this.listBox_EmailAdresses.TabIndex = 0;
            this.listBox_EmailAdresses.SelectedIndexChanged += new System.EventHandler(this.listBox_EmailAdresses_SelectedIndexChanged);
            // 
            // btnSaveNewEmailAdress
            // 
            this.btnSaveNewEmailAdress.Enabled = false;
            this.btnSaveNewEmailAdress.Location = new System.Drawing.Point(446, 338);
            this.btnSaveNewEmailAdress.Name = "btnSaveNewEmailAdress";
            this.btnSaveNewEmailAdress.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNewEmailAdress.TabIndex = 1;
            this.btnSaveNewEmailAdress.Text = "Save";
            this.btnSaveNewEmailAdress.UseVisualStyleBackColor = true;
            this.btnSaveNewEmailAdress.Click += new System.EventHandler(this.btnSaveNewEmailAdress_Click);
            // 
            // btnDeleteSelectedEmailAdress
            // 
            this.btnDeleteSelectedEmailAdress.Enabled = false;
            this.btnDeleteSelectedEmailAdress.Location = new System.Drawing.Point(527, 338);
            this.btnDeleteSelectedEmailAdress.Name = "btnDeleteSelectedEmailAdress";
            this.btnDeleteSelectedEmailAdress.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSelectedEmailAdress.TabIndex = 2;
            this.btnDeleteSelectedEmailAdress.Text = "Delete selected";
            this.btnDeleteSelectedEmailAdress.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedEmailAdress.Click += new System.EventHandler(this.btnDeleteSelectedEmailAdress_Click);
            // 
            // txtNewEmailAdress
            // 
            this.txtNewEmailAdress.Location = new System.Drawing.Point(133, 338);
            this.txtNewEmailAdress.Name = "txtNewEmailAdress";
            this.txtNewEmailAdress.Size = new System.Drawing.Size(307, 20);
            this.txtNewEmailAdress.TabIndex = 3;
            this.txtNewEmailAdress.TextChanged += new System.EventHandler(this.txtNewEmailAdress_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 341);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(113, 13);
            this.label20.TabIndex = 4;
            this.label20.Text = "Add new email adress:";
            // 
            // configManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 537);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Name = "configManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "configManagerForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabUsers.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabNetworking.ResumeLayout(false);
            this.groupBoxSetNetworkingSettings.ResumeLayout(false);
            this.groupBoxSetNetworkingSettings.PerformLayout();
            this.panel_NetworkSettingsInputs.ResumeLayout(false);
            this.panel_NetworkSettingsInputs.PerformLayout();
            this.tabMySQL.ResumeLayout(false);
            this.groupBoxMySQLConfig.ResumeLayout(false);
            this.groupBoxMySQLConfig.PerformLayout();
            this.panel_MySqlServerSettingsInputs.ResumeLayout(false);
            this.panel_MySqlServerSettingsInputs.PerformLayout();
            this.tabEmail.ResumeLayout(false);
            this.tabEmail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_DeviceInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMeasurmentInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSetNewPassword2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSetNewPassword1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TabPage tabNetworking;
        private System.Windows.Forms.GroupBox groupBoxSetNetworkingSettings;
        private System.Windows.Forms.TextBox txtIPAdress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGateWay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNetMask;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_DHCPorSTATIC_IP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel_NetworkSettingsInputs;
        private System.Windows.Forms.CheckBox checkBox_NetworkSettingsRebootDevice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabMySQL;
        private System.Windows.Forms.GroupBox groupBoxMySQLConfig;
        private System.Windows.Forms.Panel panel_MySqlServerSettingsInputs;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox_DisableMySQL;
        private System.Windows.Forms.TextBox txtMySqlServerIP;
        private System.Windows.Forms.TextBox txtMySqlServerUsername;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMySqlServerPassword;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMySqlServerDatabaseName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMySqlServerTableName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox checkBox_MySqlTableNameUseDeviceName;
        private System.Windows.Forms.TextBox txtTempRangeMax;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTempRangeMin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabEmail;
        private System.Windows.Forms.ListBox listBox_EmailAdresses;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtNewEmailAdress;
        private System.Windows.Forms.Button btnDeleteSelectedEmailAdress;
        private System.Windows.Forms.Button btnSaveNewEmailAdress;
    }
}