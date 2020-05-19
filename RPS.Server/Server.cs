using RPS.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPS.Server
{
    class Server
    {
        //Setting Constants & Globals
        private const int PORT = 3068;
        List<Client> Clients = new List<Client>();
        private string IP_ADDRESS = "localhost";
        private Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void Initialize()
        {
            //Getting IP Info
            IPHostEntry host = Dns.GetHostEntry(IP_ADDRESS);
            IPAddress ipAdd = host.AddressList[0];
            IPEndPoint ipe = new IPEndPoint(ipAdd, PORT);
            
            //Setting IP Info
            ServerSocket.Bind(ipe);
            ServerSocket.Listen(0);

            Server s = new Server();
            
            //Listening for Clients
            while (true)
            {
                Socket cSock = ServerSocket.Accept();
                Console.WriteLine("Client Connected");

                Client client = SetInfo(cSock);

                //Create New Thread Listening to Commands
                Thread cThread = new Thread(() => s.ClientInterface(client));
                cThread.Start();
            }

            
        }

        private Client SetInfo(Socket sock)
        {
            Client client = new Client
            {
                Name = "Jimmy",
                sock = sock
            };

            return client;

        }

        public void ClientInterface(Client client)
        {
            while (client.connected)
            {
                client.SendMessage("Hello");
            }
            Console.WriteLine("Listening For Messages");

        }
    }
}
