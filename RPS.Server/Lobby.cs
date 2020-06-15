using RPS.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Server
{
    class Lobby
    {
        public string LobbyID = GenerateLobbyID();
        public Client client1;
        public Client client2;

        public Lobby(Client client)
        {
            client1 = client;
        }

        public void Game()
        {
            int rounds = 5;
            while (rounds != 0)
            {
                string choice1 = client1.ReceiveString();
                string choice2 = client2.ReceiveString();
                int winner = CalculateWinner(choice1, choice2);
                Console.WriteLine(choice1 + "  " + choice2);
                if (winner == 1)
                {
                    client1.SendMessage("You Won");
                    client2.SendMessage("You Lost");
                }
                else if (winner == 0)
                {
                    client1.SendMessage("You Lost");
                    client2.SendMessage("You Won");
                }
                else
                {
                    client1.SendMessage("Draw");
                    client2.SendMessage("Draw");
                }
                rounds--;
            }
            Console.WriteLine("Game Over");

        }

        private int CalculateWinner(string c1, string c2)
        {
            Console.WriteLine($"Computer Chose {c2}");

            if (c1 == "rock" && c2 == "scissors" || c1 == "paper" && c2 == "rock" || c1 == "scissors" && c2 == "paper")
            {
                //C1 Wins
                return 1;
            }
            else if (c1 == c2)
            {
                //Draw
                return 2;
            }
            else
            {
                return 0;
            }
        }

        private static string GenerateLobbyID()
        {
            Random rnd = new Random();
            int tokenLength = 2; //Length Of Token
            var str = string.Empty;


            for (var i = 0; i < tokenLength; i++)
            {
                str += ((char)rnd.Next(33, 125)).ToString(); //Adds 64 for ascii Equivalent
            }

            return str;
        }
    }
}
