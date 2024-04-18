using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lan_Messenger
{
    public partial class FormChangeDisplayName : Form
    {
        public FormChangeDisplayName()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện khi người dùng nhấn nút "Thay đổi"
        private void btnChange_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã nhập tên hiển thị mới hay chưa
            if (txtName.Text == "")
                MessageBox.Show("Tên hiển thị không được rỗng, vui lòng chọn tên hiển thị khác", "Lỗi!");
            else
            {
                // Gọi phương thức ChangeDisplayName từ đối tượng server Global để thay đổi tên hiển thị của người dùng
                Global.server.ChangeDisplayName(Global.username, txtName.Text);
                MessageBox.Show("Tên hiển thị của bạn đã được thay đổi thành công. Vui lòng đăng nhập trở lại để thấy sự thay đổi");
                this.Close(); // Đóng form sau khi thay đổi thành công
            }
        }

        // Xử lý sự kiện khi người dùng nhấn nút "Hủy"
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }

        // Xử lý sự kiện khi form được tải lên
        private void FormChangeDisplayName_Load(object sender, EventArgs e)
        {
            lblusername.Text += Global.username; // Hiển thị tên người dùng hiện tại trên label
        }

        // Xử lý sự kiện khi người dùng nhấp chuột vào label chứa tên người dùng
        private void lblusername_Click(object sender, EventArgs e)
        {
            
        }
    }
}
