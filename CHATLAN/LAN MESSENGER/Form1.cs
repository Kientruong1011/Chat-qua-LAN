using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using LanMessengerLib;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.IO;
using System.Threading;
using System.Runtime.Remoting.Channels.Tcp;
using LanMessengerChatRoomBase;
using System.Net;

namespace Lan_Messenger
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	///
	public class Form1 : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuSendMessage;
		private System.Windows.Forms.MenuItem menuAddContact;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.Timer tmrMessageReceive;
		private System.Windows.Forms.Panel pnlContacts;
		private System.Windows.Forms.MenuItem menuChangeUser;
		private System.Windows.Forms.MenuItem menuSignOut;
		private System.Windows.Forms.MenuItem menuMin;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.Timer tmrContactUpdate;
		private System.Windows.Forms.MenuItem menuRemoveContact;
		private System.Windows.Forms.MenuItem menuNetworkSettings;
		private System.Windows.Forms.StatusBar statusBar;

		HttpChannel channel;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem conMenuSendMessage;
		private System.Windows.Forms.MenuItem conMenuAddContact;
		private System.Windows.Forms.ContextMenu conMenu;
		private System.Windows.Forms.ContextMenu conMenuContactsPanel;
		private System.Windows.Forms.MenuItem conMenuRefreshContactsPanel;
		private System.Windows.Forms.MenuItem conMenuRemoveContact;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem conMenuPanelRemoveContact;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.MenuItem menuChat;
		private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.ContextMenu notifyMenu;
        private System.Windows.Forms.MenuItem showLanMessenger;
		private System.Windows.Forms.MenuItem notMenuSend;
		private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem notMenuSignOut;
		private System.Windows.Forms.MenuItem notMenuSignIn;
		private System.Windows.Forms.MenuItem notMenuMin;
		private System.Windows.Forms.MenuItem notMenuExit;
		private System.Windows.Forms.MenuItem notMenuAbout;
		private System.Windows.Forms.MenuItem conMenuPanelAddContact;
        private Label lblWelcome;
        string hostIP;
        private TextBox txtSearchName;
        private ToolTip toolTip1;
        private PictureBox picSearch;
        private RadioButton rbtnOnline;
        private RadioButton rbtnInvisible;
        private ToolTip toolTip2;
        private MenuItem menuLogMessage;
        private MenuItem menuItem1;
        private MenuItem menuChangeDisplayName;
        private MenuItem menuOpenChatRoom;
        private MenuItem menuJoinRoom;
        private string[] setting = new string[6]; // Có 6 Options tất cả
		public Form1()
		{
            Application.EnableVisualStyles();
			InitializeComponent();            
			//
			// Các Constructor tại đây
			//

            // Đọc Usersetting.dat nếu tồn tại (ở đây người dùng phải SignOut thì mới cập nhật Sounds được)
            if (File.Exists("UserSetting.dat"))
                ReadUserSetting();
            else
                setting[5] = "1";

            // Thiết lập mạng
			channel = new HttpChannel();
			ChannelServices.RegisterChannel(channel);			
			
			statusBar.Text="Đang tải thiết lập mạng...";
			if(File.Exists("NetSetting.Dat"))
			{
				FileStream fs = new FileStream("NetSetting.Dat",FileMode.Open);
				BinaryReader br = new BinaryReader(fs);
				hostIP=br.ReadString();
				fs.Close();
				br.Close();
			}
			else
			{
				hostIP="127.0.0.1";
			}
			statusBar.Text="Đã tải thiết lập mạng.";
			try
			{
				MarshalByRefObject obj = (MarshalByRefObject)RemotingServices.Connect(typeof(IServer),"http://"+hostIP+":9090/Server");
				Global.server=obj as IServer;
				(obj as RemotingClientProxy).Timeout=5000;
			}
			catch
			{				
				return;
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{	
			this.Show();
			SignIn();            
		}
        // Khi Double lên 1 Contact thì mở cửa sổ chat với tên của người này.
		private void Contact_Click(object sender, System.EventArgs e)
		{
			OpenFormMessage(((LanMessengerControls.LanMessengerContact)sender).Contact);
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuChat = new System.Windows.Forms.MenuItem();
            this.menuSendMessage = new System.Windows.Forms.MenuItem();
            this.menuAddContact = new System.Windows.Forms.MenuItem();
            this.menuRemoveContact = new System.Windows.Forms.MenuItem();
            this.menuLogMessage = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuChangeUser = new System.Windows.Forms.MenuItem();
            this.menuSignOut = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuMin = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuNetworkSettings = new System.Windows.Forms.MenuItem();
            this.menuChangeDisplayName = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuOpenChatRoom = new System.Windows.Forms.MenuItem();
            this.menuJoinRoom = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.tmrMessageReceive = new System.Windows.Forms.Timer(this.components);
            this.pnlContacts = new System.Windows.Forms.Panel();
            this.tmrContactUpdate = new System.Windows.Forms.Timer(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.conMenu = new System.Windows.Forms.ContextMenu();
            this.conMenuSendMessage = new System.Windows.Forms.MenuItem();
            this.conMenuRemoveContact = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.conMenuAddContact = new System.Windows.Forms.MenuItem();
            this.conMenuContactsPanel = new System.Windows.Forms.ContextMenu();
            this.conMenuPanelAddContact = new System.Windows.Forms.MenuItem();
            this.conMenuPanelRemoveContact = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.conMenuRefreshContactsPanel = new System.Windows.Forms.MenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenu();
            this.showLanMessenger = new System.Windows.Forms.MenuItem();
            this.notMenuSend = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.notMenuSignIn = new System.Windows.Forms.MenuItem();
            this.notMenuSignOut = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.notMenuAbout = new System.Windows.Forms.MenuItem();
            this.notMenuMin = new System.Windows.Forms.MenuItem();
            this.notMenuExit = new System.Windows.Forms.MenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.rbtnOnline = new System.Windows.Forms.RadioButton();
            this.rbtnInvisible = new System.Windows.Forms.RadioButton();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChat,
            this.menuItem10,
            this.menuItem13});
            // 
            // menuChat
            // 
            this.menuChat.Index = 0;
            this.menuChat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSendMessage,
            this.menuAddContact,
            this.menuRemoveContact,
            this.menuLogMessage,
            this.menuItem4,
            this.menuChangeUser,
            this.menuSignOut,
            this.menuItem7,
            this.menuMin,
            this.menuExit});
            this.menuChat.Text = "Messenger";
            // 
            // menuSendMessage
            // 
            this.menuSendMessage.Enabled = false;
            this.menuSendMessage.Index = 0;
            this.menuSendMessage.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
            this.menuSendMessage.Text = "Gửi một tin nhắn...";
            this.menuSendMessage.Click += new System.EventHandler(this.menuSendMessage_Click);
            // 
            // menuAddContact
            // 
            this.menuAddContact.Enabled = false;
            this.menuAddContact.Index = 1;
            this.menuAddContact.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
            this.menuAddContact.Text = "Thêm bạn bè...";
            this.menuAddContact.Click += new System.EventHandler(this.menuAddContact_Click);
            // 
            // menuRemoveContact
            // 
            this.menuRemoveContact.Enabled = false;
            this.menuRemoveContact.Index = 2;
            this.menuRemoveContact.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftX;
            this.menuRemoveContact.Text = "Xóa bạn bè...";
            this.menuRemoveContact.Click += new System.EventHandler(this.menuRemoveContact_Click);
            // 
            // menuLogMessage
            // 
            this.menuLogMessage.Enabled = false;
            this.menuLogMessage.Index = 3;
            this.menuLogMessage.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
            this.menuLogMessage.Text = "Lịch sử chat...";
            this.menuLogMessage.Click += new System.EventHandler(this.menuLogMessage_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 4;
            this.menuItem4.Text = "-";
            // 
            // menuChangeUser
            // 
            this.menuChangeUser.Index = 5;
            this.menuChangeUser.Text = "Đăng nhập";
            this.menuChangeUser.Click += new System.EventHandler(this.menuChangeUser_Click);
            // 
            // menuSignOut
            // 
            this.menuSignOut.Enabled = false;
            this.menuSignOut.Index = 6;
            this.menuSignOut.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.menuSignOut.Text = "Đăng xuất";
            this.menuSignOut.Click += new System.EventHandler(this.menuSignOut_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 7;
            this.menuItem7.Text = "-";
            // 
            // menuMin
            // 
            this.menuMin.Index = 8;
            this.menuMin.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
            this.menuMin.Text = "Thu nhỏ xuống khay hệ thống";
            this.menuMin.Click += new System.EventHandler(this.menuMin_Click);
            // 
            // menuExit
            // 
            this.menuExit.Index = 9;
            this.menuExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem11,
            this.menuNetworkSettings,
            this.menuChangeDisplayName,
            this.menuItem1,
            this.menuOpenChatRoom,
            this.menuJoinRoom});
            this.menuItem10.Text = "Mở rộng";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 0;
            this.menuItem11.Text = "Tùy chỉnh";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuNetworkSettings
            // 
            this.menuNetworkSettings.Index = 1;
            this.menuNetworkSettings.Text = "Thiết lập mạng";
            this.menuNetworkSettings.Click += new System.EventHandler(this.menuNetworkSettings_Click);
            // 
            // menuChangeDisplayName
            // 
            this.menuChangeDisplayName.Enabled = false;
            this.menuChangeDisplayName.Index = 2;
            this.menuChangeDisplayName.Text = "Đổi tên hiển thị với bạn bè";
            this.menuChangeDisplayName.Click += new System.EventHandler(this.menuChangeDisplayName_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // menuOpenChatRoom
            // 
            this.menuOpenChatRoom.Enabled = false;
            this.menuOpenChatRoom.Index = 4;
            this.menuOpenChatRoom.Text = "Mở một Chat Room";
            this.menuOpenChatRoom.Click += new System.EventHandler(this.menuOpenChatRoom_Click);
            // 
            // menuJoinRoom
            // 
            this.menuJoinRoom.Enabled = false;
            this.menuJoinRoom.Index = 5;
            this.menuJoinRoom.Text = "Tham gia một Chat Room";
            this.menuJoinRoom.Click += new System.EventHandler(this.menuJoinRoom_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
            this.menuItem13.Text = "Trợ giúp";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 0;
            this.menuAbout.Text = "Thông tin";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // tmrMessageReceive
            // 
            this.tmrMessageReceive.Interval = 1000;
            this.tmrMessageReceive.Tick += new System.EventHandler(this.tmrMessageReceive_Tick);
            // 
            // pnlContacts
            // 
            this.pnlContacts.AutoScroll = true;
            this.pnlContacts.BackColor = System.Drawing.Color.White;
            this.pnlContacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlContacts.Location = new System.Drawing.Point(14, 81);
            this.pnlContacts.Name = "pnlContacts";
            this.pnlContacts.Size = new System.Drawing.Size(279, 391);
            this.pnlContacts.TabIndex = 0;
            this.pnlContacts.Resize += new System.EventHandler(this.pnlContacts_Resize);
            // 
            // tmrContactUpdate
            // 
            this.tmrContactUpdate.Interval = 3000;
            this.tmrContactUpdate.Tick += new System.EventHandler(this.tmrContactUpdate_Tick);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 289);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(314, 26);
            this.statusBar.TabIndex = 1;
            // 
            // conMenu
            // 
            this.conMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.conMenuSendMessage,
            this.conMenuRemoveContact,
            this.menuItem5,
            this.conMenuAddContact});
            // 
            // conMenuSendMessage
            // 
            this.conMenuSendMessage.Index = 0;
            this.conMenuSendMessage.Text = "Gửi một tin nhắn tới bạn này";
            this.conMenuSendMessage.Click += new System.EventHandler(this.conMenuSendMessage_Click);
            // 
            // conMenuRemoveContact
            // 
            this.conMenuRemoveContact.Index = 1;
            this.conMenuRemoveContact.Text = "Xóa người bạn này";
            this.conMenuRemoveContact.Click += new System.EventHandler(this.conMenuRemoveContact_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // conMenuAddContact
            // 
            this.conMenuAddContact.Index = 3;
            this.conMenuAddContact.Text = "Thêm bạn bè...";
            this.conMenuAddContact.Click += new System.EventHandler(this.menuAddContact_Click);
            // 
            // conMenuContactsPanel
            // 
            this.conMenuContactsPanel.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.conMenuPanelAddContact,
            this.conMenuPanelRemoveContact,
            this.menuItem6,
            this.conMenuRefreshContactsPanel});
            // 
            // conMenuPanelAddContact
            // 
            this.conMenuPanelAddContact.Index = 0;
            this.conMenuPanelAddContact.Text = "Thêm bạn bè...";
            this.conMenuPanelAddContact.Click += new System.EventHandler(this.menuAddContact_Click);
            // 
            // conMenuPanelRemoveContact
            // 
            this.conMenuPanelRemoveContact.Index = 1;
            this.conMenuPanelRemoveContact.Text = "Xóa bạn bè...";
            this.conMenuPanelRemoveContact.Click += new System.EventHandler(this.menuRemoveContact_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "-";
            // 
            // conMenuRefreshContactsPanel
            // 
            this.conMenuRefreshContactsPanel.Index = 3;
            this.conMenuRefreshContactsPanel.Text = "Làm mới lại danh sách";
            this.conMenuRefreshContactsPanel.Click += new System.EventHandler(this.conMenuRefreshContactsPanel_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenu = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "LAN Messenger";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.showLanMessenger,
            this.notMenuSend,
            this.menuItem8,
            this.menuItem9,
            this.notMenuSignIn,
            this.notMenuSignOut,
            this.menuItem15,
            this.notMenuAbout,
            this.notMenuMin,
            this.notMenuExit});
            // 
            // showLanMessenger
            // 
            this.showLanMessenger.Index = 0;
            this.showLanMessenger.Text = "Hiện LAN Messenger!";
            this.showLanMessenger.Click += new System.EventHandler(this.showLanMessenger_Click);
            // 
            // notMenuSend
            // 
            this.notMenuSend.Enabled = false;
            this.notMenuSend.Index = 1;
            this.notMenuSend.Text = "Gửi một tin nhắn tới...";
            this.notMenuSend.Click += new System.EventHandler(this.menuSendMessage_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.Text = "-";
            // 
            // notMenuSignIn
            // 
            this.notMenuSignIn.Index = 4;
            this.notMenuSignIn.Text = "Đăng nhập";
            this.notMenuSignIn.Click += new System.EventHandler(this.menuChangeUser_Click);
            // 
            // notMenuSignOut
            // 
            this.notMenuSignOut.Enabled = false;
            this.notMenuSignOut.Index = 5;
            this.notMenuSignOut.Text = "Đăng xuất";
            this.notMenuSignOut.Click += new System.EventHandler(this.menuSignOut_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 6;
            this.menuItem15.Text = "-";
            // 
            // notMenuAbout
            // 
            this.notMenuAbout.Index = 7;
            this.notMenuAbout.Text = "Thông tin";
            this.notMenuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // notMenuMin
            // 
            this.notMenuMin.Index = 8;
            this.notMenuMin.Text = "Thu nhỏ xuống khay hệ thống";
            this.notMenuMin.Click += new System.EventHandler(this.menuMin_Click);
            // 
            // notMenuExit
            // 
            this.notMenuExit.Index = 9;
            this.notMenuExit.Text = "Thoát";
            this.notMenuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.ForeColor = System.Drawing.Color.Green;
            this.lblWelcome.Location = new System.Drawing.Point(14, 8);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(105, 16);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Chưa đăng nhập";
            // 
            // txtSearchName
            // 
            this.txtSearchName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSearchName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearchName.Enabled = false;
            this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSearchName.Location = new System.Drawing.Point(52, 54);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(241, 23);
            this.txtSearchName.TabIndex = 3;
            this.txtSearchName.Text = "Nhập tên bạn bè cần tìm...";
            this.toolTip1.SetToolTip(this.txtSearchName, "Tìm kiếm bạn bè bằng có gợi ý bằng cách nhập tên vào đây rồi nhấn Enter.");
            this.txtSearchName.Click += new System.EventHandler(this.SearchKeyClick);
            this.txtSearchName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKeyPress);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Search Bar...";
            // 
            // picSearch
            // 
            this.picSearch.Image = ((System.Drawing.Image)(resources.GetObject("picSearch.Image")));
            this.picSearch.Location = new System.Drawing.Point(18, 50);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(30, 28);
            this.picSearch.TabIndex = 4;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // rbtnOnline
            // 
            this.rbtnOnline.AutoSize = true;
            this.rbtnOnline.Enabled = false;
            this.rbtnOnline.Location = new System.Drawing.Point(18, 28);
            this.rbtnOnline.Name = "rbtnOnline";
            this.rbtnOnline.Size = new System.Drawing.Size(66, 20);
            this.rbtnOnline.TabIndex = 5;
            this.rbtnOnline.TabStop = true;
            this.rbtnOnline.Text = "Online";
            this.toolTip2.SetToolTip(this.rbtnOnline, "Hiện nick với mọi người.");
            this.rbtnOnline.UseVisualStyleBackColor = true;
            this.rbtnOnline.CheckedChanged += new System.EventHandler(this.rbtnOnline_CheckedChanged);
            // 
            // rbtnInvisible
            // 
            this.rbtnInvisible.AutoSize = true;
            this.rbtnInvisible.Enabled = false;
            this.rbtnInvisible.Location = new System.Drawing.Point(91, 27);
            this.rbtnInvisible.Name = "rbtnInvisible";
            this.rbtnInvisible.Size = new System.Drawing.Size(77, 20);
            this.rbtnInvisible.TabIndex = 6;
            this.rbtnInvisible.TabStop = true;
            this.rbtnInvisible.Text = "Invisible";
            this.toolTip2.SetToolTip(this.rbtnInvisible, "Ẩn nick với mọi người.");
            this.rbtnInvisible.UseVisualStyleBackColor = true;
            this.rbtnInvisible.CheckedChanged += new System.EventHandler(this.rbtnInvisible_CheckedChanged);
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip2.ToolTipTitle = "Trạng thái...";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(314, 315);
            this.Controls.Add(this.rbtnInvisible);
            this.Controls.Add(this.rbtnOnline);
            this.Controls.Add(this.picSearch);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.pnlContacts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(278, 362);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAN MESSENGER!";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		[STAThread]
		static void Main() 
		{			
			using(Form1 frm1 = new Form1())
			{
				Application.Run(frm1);
			}
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			notifyIcon.Dispose();
			ChannelServices.UnregisterChannel(channel);
			try
			{
                if (setting[5] == "2")
                    DeleteAllLogs();
				Global.server.SignOut(Global.username);                
			}
			finally
			{
				Application.Exit();
			}
		}

		private void menuSendMessage_Click(object sender, System.EventArgs e)
		{
			using(FormSelectContact frmContact = new FormSelectContact())
			{
				if(frmContact.ShowDialog(this)==DialogResult.OK)
				{
					if(frmContact.txtContact.Text==Global.username)
					{
						MessageBox.Show("Bạn không thể gửi tin nhắn tới chính bạn được!");
						return;
					}
					if(Global.windowList.Contains(frmContact.txtContact.Text))
					{
						((FormMessage)Global.windowList[frmContact.txtContact.Text]).Focus();
					}
					else
					{
						FormMessage frmMessage = new FormMessage();
						frmMessage.contact=frmContact.txtContact.Text;
						frmMessage.Text=frmContact.txtContact.Text+" - Tin nhắn trực tiếp.";
						Global.windowList.Add(frmContact.txtContact.Text,frmMessage);				
						frmMessage.Show();
					}
				}
			}
		}
		private void tmrMessageReceive_Tick(object sender, System.EventArgs e)
		{
			LetterReceive letter;
			try
			{
				letter = Global.server.Receive(Global.username);
			}
			catch
			{
				AbortConnection();
				return;
			}
			if(letter.From=="")
			{
				return;
			}
			if(Global.windowList.Contains(letter.From))
			{	
				if(letter.Message=="BUZZ IT")
				{
					((FormMessage)Global.windowList[letter.From]).Focus();			
				}
				((FormMessage)Global.windowList[letter.From]).AddText(letter.From,letter.Message);

			}
			else
			{
				FormMessage frmMessage = new FormMessage();
				frmMessage.contact=letter.From;
				frmMessage.Text=letter.From+" - Tin nhắn trực tiếp.";
				frmMessage.AddText(letter.From,letter.Message);
				Global.windowList.Add(letter.From,frmMessage);
				frmMessage.Show();
			}
		}

		private void menuAddContact_Click(object sender, System.EventArgs e)
		{
			FormAddContact frmAddContact = new FormAddContact();
			if(frmAddContact.ShowDialog()==DialogResult.OK)
			{
				UpdatePanelContact();
			}
		}


        private void menuLogMessage_Click(object sender, EventArgs e)
        {
            FormLogsReader f = new FormLogsReader();
            f.Show();
        }

		private void menuSignOut_Click(object sender, System.EventArgs e)
		{
            Global.server.SignOut(Global.username);
            if (setting[5] == "2")
                DeleteAllLogs();
            pnlContacts.Controls.Clear();            
            Global.contactList.Clear();
            Global.username = "";
            this.txtSearchName.Enabled = false;
            rbtnOnline.Enabled = false;
            rbtnInvisible.Enabled = false;
            this.txtSearchName.Clear();
            this.menuAddContact.Enabled = false;
            this.menuSendMessage.Enabled = false;
            this.menuRemoveContact.Enabled = false;
            this.menuLogMessage.Enabled = false;
            this.menuChangeDisplayName.Enabled = false;
            this.menuOpenChatRoom.Enabled = false;
            this.menuJoinRoom.Enabled = false;
            this.menuChangeUser.Text = "Đăng nhập...";
            this.menuSignOut.Enabled = false;
            this.pnlContacts.ContextMenu = null;
            this.notMenuSend.Enabled = false;
            this.notMenuSignIn.Text = "Đăng nhập...";
            this.notMenuSignOut.Enabled = false;
            tmrMessageReceive.Enabled = false;
            tmrContactUpdate.Enabled = false;
            SignIn();
		}

        // Tham gia một room đã có sẵn
        private void menuJoinRoom_Click(object sender, EventArgs e)
        {
            FormJoinRoom fjr = new FormJoinRoom();
            fjr.Show();
        }

        // Delegate để UnregisterChannel khi FormChatRoom đóng
        bool ChatRoomClosed = false;
        public void GetValue(Boolean b)
        {
            ChatRoomClosed = b;
            if (ChatRoomClosed)
                ChannelServices.UnregisterChannel(channelChatRoom);
        }

        TcpChannel channelChatRoom;
        // Mở một chat room mới.
        public void menuOpenChatRoom_Click(object sender, EventArgs e)
        {
            // Khởi tạo kênh liên lạc với remote Object.
            channelChatRoom = new TcpChannel(7070);
            ChannelServices.RegisterChannel(channelChatRoom, false);

            // Ở đây sẻ sử dụng Singleton để duy trì trạng thái với nhiều kết nối Client 
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(SampleObject), Global.username.ToString(), WellKnownObjectMode.Singleton); // Cho Server chat room
            
            // Mở Room
            if (OpenRoom() == 0)
            {
                ChannelServices.UnregisterChannel(channelChatRoom);
                channelChatRoom = null;
            }
        }

        TcpChannel chan;
        private int OpenRoom()
        {
            ArrayList alOnlineUser = new ArrayList();
            FormChatRoom objChatWin;

            if (true) 
            {
                chan = new TcpChannel();
                //ChannelServices.RegisterChannel(chan, false);
                chan = null;
                IPHostEntry temp = Dns.GetHostByName(Dns.GetHostName().ToString());
                string IP = temp.AddressList[0].ToString();
                objChatWin = new FormChatRoom();
                objChatWin.MyGetData = new FormChatRoom.GetString(GetValue);
                objChatWin.remoteObj = (SampleObject)Activator.GetObject(typeof(LanMessengerChatRoomBase.SampleObject), "tcp://"+IP+":7070/" + Global.username);

                if (!objChatWin.remoteObj.JoinToChatRoom(Global.username))
                {
                    MessageBox.Show(Global.username + " đã đăng nhập rồi!. Có thể mạng bị lag, hãy thử lại sau!");
                    ChannelServices.UnregisterChannel(chan);
                    chan = null;
                    objChatWin.Dispose();
                    return 1; // 1: da dang nhap roi
                }
                objChatWin.key = objChatWin.remoteObj.CurrentKeyNo();
                objChatWin.yourName = Global.username;
                objChatWin.Show();
                return 2; // 2 : Dang nhap cong
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra khi tạo Room Chat, vui lòng thử lại!");
                chan = null;
                return 0; // 0: Loi
            }
        }

        // Thay đổi tên hiển thị với bạn bè
        private void menuChangeDisplayName_Click(object sender, EventArgs e)
        {
            FormChangeDisplayName fcdn = new FormChangeDisplayName();
            fcdn.Show();
        }

        // Thông báo tên 1 Contact Online
        private void GoOnline(string ContactName)
        {
            TrayBalloon.TrayBalloon tb = new TrayBalloon.TrayBalloon();
            tb.BackgroundLocation = "background.bmp";
            if (File.Exists(setting[1]))
                tb.SoundLocation = setting[1];
            else
                tb.SoundLocation = "sounds/Online.wav";
            tb.Title = "Lan Messenger!";
            tb.Message = Global.server.GetfullName(ContactName) + " đã Online!";
            tb.Run();
        }

        // Thông báo tên 1 Contact Offline
        private void GoOffline(string ContactName)
        {
            TrayBalloon.TrayBalloon tb = new TrayBalloon.TrayBalloon();
            tb.BackgroundLocation = "background.bmp";
            if (File.Exists(setting[2]))
                tb.SoundLocation = setting[2];
            else
                tb.SoundLocation = "sounds/Offline.wav";
            tb.Title = "Lan Messenger!";
            tb.Message = Global.server.GetfullName(ContactName) + " đã Offline!";
            tb.Run();
        }

        bool Check = false; // Biến cờ kiểm tra đã Check trạng thái của 1 người dùng hay chưa?
        private void tmrContactUpdate_Tick(object sender, System.EventArgs e)
		{
            try
			{
				foreach(object o in Global.contactList)
				{
                    // Thay đổi biến cờ khi bạn bè thay đổi trạng thái.
                    if (((LanMessengerControls.LanMessengerContact)o).Online != Global.server.IsVisible((o as LanMessengerControls.LanMessengerContact).Contact))  Check = !Check;
                    // Cập nhật lại trạng thái trong Contact List
					((LanMessengerControls.LanMessengerContact)o).Online=Global.server.IsVisible((o as LanMessengerControls.LanMessengerContact).Contact);
                    // Thông báo trạng thái của bạn bè!
                    if (Check)
                    {
                        if (Global.server.IsVisible((o as LanMessengerControls.LanMessengerContact).Contact))
                            GoOnline((o as LanMessengerControls.LanMessengerContact).Contact.ToString());
                        else GoOffline((o as LanMessengerControls.LanMessengerContact).Contact.ToString());
                        Check = !Check;
                    }                    
                }
				pnlContacts.Update();                
			}
			catch
			{
                AbortConnection();
				return;
			}
		}

		private void menuRemoveContact_Click(object sender, System.EventArgs e)
		{
			FormSelectContact frmSelectContact = new FormSelectContact();
            if (frmSelectContact.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Global.server.RemoveContact(Global.username, frmSelectContact.txtContact.Text);
                    UpdatePanelContact();
                }
                catch
                {
                    AbortConnection();
                    return;
                }
            }
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			pnlContacts.Width=this.Width-24;
			pnlContacts.Height=this.Height-88;
		}

		private void pnlContacts_Resize(object sender, System.EventArgs e)
		{
			foreach(object o in Global.contactList)
			{
				((LanMessengerControls.LanMessengerContact)o).Width=pnlContacts.Width-32;
			}
		}

		private void menuChangeUser_Click(object sender, System.EventArgs e)
		{
            try
            {
                Global.server.SignOut(Global.username);
                if (setting[5] == "2")
                    DeleteAllLogs();
                pnlContacts.Controls.Clear();
                Global.contactList.Clear();
                this.txtSearchName.Enabled = false;
                rbtnOnline.Enabled = false;
                rbtnInvisible.Enabled = false;
                this.txtSearchName.Clear();
                this.menuAddContact.Enabled = false;
                this.menuSendMessage.Enabled = false;
                this.menuRemoveContact.Enabled = false;
                this.menuLogMessage.Enabled = false;
                this.menuChangeDisplayName.Enabled = false;
                this.menuOpenChatRoom.Enabled = false;
                this.menuJoinRoom.Enabled = false;
                this.menuChangeUser.Text = "Đăng nhập...";
                this.menuSignOut.Enabled = false;
                this.pnlContacts.ContextMenu = null;
                this.notMenuSend.Enabled = false;
                this.notMenuSignIn.Text = "Đăng nhập...";
                this.notMenuSignOut.Enabled = false;
                tmrMessageReceive.Enabled = false;
                tmrContactUpdate.Enabled = false;
            }
            finally
            {
                SignIn();
            }		
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			try
			{
                if (setting[5] == "2")
                    DeleteAllLogs();
                Global.server.SignOut(Global.username); // Người dùng bấm Exit thì cũng sẻ SignOut nick lun.
			}
			finally
			{
				Application.Exit();
			}			
		}
		
		private void menuNetworkSettings_Click(object sender, System.EventArgs e)
		{
			FormNetworkSettings frmNetworkSettings = new FormNetworkSettings();
			frmNetworkSettings.txtIP.Text=hostIP;
			if(frmNetworkSettings.ShowDialog()==DialogResult.OK)
			{
				hostIP=frmNetworkSettings.txtIP.Text;
				try
				{
					AbortConnection();
					MarshalByRefObject obj = (MarshalByRefObject)RemotingServices.Connect(typeof(IServer),"http://"+hostIP+":9090/Server");
					Global.server=obj as IServer;                    
				}
				catch
				{
					AbortConnection();
					return;
				}
			}
		}

        


		private void conMenuSendMessage_Click(object sender, System.EventArgs e)
		{
			OpenFormMessage((conMenu.SourceControl as LanMessengerControls.LanMessengerContact).Contact);
		}

		private void UpdatePanelContact()
		{
			statusBar.Text="Đang tải danh sách bạn bè từ Server...";
			ArrayList contacts=null;
			try
			{
				contacts = Global.server.GetContacts(Global.username);
			}
			catch
			{
				AbortConnection();
				return;
			}
			statusBar.Text="Danh sách bạn bè đã được tải.";


            Label lblInfo = new Label();
            lblInfo.Text="Danh sách bạn bè :";
			lblInfo.Location=new System.Drawing.Point(8,4);
			lblInfo.Size=new System.Drawing.Size(200,16);
            
			
			pnlContacts.Controls.Clear();
			Global.contactList.Clear();
			pnlContacts.Controls.Add(lblInfo);
			int i = 20;
			statusBar.Text="Đang cập nhật danh sách bạn bè...";
			foreach(object o in contacts)
			{						
				LanMessengerControls.LanMessengerContact temp = new LanMessengerControls.LanMessengerContact();
                temp.DisplayName = Global.server.GetfullName(o as string); // Hiển thị Display Name thay vì là Username
                temp.Contact = o as string;
				statusBar.Text="Đang thêm "+o as string;
				try
				{
					temp.Online=Global.server.IsVisible(o as String);
				}
				catch
				{
					AbortConnection();
					return;
				}
				temp.Location=new System.Drawing.Point(8,i);
				temp.Size=new System.Drawing.Size(pnlContacts.Width-32,16);
				temp.DoubleClick+=new System.EventHandler(this.Contact_Click); // Sự kiện double click lên contact
				temp.ContextMenu=conMenu;

				pnlContacts.Controls.Add(temp);
				Global.contactList.Add(temp);
				i +=18;
			}
            CreateAutoCompleteTextBox(); // Tạo dữ liệu cho khung SearchContact
			statusBar.Text="Cập nhật danh sách bạn bè thành công.";
		}
		private void OpenFormMessage(string contact)
		{
			if(Global.windowList.Contains(contact))
			{
				((FormMessage)Global.windowList[contact]).Focus();
			}
			else
			{
				FormMessage frmMessage = new FormMessage();
				frmMessage.contact=contact;
				frmMessage.Text= Global.server.GetfullName(contact) + " (" + contact + ")" + " - Tin nhắn trực tiếp.";
				frmMessage.Show();
				Global.windowList.Add(contact,frmMessage);					
			}
		}

        // Xử lý SignOut
		private void SignOut()
		{			
			ArrayList a = new ArrayList();
			foreach(string key in Global.windowList.Keys)
				a.Add(key);
			foreach(string key in a)
				(Global.windowList[key] as FormMessage).Close();

            this.txtSearchName.Enabled = false;
            rbtnOnline.Enabled = false;
            rbtnInvisible.Enabled = false;
            this.txtSearchName.Clear();
            this.menuAddContact.Enabled = false;
            this.menuSendMessage.Enabled = false;
            this.menuRemoveContact.Enabled = false;
            this.menuLogMessage.Enabled = false;
            this.menuChangeDisplayName.Enabled = false;
            this.menuOpenChatRoom.Enabled = false;
            this.menuJoinRoom.Enabled = false;
			this.menuChangeUser.Text="Đăng nhập...";
            this.menuSignOut.Enabled = false;
            this.pnlContacts.ContextMenu = null;
            this.notMenuSend.Enabled = false;
            this.notMenuSignIn.Text = "Đăng nhập...";
            this.notMenuSignOut.Enabled = false;
            tmrMessageReceive.Enabled = false;
            tmrContactUpdate.Enabled = false;
            if (setting[5] == "2")
                DeleteAllLogs();
			try
			{
				Global.server.SignOut(Global.username);                
				statusBar.Text="Đã đăng xuất.";                
			}
			catch
			{
				AbortConnection();
				return;
			}
			finally
			{
				pnlContacts.Controls.Clear();
				Global.contactList.Clear();
				Global.username="";
				
			}
		}
		private void conMenuRemoveContact_Click(object sender, System.EventArgs e)
		{
			try
			{
				Global.server.RemoveContact(Global.username,(conMenu.SourceControl as LanMessengerControls.LanMessengerContact).Contact);
				UpdatePanelContact();
			}
			catch
			{
				AbortConnection();
				return;
			}
		}

        // Sự kiện người dùng bấm refresh lại danh sách contact
		private void conMenuRefreshContactsPanel_Click(object sender, System.EventArgs e)
		{
			this.UpdatePanelContact();
		}

        // Xử lý đăng nhập
		private void SignIn()
		{            
			notifyIcon.ContextMenu=null;
			statusBar.Text="Thao tác đăng nhập";
            lblWelcome.Text = "Chưa đăng nhập";
			FormSignIn frmSignIn = new FormSignIn();
			switch(frmSignIn.ShowDialog(this))
			{
				case DialogResult.OK:					
					Global.username=frmSignIn.txtUsername.Text; // Tên người dùng = tên nhập lúc đầu ở form SignIn
					try
					{
                        // Nếu có tin nhắn offline thì hiển thị ở FormOfflineMessages 
						ArrayList offline = Global.server.ReceiveOffline(Global.username);
						if(offline.Count>0)
						{
							FormOfflineMessages frmOffline = new FormOfflineMessages(offline);
                            frmOffline.Show();                            
						}						
					}
					catch
					{
						AbortConnection();
						return;
					}
                    
                    txtSearchName.Enabled = true;
                    rbtnOnline.Enabled = true;
                    rbtnInvisible.Enabled = true;                    

                    // Xét trạng thái lúc đầu của 2 Radiobutton này
                    if (Global.server.IsVisible(Global.username))
                    {
                        rbtnOnline.Checked = true;
                    }
                    else
                        rbtnInvisible.Checked = true;
                    
					statusBar.Text="Đã đăng nhập";
                    if (Global.server.IsVisible(Global.username))
                        lblWelcome.Text = "Chào " + Global.server.GetfullName(Global.username) + "! Bạn đang Online.";
                    else
                        lblWelcome.Text = "Chào " + Global.server.GetfullName(Global.username) + "! Bạn đang đăng nhập ẩn.";
					tmrMessageReceive.Enabled=true;
					tmrContactUpdate.Enabled=true;
		
					this.menuAddContact.Enabled=true;
					this.menuSendMessage.Enabled=true;
					this.menuRemoveContact.Enabled=true;
                    this.menuLogMessage.Enabled = true;
                    this.menuChangeDisplayName.Enabled = true;
                    this.menuOpenChatRoom.Enabled = true;
                    this.menuJoinRoom.Enabled = true;
                    this.menuChangeUser.Text = "Đăng nhập bằng một tài khoản khác...";
					this.menuSignOut.Enabled=true;
					this.pnlContacts.ContextMenu=this.conMenuContactsPanel;

					this.notMenuSend.Enabled=true;
					this.notMenuSignIn.Text="Đăng nhập bằng một tài khoản khác...";
					this.notMenuSignOut.Enabled=true;

					this.UpdatePanelContact();
					break;
			}
			notifyIcon.ContextMenu=this.notifyMenu;			
		}

		private void AbortConnection()
		{
			tmrMessageReceive.Enabled=false;
			tmrContactUpdate.Enabled=false;

			this.menuAddContact.Enabled=false;
			this.menuSendMessage.Enabled=false;
			this.menuRemoveContact.Enabled=false;
            this.menuLogMessage.Enabled = false;
            this.menuChangeDisplayName.Enabled = false;
            this.menuOpenChatRoom.Enabled = false;
            this.menuJoinRoom.Enabled = false;
			this.menuChangeUser.Text="Đăng nhập...";
			this.menuSignOut.Enabled=false;
			this.pnlContacts.ContextMenu=null;

			this.notMenuSend.Enabled=false;
			this.notMenuSignIn.Text="Đăng nhập...";
			this.notMenuSignOut.Enabled=false;

			ArrayList a = new ArrayList();
			foreach(string key in Global.windowList.Keys)
				a.Add(key);
			foreach(string key in a)
				(Global.windowList[key] as FormMessage).Close();
			Global.username="";
			pnlContacts.Controls.Clear();
			Global.contactList.Clear();
            //statusBar.Text = "Lỗi kết nối tới Server.";
			this.Focus();
            //MessageBox.Show("Lỗi kết nối tới Server. Vui lòng kiểm tra kết nối và thử lại!");
		}

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			FormAbout frmAbout = new FormAbout();
			frmAbout.ShowDialog();
		}

        private void menuMin_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            notifyIcon.BalloonTipTitle = "LAN MESSENGER!";
            notifyIcon.BalloonTipText = "Chương trình đã được thu nhỏ xuống khay hệ thống.";
            notifyIcon.ShowBalloonTip(2000);
            this.notMenuMin.Enabled = false;
        }

        private void showLanMessenger_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.menuMin.Enabled = true;
            this.notMenuMin.Enabled = true;
        }

        // Sự kiện mở FormOption
        private void menuItem11_Click(object sender, EventArgs e)
        {
            FormOption fo = new FormOption();
            fo.Show();
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
            setting[5] = w1.ReadString().ToString(); // Tùy chọn việc lưu logs
            w1.Close();
            fs1.Close();
        }

        // Tạo dữ liệu cho khung SearchContact
        private void CreateAutoCompleteTextBox()
        {           
            string[] arrayContact = new string[Global.contactList.Count]; // Khởi tạo mảng chứa tên các Contact trong list
            int i = 0;

            // Đưa tên các Contact trong list vào mảng arrayContact
            foreach (object o in Global.contactList)
            {
                arrayContact[i] = ((LanMessengerControls.LanMessengerContact)o).Contact.ToString();
                i++;
            }

            // Khởi tạo AutoCompleteString
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();                        
            foreach (string name in arrayContact)
            {
                auto.Add(name + " (" + Global.server.GetfullName(name) + ")");
            }
          
            // Gán AutoCompleteSource cho textbox txtSearchContact
            txtSearchName.AutoCompleteCustomSource = auto;
        }

        // Khi nhấn phím Enter thì mở ra khung chat với tên đã Search
        private void SearchKeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSearchName.Text.IndexOf('(') != -1)
                    OpenFormMessage(txtSearchName.Text.Substring(0, txtSearchName.Text.IndexOf('(') - 1)); // Mở khung chat tới Contact vừa tìm
                this.txtSearchName.Clear();
                this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtSearchName.ForeColor = System.Drawing.SystemColors.WindowFrame;
                this.txtSearchName.Text = "Nhập tên bạn bè cần tìm...";
            }
        }

        // Khi tìm người nào đó xong thì Clear nội dung hiện tại của Searchbar
        private void SearchKeyClick(object sender, System.EventArgs e)
        {
            this.txtSearchName.Clear();
            this.txtSearchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.ForeColor = System.Drawing.SystemColors.MenuText;
        }

        // Icon bên thanh tìm kiếm
        private void picSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchName.Text != "" && txtSearchName.Text != "Nhập tên bạn bè cần tìm...")
            {
                OpenFormMessage(txtSearchName.Text.Substring(0, txtSearchName.Text.IndexOf('(') -1));
            }
        }

        // Sự kiện chọn RadioButton Online
        private void rbtnOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOnline.Checked == true && !Global.server.IsVisible(Global.username))
            {
                Global.server.ChangeStatus(Global.username);
                lblWelcome.Text = "Chào " + Global.server.GetfullName(Global.username) + "! Bạn đang Online.";
            }                
        }

        private void rbtnInvisible_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnInvisible.Checked == true && Global.server.IsVisible(Global.username))
            {
                Global.server.ChangeStatus(Global.username);
                lblWelcome.Text = "Chào " + Global.server.GetfullName(Global.username) + "! Bạn đang đăng nhập ẩn.";
            }                
        }

        // Thủ tục xóa Logs khi người dùng chọn chế độ "xóa all tin nhắn khi đăng xuất"
        private void DeleteAllLogs()
        {
            if (Global.username != "") // Kiểm tra xem người dùng đã đăng nhập hay chưa thì mới xóa logs dc
            {
                string path = "logs/" + Global.username + "/";
                if (Directory.Exists(path))
                {
                    // Lấy danh sách các folder con của Folder hiện tại.
                    string[] directoryContact = Directory.GetDirectories(path);
                    foreach (string dc in directoryContact)
                    {
                        // Lấy danh sách các file trong folder dc hiện tại
                        string[] fileLogs = Directory.GetFiles(dc);
                        foreach (string fl in fileLogs)
                        {
                            File.Delete(fl); // xóa lần lượt từng file
                        }
                        Directory.Delete(dc); // xóa mục con chứa file
                    }
                    Directory.Delete(path); // xóa mục lưu logs của người dùng
                }
            }            
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        // Mở file help.chm
        /*private void menuItem14_Click(object sender, EventArgs e)
        {
            if (File.Exists("help.chm"))
                System.Diagnostics.Process.Start("help.chm");
            else
                MessageBox.Show("Không tìm thấy tệp tin help.chm","Lỗi");
        }*/
	}
	class Global
	{
		internal static IServer server;
		internal static Hashtable windowList;
		internal static ArrayList contactList;
		internal static string username;

		static Global()
		{
			windowList = new Hashtable();
			contactList = new ArrayList();
			username="";
		}
	}
}