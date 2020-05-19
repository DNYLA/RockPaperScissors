using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Client
{
	public class Game
	{
		private string OpponentChoice, DefenderChoice;
		private int OpponentScore, DefenderScore = 0;
		private int RoundAmount = 0;
		private bool IsAI = true;

		public void Start()
		{
			ChooseSettings();

			for (var i = 0; RoundAmount > i; i++)
			{
				if (IsAI)
				{
					OpponentChoice = RandomOption();
				}

				Console.WriteLine("Rock, Paper or Scissors?");

				DefenderChoice = GetChoice(GetInput());

				HandleAnswers(OpponentChoice, DefenderChoice);
			}

			Console.WriteLine($"opponentscore: {OpponentScore}, defenderscore: {DefenderScore}");

			Console.ReadKey();
		}

		private void HandleAnswers(string oc, string dc)
		{
			if (oc == "rock" && dc == "paper" || oc == "paper" && dc == "rock" || oc == "scissors" && dc == "rock")
            {
				// Defender win
				DefenderScore++;
            }
			else if (oc == "rock" && dc == "rock" || oc == "paper" && dc == "paper" || oc == "scissors" && dc == "scissors")
            {
                // Draw
            }
			else
            {
				// Opponent win
				OpponentScore++;
				
            }
		}

		/// <summary>
		/// Select a random option from list of options
		/// </summary>
		/// <returns></returns>
		private string RandomOption()
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

		/// <summary>
		/// Ask user for settings and set them in variables
		/// </summary>
		private void ChooseSettings()
		{
			Console.WriteLine("How many rounds do you want to play?");

			RoundAmount = Int32.Parse(GetInput());

			Console.WriteLine("Do you want to play online?");

			if (GetInput() == "yes") IsAI = false;
		}

		/// <summary>
		/// Get input from console
		/// </summary>
		/// <returns>input</returns>
		public string GetInput()
		{
			var input = Console.ReadLine();

			return input.ToLower();
		}

		/// <summary>
		/// Get player choice
		/// </summary>
		/// <param name="input"></param>
		private string GetChoice(string input)
		{
			string choice;
			// Check input and find out choice

			if (input == "rock")
			{
				choice = "rock";
			}
			else if (input == "paper")
			{
				choice = "paper";
			}
			else if (input == "scissors")
			{
				choice = "scissors";
			}
			else
			{
				// re run
				choice = "nothing";
			}

			return choice;
		}
	}
}
