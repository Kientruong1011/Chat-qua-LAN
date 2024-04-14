using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;

namespace LanMessengerChatRoomBase
{
    // Lớp cơ sở của ChatRoom
    public class SampleObject : MarshalByRefObject
    {
        // Hashtable để lưu trữ tin nhắn từ các người dùng
        Hashtable hTChatMsg = new Hashtable();

        // ArrayList để lưu trữ các người dùng đang online
        ArrayList alOnlineUser = new ArrayList();

        // Biến key để đánh dấu số lượng tin nhắn và phục vụ như một định danh duy nhất cho mỗi tin nhắn
        private int key = 0;

        // Phương thức khi một người dùng tham gia vào phòng chat
        public bool JoinToChatRoom(string name)
        {
            if (alOnlineUser.IndexOf(name) > -1)
                return false; // Trả về false nếu tên người dùng đã tồn tại trong danh sách người dùng đang online
            else
            {
                alOnlineUser.Add(name);
                SendMsgToSvr(name + " đã tham gia phòng chat!"); // Gửi tin nhắn thông báo việc tham gia vào phòng chat
                return true;
            }
        }

        // Phương thức khi một người dùng rời khỏi phòng chat
        public void LeaveChatRoom(string name)
        {
            alOnlineUser.Remove(name); // Xóa người dùng ra khỏi danh sách người dùng đang online
            SendMsgToSvr(name + " đã rời khỏi phòng chat!"); // Gửi tin nhắn thông báo việc rời khỏi phòng chat
        }

        // Phương thức để lấy danh sách các người dùng đang online
        public ArrayList GetOnlineUser()
        {
            return alOnlineUser;
        }

        // Phương thức để trả về số key hiện tại (được sử dụng làm định danh cho mỗi tin nhắn)
        public int CurrentKeyNo()
        {
            return key;
        }

        // Phương thức để gửi tin nhắn đến máy chủ
        public void SendMsgToSvr(string chatMsgFromUsr)
        {
            hTChatMsg.Add(++key, chatMsgFromUsr); // Thêm tin nhắn mới vào Hashtable với key tăng dần
        }

        // Phương thức để lấy tin nhắn từ máy chủ dựa trên key cuối cùng mà người dùng đã nhận được
        public string GetMsgFromSvr(int lastKey)
        {
            if (key > lastKey)
                return hTChatMsg[lastKey + 1].ToString(); // Trả về tin nhắn mới nhất mà người dùng chưa nhận được
            else
                return ""; // Trả về chuỗi rỗng nếu không có tin nhắn mới
        }
    }
}
