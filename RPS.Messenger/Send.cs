using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Messenger
{
    public class Send
    {
        public static void SendData(byte[] data, Socket sock)
        {
            sock.Send(data, 0, data.Length, SocketFlags.None);
        }

        public static void SendString(string message, Socket sock)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            SendData(data, sock);
        }
    }
}
