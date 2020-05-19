using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Server.Data
{

    class Client
    {

        public string Name = string.Empty;
        public int LobbyID = 0;
        public Socket sock = null;
        public bool connected = true;

        //Security Handle Later
        public string Token = string.Empty;

        //Do Receiving & Sending in Client Class to Reduce Imports
        public string ReceiveString()
        {
            return RPS.Messenger.Receive.ReceiveString(sock);
        }

        public int ReceiveInt()
        {
            int val = Messenger.Receive.ReceiveInt32(sock);


            //Add Error Handling Later
            //Messenger.Send.SendMessage("ReSend");

            return val;
        }

        public void SendMessage(string message)
        {
            Messenger.Send.SendString(message, sock);
        }
    }

}
