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
            this.label1.Location = new System.Drawing.Point(99, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device information:";
            // 
            // richTextBox_DeviceInformation
            // 
            this.richTextBox_DeviceInformation.Location = new System.Drawing.Point(102, 22);
            this.richTextBox_DeviceInformation.Name = "richTextBox_DeviceInformation";
            this.richTextBox_DeviceInformation.ReadOnly = true;
            this.richTextBox_DeviceInformation.Size = new System.Drawing.Size(337, 160);
            this.richTextBox_DeviceInformation.TabIndex = 2;
            this.richTextBox_DeviceInformation.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Device name:";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(178, 197);
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
            this.txtMeasurmentInterval.Location = new System.Drawing.Point(265, 226);
            this.txtMeasurmentInterval.Name = "txtMeasurmentInterval";
            this.txtMeasurmentInterval.Size = new System.Drawing.Size(174, 20);
            this.txtMeasurmentInterval.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Measurement interval (seconds):";
            // 
            // configManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 289);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMeasurmentInterval);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox_DeviceInformation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Name = "configManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "configManagerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}