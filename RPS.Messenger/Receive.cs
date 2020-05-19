using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Messenger
{
    public class Receive
    {
        private static byte[] ReceiveData(Socket sock)
        {
            byte[] data = new byte[1024];
            int size = sock.Receive(data);
            byte[] buff = new byte[size];

            Array.Copy(data, buff, size);

            return buff;
        }

        public static string ReceiveString(Socket sock)
        {
            return Encoding.UTF8.GetString(ReceiveData(sock)); ;
        }

        public static int ReceiveInt32(Socket sock)
        {
            try
            {
                return Convert.ToInt32(Encoding.UTF8.GetString(ReceiveData(sock)));
            }
            catch
            {
                return int.MaxValue; //Error Checking
            }
        }

    }
}
