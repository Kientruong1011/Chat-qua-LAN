namespace Lan_Messenger
{
    partial class FormFileReceive
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
            this.lblFileLocation = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFileLocation
            // 
            this.lblFileLocation.AutoSize = true;
            this.lblFileLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileLocation.ForeColor = System.Drawing.Color.Red;
            this.lblFileLocation.Location = new System.Drawing.Point(12, 23);
            this.lblFileLocation.Name = "lblFileLocation";
            this.lblFileLocation.Size = new System.Drawing.Size(100, 16);
            this.lblFileLocation.TabIndex = 0;
            this.lblFileLocation.Text = "Tệp được lưu ở:";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.ForeColor = System.Drawing.Color.Red;
            this.lblServerStatus.Location = new System.Drawing.Point(12, 50);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(71, 16);
            this.lblServerStatus.TabIndex = 1;
            this.lblServerStatus.Text = "Trạng thái:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(109, 53);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(152, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Đang chờ người dùng gửi file...";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.ForeColor = System.Drawing.Color.Green;
            this.lblPath.Location = new System.Drawing.Point(109, 26);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(16, 13);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "...";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(277, 103);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(131, 103);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(134, 23);
            this.btnOpenFolder.TabIndex = 5;
            this.btnOpenFolder.Text = "Mở folder nhận file";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
            // 
            // FormFileReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 138);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblFileLocation);
            this.Name = "FormFileReceive";
            this.Text = "Nhận file...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFileReceive_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileLocation;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}