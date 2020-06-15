using System.Net.Sockets;

namespace RPS.Client.Server
{
    public class Messenger
    {
        private readonly Socket serverSocket;
        public Messenger(Socket sock)
        {
            serverSocket = sock;
        }

        #region Send
        public void SendMessage(string message)
        {
            RPS.Messenger.Send.SendString(message, serverSocket);
        }
        #endregion

        #region Receive
        public string ReceiveString()
        {
            return RPS.Messenger.Receive.ReceiveString(serverSocket);
        }

        public int ReceiveInt()
        {
            int val = RPS.Messenger.Receive.ReceiveInt32(serverSocket);


            //Add Error Handling Later
            //Messenger.Send.SendMessage("ReSend");

            return val;
        }
        #endregion
    }
    
}
