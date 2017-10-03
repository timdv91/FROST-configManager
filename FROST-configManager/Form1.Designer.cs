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
            this.SuspendLayout();
            // 
            // btnSendDiscoveryPing
            // 
            this.btnSendDiscoveryPing.Location = new System.Drawing.Point(13, 12);
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
            this.listBox_DevicesDiscoverd.Location = new System.Drawing.Point(13, 60);
            this.listBox_DevicesDiscoverd.Name = "listBox_DevicesDiscoverd";
            this.listBox_DevicesDiscoverd.Size = new System.Drawing.Size(585, 511);
            this.listBox_DevicesDiscoverd.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 660);
            this.Controls.Add(this.listBox_DevicesDiscoverd);
            this.Controls.Add(this.btnSendDiscoveryPing);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendDiscoveryPing;
        private System.Windows.Forms.ListBox listBox_DevicesDiscoverd;
    }
}

