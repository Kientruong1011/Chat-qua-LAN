using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using LanMessengerLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Threading;
using System.Net;

namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for FormSignIn.
	/// </summary>
	public class FormSignIn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCreateAccount;
		internal System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnSignIn;
		private System.Windows.Forms.Button btnCancel;
		private System.ComponentModel.IContainer components;
        private System.Windows.Forms.CheckBox chkInvisible;
		private System.Windows.Forms.Button btnChangePassword;

		public FormSignIn()
		{
			//
			// Required for Windows Form Designer support
			//            
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSignIn));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkInvisible = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateAccount);
            this.groupBox1.Location = new System.Drawing.Point(10, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bạn chưa có tài khoản?";
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCreateAccount.Location = new System.Drawing.Point(80, 18);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(144, 28);
            this.btnCreateAccount.TabIndex = 0;
            this.btnCreateAccount.Text = "Tạo tài khoản mới";
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkInvisible);
            this.groupBox2.Controls.Add(this.txtPassword);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(10, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 129);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bạn đã có tài khoản rồi?";
            // 
            // chkInvisible
            // 
            this.chkInvisible.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkInvisible.Location = new System.Drawing.Point(86, 102);
            this.chkInvisible.Name = "chkInvisible";
            this.chkInvisible.Size = new System.Drawing.Size(135, 18);
            this.chkInvisible.TabIndex = 3;
            this.chkInvisible.Text = "Đăng nhập ẩn";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(106, 65);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(192, 22);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUsername.Location = new System.Drawing.Point(107, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(192, 22);
            this.txtUsername.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(35, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên tài khoản :";
            // 
            // btnSignIn
            // 
            this.btnSignIn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSignIn.Location = new System.Drawing.Point(10, 212);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(85, 28);
            this.btnSignIn.TabIndex = 0;
            this.btnSignIn.Text = "Đăng Nhập";
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(102, 212);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Hủy";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChangePassword.Location = new System.Drawing.Point(191, 212);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(134, 28);
            this.btnChangePassword.TabIndex = 3;
            this.btnChangePassword.Text = "Thay đổi mật khẩu";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // FormSignIn
            // 
            this.AcceptButton = this.btnSignIn;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(362, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnChangePassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSignIn";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng nhập";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormSignIn_Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnCreateAccount_Click(object sender, System.EventArgs e)
		{
			FormCreateAccount frmCreateAccount = new FormCreateAccount();
			if(frmCreateAccount.ShowDialog()==DialogResult.OK)
			{
				txtUsername.Text=frmCreateAccount.txtUsername.Text;
				txtPassword.Text=frmCreateAccount.txtPassword.Text;
			}
		}
		private void btnSignIn_Click(object sender, System.EventArgs e)
		{            
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                try
                {
                    if (Global.server.SignIn(txtUsername.Text, txtPassword.Text, !chkInvisible.Checked))
                    {
                        // Ghi địa chỉ IP của user đăng nhập
                        IPHostEntry temp = Dns.GetHostByName(Dns.GetHostName().ToString());
                        string IP = temp.AddressList[0].ToString();
                        Global.server.SetIP(txtUsername.Text, IP);
                    }
                    else
                    {
                        MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng. Vui lòng kiểm tra lại!","Lỗi đăng nhập...");
                        this.DialogResult = DialogResult.None;
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối tới Server. Vui lòng kiểm tra kết nối và thử lại!", "Lỗi kết nối...");
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                MessageBox.Show("Lỗi! Vui lòng nhập tên tài khoản và mật khẩu!", "Lỗi đăng nhập...");
                this.DialogResult = DialogResult.None;
            }
		}

		private void FormSignIn_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.None)
			{
				e.Cancel=true;
			}
		}

		private void btnChangePassword_Click(object sender, System.EventArgs e)
		{
			FormChangePassword frmChangePassword = new FormChangePassword();
			frmChangePassword.txtUsername.Text=txtUsername.Text;
			frmChangePassword.txtCurPassword.Text=txtPassword.Text;
			if(frmChangePassword.ShowDialog()==DialogResult.OK)
			{
				txtUsername.Text=frmChangePassword.txtUsername.Text;
				txtPassword.Text=frmChangePassword.txtNewPassword.Text;
			}
		}        
	}
}
