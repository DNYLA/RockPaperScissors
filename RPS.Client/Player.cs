using RPS.Client.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Client
{
    public class Player
    {
        private bool IsAI = false;
        public int score = 0;
        public string LobbyID = "";
        public Socket clientSock;
        private string choice;

        public Server.Messenger Messenger;

        public string GetChoice()
        {
            return choice;
        }

        [Obsolete("No Need as Everything is Handled using UI")]
        private string ValidateChoice(string input)
        {
                input = input.ToLower();

                if (input != "rock" || input != "paper" || input != "scissors")
                {
                    return "nothing";
                }

                return input.ToLower();
        }


        public string SetAiChoice()
        {
            Random rnd = new Random();

            var options = new List<string>
            {
                "rock",
                "paper",
                "scissors"
            };

            int numChoice = rnd.Next(0, options.Count());
            choice = options[numChoice];
            return "dff";
        }

        public void SetChoice(string selectedChoice)
        { 
            choice = selectedChoice;
        }

        public string ReceiveString()
        {
            return RPS.Messenger.Receive.ReceiveString(clientSock);
        }


        public void DisplayScore()
        {
            Console.WriteLine($"You Won {score} times");
        }

        public string GetInput(bool caseInsensitive = false)
        {
            if (caseInsensitive) { return Console.ReadLine(); }
            return Console.ReadLine().ToLower();
        }

        public void UpdateMessenger()
        {
            Messenger = new Server.Messenger(clientSock);
        }



    }
}
