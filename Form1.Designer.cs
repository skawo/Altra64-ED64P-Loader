
namespace ED64PLoad
{
    partial class ED64PLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ED64PLoad));
            this.comboCOMPorts = new System.Windows.Forms.ComboBox();
            this.lblCOMPort = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusExp = new System.Windows.Forms.Label();
            this.btn_SendROM = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboCOMPorts
            // 
            this.comboCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCOMPorts.FormattingEnabled = true;
            this.comboCOMPorts.Location = new System.Drawing.Point(74, 17);
            this.comboCOMPorts.Name = "comboCOMPorts";
            this.comboCOMPorts.Size = new System.Drawing.Size(121, 21);
            this.comboCOMPorts.TabIndex = 0;
            this.comboCOMPorts.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblCOMPort
            // 
            this.lblCOMPort.AutoSize = true;
            this.lblCOMPort.Location = new System.Drawing.Point(12, 20);
            this.lblCOMPort.Name = "lblCOMPort";
            this.lblCOMPort.Size = new System.Drawing.Size(56, 13);
            this.lblCOMPort.TabIndex = 1;
            this.lblCOMPort.Text = "COM Port:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 52);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // lblStatusExp
            // 
            this.lblStatusExp.AutoSize = true;
            this.lblStatusExp.Location = new System.Drawing.Point(71, 52);
            this.lblStatusExp.Name = "lblStatusExp";
            this.lblStatusExp.Size = new System.Drawing.Size(33, 13);
            this.lblStatusExp.TabIndex = 3;
            this.lblStatusExp.Text = "None";
            // 
            // btn_SendROM
            // 
            this.btn_SendROM.Location = new System.Drawing.Point(12, 80);
            this.btn_SendROM.Name = "btn_SendROM";
            this.btn_SendROM.Size = new System.Drawing.Size(278, 43);
            this.btn_SendROM.TabIndex = 4;
            this.btn_SendROM.Text = "Send ROM";
            this.btn_SendROM.UseVisualStyleBackColor = true;
            this.btn_SendROM.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 129);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(278, 23);
            this.progressBar.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(201, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 21);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button2_Click);
            // 
            // ED64PLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 170);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btn_SendROM);
            this.Controls.Add(this.lblStatusExp);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCOMPort);
            this.Controls.Add(this.comboCOMPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ED64PLoad";
            this.Text = "ED64PLoad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.ED64PLoad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboCOMPorts;
        private System.Windows.Forms.Label lblCOMPort;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusExp;
        private System.Windows.Forms.Button btn_SendROM;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnRefresh;
    }
}

