using RPS.Messenger;
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
        private const int PORT = 4030;
        List<Client> Clients = new List<Client>();
        List<Lobby> Lobbies = new List<Lobby>();
        private string IP_ADDRESS = "127.0.0.1";
        private Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void Initialize()
        {
            //Getting IP Info
            //IPHostEntry host = Dns.GetHostEntry(IP_ADDRESS);
            //IPAddress ipAdd = host.AddressList[0];
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP_ADDRESS), PORT);
            
            //Setting IP Info
            ServerSocket.Bind(ipe);
            ServerSocket.Listen(0);

            Console.WriteLine("Starting Server");

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
               
                string command = client.ReceiveString();
                Console.WriteLine(command + "Command");
                switch (command)
                {
                    case "CreateLobby":
                        CreateLobby(client);
                        break;
                    case "ConnectLobby":
                        ConnectLobby(client);
                        break;

                }
               
 
            }
            Console.WriteLine("Listening For Messages");

        }

        private void CreateLobby(Client client)
        {
            Lobby lobby = new Lobby(client);
            Lobbies.Add(lobby);

            client.SendMessage(lobby.LobbyID);

            if (lobby.client2 == null) { Console.WriteLine("Null"); }

            while (lobby.client2 == null)
            {
                Thread.Sleep(500); //Checks For New Clients Every 0.5 Seconds
            }

            client.SendMessage("Ready");

            Console.WriteLine("Both Clients Connected");

            lobby.Game();
        }

        public void ConnectLobby(Client client)
        {
            string lobbyID = client.ReceiveString();

            bool valid = false;

            foreach (Lobby lob in Lobbies)
            {
                if (lob.LobbyID == lobbyID)
                {
                    Console.WriteLine("Valid ID");
                    lob.client2 = client;
                    client.SendMessage("Valid");
                    valid = true;
                    lob.Game();
                }

                if (valid) { break; }
            }
                
            if (!valid) { client.SendMessage("Invalid Lobby Id"); }
        }
    }
}
