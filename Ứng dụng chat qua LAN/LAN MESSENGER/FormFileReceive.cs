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
using System.Diagnostics; // Dùng để mở thư mục
using System.Threading;

namespace Lan_Messenger
{    
    public partial class FormFileReceive : Form
    {
        Thread t1;
        int flag = 0;
        string receivedPath;
        public delegate void UpdateStatusDelegate(string newStatus);// Sử dụng Delegate để update lại satatus mà ko bị xung đột Thread
        private string[] setting = new string[5]; // Có 5 Options tất cả
        public FormFileReceive()
        {
            InitializeComponent();
            // Đọc file Usersetting.dat nếu có để lấy đường dẫn lưu file
            if (File.Exists("UserSetting.dat"))
                ReadUserSetting();
            // Truyền địa chỉ IP cho FormMessage biết
            t1 = new Thread(new ThreadStart(StartListening)); // khởi tạo luồng
            t1.Start();
            if (Directory.Exists(setting[4]))
                receivedPath = setting[4];
            else
                receivedPath = Path.GetFullPath("files");
            lblPath.Text = receivedPath;
        }

        public void ReadUserSetting()
        {
            FileStream fs1 = new FileStream("UserSetting.dat", FileMode.Open);
            BinaryReader w1 = new BinaryReader(fs1);
            setting[0] = w1.ReadString().ToString(); // Link tiếng buzz
            setting[1] = w1.ReadString().ToString(); // Link tiếng Online
            setting[2] = w1.ReadString().ToString(); // Link tiếng Offline
            setting[3] = w1.ReadString().ToString(); // Link tiếng Message
            setting[4] = w1.ReadString().ToString(); // Link thư mục lưu file
            w1.Close();
            fs1.Close();
        }
        public class StateObject
        {
            // Client socket.
            public Socket workSocket = null;

            public const int BufferSize = 1024;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
        }
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public void StartListening()
        {
            byte[] bytes = new Byte[1024];
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, 6565);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true); // tái sử dụng socket
                listener.Bind(ipEnd);
                listener.Listen(100);
                while (true)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                    UpdateStatus("Đã nhận file thành công!");
                }
            }
            catch (Exception ex)
            {
                UpdateStatus(ex.Message);
            }
        }
        public void AcceptCallback(IAsyncResult ar)
        {

            allDone.Set();
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
            flag = 0;
        }
        public string FileName;
        public void ReadCallback(IAsyncResult ar)
        {
            
            int fileNameLen = 1;
            receivedPath = receivedPath + "\\";
            String content = String.Empty;
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {
                if (flag == 0)
                {
                    fileNameLen = BitConverter.ToInt32(state.buffer, 0);
                    string fileName = Encoding.UTF8.GetString(state.buffer, 4, fileNameLen);
                    FileName = fileName;
                    UpdateStatus("Đang nhận File...");
                    flag++;
                }
                if (flag >= 1)
                {
                    BinaryWriter writer = new BinaryWriter(File.Open(receivedPath+FileName, FileMode.Append));
                    if (flag == 1)
                    {
                        writer.Write(state.buffer, 4 + fileNameLen, bytesRead - (4 + fileNameLen));
                        flag++;
                    }
                    else
                        writer.Write(state.buffer, 0, bytesRead);
                    writer.Close();
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }     
            }
            else
            {
                UpdateStatus("Đã nhận File thành công!");
            }        
        }

        private void UpdateStatus(string newStatus)
        {
            if (lblStatus.InvokeRequired)
            {
                try
                {
                    UpdateStatusDelegate del = new UpdateStatusDelegate(UpdateStatus);
                    lblStatus.Invoke(del, new object[] { newStatus });
                }
                catch (Exception ex)
                {
                    lblStatus.Text = ex.ToString();
                }
            }
            else
            {
                lblStatus.Text = newStatus;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text != "Đã nhận File thành công!")
                MessageBox.Show("Vui lòng chờ cho đến khi quá trình truyền tải file thành công");
            else
            {
                this.Hide();
            }             
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            // Mở folder đã nhận file
            Process ps = new Process();
           
            ps.StartInfo.FileName = Path.GetFullPath(receivedPath);
            ps.Start();
            ps.Close();
        }

        private void FormFileReceive_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    } 
}
