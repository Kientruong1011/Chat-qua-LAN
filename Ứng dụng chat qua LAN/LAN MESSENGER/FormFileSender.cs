using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Lan_Messenger
{
    public partial class FormFileSender : Form
    {
        public static string IP; // IP của server nhận file
        string splitter = "'\\'";
        string fName;
        string[] split = null;
        byte[] clientData;
        public FormFileSender()
        {
            InitializeComponent();
        }
        FormMessage f;
        public FormFileSender(FormMessage form)
        {
            InitializeComponent();
            f = new FormMessage();
            f = form;
        }

        private void FormFileSender_Load(object sender, EventArgs e)
        {
            IP = f.IPContact;            
        }
        
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            char[] delimiter = splitter.ToCharArray();
            openFileDialog1.ShowDialog();
            txtFileLink.Text = openFileDialog1.FileName;
            split = txtFileLink.Text.Split(delimiter);
            int limit = split.Length;
            fName = split[limit - 1].ToString();
            if (txtFileLink.Text != null)
                btnSend.Enabled = true;
        }      
        private void btnSend_Click(object sender, EventArgs e)
        {
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            byte[] fileName = Encoding.UTF8.GetBytes(fName); // tên file
            byte[] fileData = File.ReadAllBytes(txtFileLink.Text); // dữ liệu
            byte[] fileNameLen = BitConverter.GetBytes(fileName.Length); // độ dài tên file
            clientData = new byte[4 + fileName.Length + fileData.Length];
            fileNameLen.CopyTo(clientData, 0);
            fileName.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileName.Length);
            lblStatus.Text = "Đang kết nối tới người nhận...";
            clientSock.Connect(IP, 6565); // IP máy đích
            lblStatus.Text = "Đang truyền tải dữ liệu. Làm ơn đợi...";
            clientSock.Send(clientData);
            clientSock.Close();
            lblStatus.Text = "Đã gửi thành công file: " + Path.GetFileName(txtFileLink.Text);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }    
}
