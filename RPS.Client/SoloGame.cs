using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Client
{
	public class SoloGame
	{
		private Player self = new Player();
		public SoloGame(Player ply)
		{
			self = ply;
		}

		public void Start(int roundAmmount)
		{
			Player computer = new Player();

			for (var i = 0; roundAmmount > i; i++)
			{
				int winValue = CalculateWinner(self.GetChoice(), computer.GetChoice());
				UpdateScore(self, computer, winValue);
			}
			
			Console.WriteLine("\nFinal Score");
			Console.WriteLine("Player: "); self.DisplayScore();
			Console.WriteLine("Computer: "); computer.DisplayScore();

			return;
		}

		private void UpdateScore(Player p1, Player p2, int winValue)
		{
			if (winValue == 0)
			{
				Console.WriteLine("You Lost The Round");
				p2.score++;
			}
			else if (winValue == 1)
			{
				Console.WriteLine("You Won The Round");
				p1.score++;
			}
			else
			{
				Console.WriteLine("The Round was a draw");
			}
		}

		private int CalculateWinner(string c1, string c2)
		{
			Console.WriteLine($"Computer Chose {c2}");
			if (c1 == "rock" && c2 == "paper" || c1 == "paper" && c2 == "rock" || c1 == "scissors" && c2 == "rock")
			{
				//C1 Wins
				return 1;
			}
			else if (c1 == "rock" && c2 == "rock" || c1 == "paper" && c2 == "paper" || c1 == "scissors" && c2 == "scissors")
			{
				//Draw
				return 2;
			}
			else
			{
				//C1 Lost
				return 0;

			}
		}



	}
}
