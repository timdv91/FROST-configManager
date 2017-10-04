namespace FROST_configManager
{
    partial class Form1
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
            this.btnSendDiscoveryPing = new System.Windows.Forms.Button();
            this.listBox_DevicesDiscoverd = new System.Windows.Forms.ListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtManualConnectionIP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendDiscoveryPing
            // 
            this.btnSendDiscoveryPing.Location = new System.Drawing.Point(6, 19);
            this.btnSendDiscoveryPing.Name = "btnSendDiscoveryPing";
            this.btnSendDiscoveryPing.Size = new System.Drawing.Size(191, 41);
            this.btnSendDiscoveryPing.TabIndex = 0;
            this.btnSendDiscoveryPing.Text = "Discover devices";
            this.btnSendDiscoveryPing.UseVisualStyleBackColor = true;
            this.btnSendDiscoveryPing.Click += new System.EventHandler(this.btnSendDiscoveryPing_Click);
            // 
            // listBox_DevicesDiscoverd
            // 
            this.listBox_DevicesDiscoverd.FormattingEnabled = true;
            this.listBox_DevicesDiscoverd.Location = new System.Drawing.Point(9, 66);
            this.listBox_DevicesDiscoverd.Name = "listBox_DevicesDiscoverd";
            this.listBox_DevicesDiscoverd.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_DevicesDiscoverd.Size = new System.Drawing.Size(385, 277);
            this.listBox_DevicesDiscoverd.TabIndex = 1;
            this.listBox_DevicesDiscoverd.SelectedIndexChanged += new System.EventHandler(this.listBox_DevicesDiscoverd_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(203, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(191, 41);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manual connection using IP adress:";
            // 
            // txtManualConnectionIP
            // 
            this.txtManualConnectionIP.Location = new System.Drawing.Point(9, 45);
            this.txtManualConnectionIP.Name = "txtManualConnectionIP";
            this.txtManualConnectionIP.Size = new System.Drawing.Size(385, 20);
            this.txtManualConnectionIP.TabIndex = 4;
            this.txtManualConnectionIP.TextChanged += new System.EventHandler(this.txtManualConnectionIP_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSendDiscoveryPing);
            this.groupBox1.Controls.Add(this.listBox_DevicesDiscoverd);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 353);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto discovery:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtManualConnectionIP);
            this.groupBox2.Location = new System.Drawing.Point(13, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 82);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual connection (Advanced users only!):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 460);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "FROST-Configurator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendDiscoveryPing;
        private System.Windows.Forms.ListBox listBox_DevicesDiscoverd;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtManualConnectionIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

