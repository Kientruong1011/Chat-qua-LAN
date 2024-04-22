namespace Lan_Messenger
{
    partial class FormLogsReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogsReader));
            this.lbListContact = new System.Windows.Forms.ListBox();
            this.lvListMessage = new System.Windows.Forms.ListView();
            this.rtbLogMessage = new System.Windows.Forms.RichTextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbListContact
            // 
            this.lbListContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbListContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbListContact.ForeColor = System.Drawing.Color.Purple;
            this.lbListContact.FormattingEnabled = true;
            this.lbListContact.ItemHeight = 24;
            this.lbListContact.Location = new System.Drawing.Point(0, 0);
            this.lbListContact.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbListContact.Name = "lbListContact";
            this.lbListContact.Size = new System.Drawing.Size(161, 388);
            this.lbListContact.TabIndex = 0;
            this.lbListContact.SelectedValueChanged += new System.EventHandler(this.lbListContact_SelectedValueChanged);
            // 
            // lvListMessage
            // 
            this.lvListMessage.BackColor = System.Drawing.Color.White;
            this.lvListMessage.CausesValidation = false;
            this.lvListMessage.CheckBoxes = true;
            this.lvListMessage.FullRowSelect = true;
            this.lvListMessage.GridLines = true;
            this.lvListMessage.HideSelection = false;
            this.lvListMessage.Location = new System.Drawing.Point(161, 0);
            this.lvListMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvListMessage.Name = "lvListMessage";
            this.lvListMessage.Size = new System.Drawing.Size(512, 182);
            this.lvListMessage.TabIndex = 2;
            this.lvListMessage.UseCompatibleStateImageBehavior = false;
            this.lvListMessage.View = System.Windows.Forms.View.Details;
            this.lvListMessage.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvMessage_ItemChecked);
            this.lvListMessage.SelectedIndexChanged += new System.EventHandler(this.lvListMessage_SelectedIndexChanged);
            // 
            // rtbLogMessage
            // 
            this.rtbLogMessage.Location = new System.Drawing.Point(161, 206);
            this.rtbLogMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtbLogMessage.Name = "rtbLogMessage";
            this.rtbLogMessage.ReadOnly = true;
            this.rtbLogMessage.Size = new System.Drawing.Size(511, 197);
            this.rtbLogMessage.TabIndex = 3;
            this.rtbLogMessage.Text = "";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(324, 407);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(183, 28);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa logs chat được chọn";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(543, 407);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormLogsReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 446);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.rtbLogMessage);
            this.Controls.Add(this.lvListMessage);
            this.Controls.Add(this.lbListContact);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormLogsReader";
            this.Text = "Lịch sử chat";
            this.Load += new System.EventHandler(this.FormLogsReader_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbListContact;
        private System.Windows.Forms.ListView lvListMessage;
        private System.Windows.Forms.RichTextBox rtbLogMessage;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
    }
}