using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPS.Client.Server
{
    [Obsolete("This needs to be Moved")]
    public class Connect
    {
        private string IP_ADDRESS = "127.0.0.1";
        private int PORT = 4030;
        public  bool connected = false;
        protected internal static Socket sSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public bool InitializeConnection(out Socket sock)
        {
        sock = sSock;

            if (!connected)
            {
                int attempts = 0;
                do
                {
                    try
                    {
                        IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP_ADDRESS), PORT);
                        sSock.Connect(ipe);
                        connected = true;
                        sock = sSock;
                        if (sSock.Connected)
                        {
                            return true;
                        }
                    }
                    catch (Exception)
                    {

                    }
                    attempts++;
                    Console.WriteLine("Failed to Connect");
                    Thread.Sleep(500);
                } while (attempts < 20);

                return false;

            }

            if (connected) { Console.WriteLine("Already Connected"); }

            return true;
        }

        public void CloseConnection()
        {
            sSock.Close(500);
        }
    }
}
