using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for FormAddContact.
	/// </summary>
	public class FormAddContact : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtContact;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAddContact()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddContact));
            this.label1 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên :";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(86, 18);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(250, 22);
            this.txtContact.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(115, 55);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(230, 55);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy";
            // 
            // FormAddContact
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(440, 99);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddContact";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm bạn bè";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormAddContact_Closing);
            this.Load += new System.EventHandler(this.FormAddContact_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if(Global.username==txtContact.Text)
			{
				MessageBox.Show("Bạn không thể thêm chính bạn vào danh sách được!");
				txtContact.Text="";
				this.DialogResult=DialogResult.None;
				return;
			}
			if(Global.server.AddContact(Global.username,txtContact.Text))
			{
				return;
			}
			else
			{
                
                // Global.server.GetContacts(Global.username) lấy mảng danh sách các Contact của người dùng hiện tại
                bool check = false; // Biến cờ để xác định sự tồn tại của User                
                foreach (object o in Global.server.GetContacts(Global.username))
                    if (o.ToString() == txtContact.Text) 
                    {
                        check = true;                        
                        break;
                    }
                if (check) MessageBox.Show("Người dùng này đã có trong danh sách bạn bè của bạn");
                else
                    MessageBox.Show("Người dùng này không tồn tại trong cơ sở dữ liệu!");
				this.DialogResult=DialogResult.None;
			}
		}

		private void FormAddContact_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(this.DialogResult==DialogResult.None)
				e.Cancel=true;
		}

        private void FormAddContact_Load(object sender, EventArgs e)
        {

        }
    }
}
