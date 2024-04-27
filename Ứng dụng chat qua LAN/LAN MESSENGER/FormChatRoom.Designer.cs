namespace Lan_Messenger
{
    partial class FormChatRoom
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChatRoom));
            this.txtAllChat = new System.Windows.Forms.RichTextBox();
            this.lstOnlineUser = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtChatHere = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbbListContact = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAllChat
            // 
            this.txtAllChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAllChat.Location = new System.Drawing.Point(0, 0);
            this.txtAllChat.Name = "txtAllChat";
            this.txtAllChat.ReadOnly = true;
            this.txtAllChat.Size = new System.Drawing.Size(478, 329);
            this.txtAllChat.TabIndex = 3;
            this.txtAllChat.Text = "";
            // 
            // lstOnlineUser
            // 
            this.lstOnlineUser.FormattingEnabled = true;
            this.lstOnlineUser.Location = new System.Drawing.Point(484, 30);
            this.lstOnlineUser.Name = "lstOnlineUser";
            this.lstOnlineUser.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstOnlineUser.Size = new System.Drawing.Size(125, 238);
            this.lstOnlineUser.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(509, 345);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 36);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Gửi";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtChatHere
            // 
            this.txtChatHere.Location = new System.Drawing.Point(0, 345);
            this.txtChatHere.Multiline = true;
            this.txtChatHere.Name = "txtChatHere";
            this.txtChatHere.Size = new System.Drawing.Size(478, 36);
            this.txtChatHere.TabIndex = 0;
            this.txtChatHere.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChatHere_KeyDown);
            this.txtChatHere.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtChatHere_KeyUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(483, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nick trong Room";
            // 
            // cbbListContact
            // 
            this.cbbListContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbListContact.FormattingEnabled = true;
            this.cbbListContact.Location = new System.Drawing.Point(488, 308);
            this.cbbListContact.Name = "cbbListContact";
            this.cbbListContact.Size = new System.Drawing.Size(121, 21);
            this.cbbListContact.TabIndex = 5;
            this.cbbListContact.SelectedIndexChanged += new System.EventHandler(this.cbbListContact_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(495, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mời thêm bạn";
            // 
            // FormChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 393);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbListContact);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChatHere);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lstOnlineUser);
            this.Controls.Add(this.txtAllChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChatRoom";
            this.Text = "LAN Messenger - Room Chat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChatRoom_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtAllChat;
        private System.Windows.Forms.ListBox lstOnlineUser;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtChatHere;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbListContact;
        private System.Windows.Forms.Label label2;
    }
}