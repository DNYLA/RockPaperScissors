using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Client
{
    public class Player
    {

        public string GetChoice()
        {
            if (IsAI)
                return AiInput();

            Console.WriteLine("Chose Rock, Paper or Scissors");
            var input = Console.ReadLine();

            string choice = ValidateChoice(input);

            if (choice == "nothing")
            {
                Console.WriteLine("Invalid Option");
                return GetInput();
            }


            return choice;
        }

        private string ValidateChoice(string input)
        {
                input = input.ToLower();

                if (input != "rock" || input != "paper" || input != "scissors")
                {
                    return "nothing";
                }

                return input.ToLower();
        }


        public string AiInput()
        {
            Random rnd = new Random();

            var options = new List<string>
            {
                "rock",
                "paper",
                "scissors"
            };

            int choice = rnd.Next(0, options.Count());

            return options[choice];
        }

        public void DisplayScore()
        {
            Console.WriteLine($"You Won {score} times");
        }

        public string GetInput()
        {
            return Console.ReadLine().ToLower();
        }

        private bool IsAI = false;
        public int score = 0;


    }
}
