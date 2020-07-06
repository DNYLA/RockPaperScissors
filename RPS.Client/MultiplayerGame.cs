using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RPS.Client.Server;

namespace RPS.Client
{
    class MultiplayerGame
    {
        Player self = new Player();
        public MultiplayerGame(Player ply)
        {
            self = ply;

            Console.WriteLine("Do You want to Connect or Create a lobby");

            string resp = self.GetInput();

            if (resp == "connect") { ConnectLobby(); }
            else { CreateLobby();  }
        }

        private void CreateLobby()
        {
            self.Messenger.SendMessage("CreateLobby");

            string LobbyID = self.Messenger.ReceiveString();

            Console.WriteLine(LobbyID);

            string ready = self.ReceiveString();
            PlayGame();
        }

        private void PlayGame()
        {
            int rounds = 5;

            while (rounds != 0)
            {
                Console.WriteLine("Enter Your Move (R/P/S)");
                string choice = self.GetInput();

                self.Messenger.SendMessage(choice);

                string result = self.Messenger.ReceiveString();

                Console.WriteLine(result);
                rounds--;
            }

            Console.WriteLine("Game Over");

        }

        public void ConnectLobby()
        {
            self.Messenger.SendMessage("ConnectLobby");

            Console.WriteLine("Enter The LobbyID2:   ");

            string lobbyID = self.GetInput(true);

            Thread.Sleep(500);
            self.Messenger.SendMessage(lobbyID);

            string response = self.ReceiveString();

            if (response == "Valid") { Console.WriteLine("Connected to Server"); }
            else { Console.WriteLine("Incorrect Lobby ID"); }

            PlayGame();
        }

    }
}
