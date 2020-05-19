using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Client
{
    class MainMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("How many rounds do you want to play?");
            int RoundAmount = 3;
            Player player = new Player();

            try
            {
                RoundAmount = Int32.Parse(player.GetInput());
            }
            catch { }




            Console.WriteLine("Do you want to play online? (Y/N)");

            if (player.GetInput() == "y")
            {
                Console.WriteLine("Not Implemented Yet Sorry");
                ShowMenu();
            }
            else
            {
                SoloGame g = new SoloGame();
                g.Start(RoundAmount);
            }

        }
    }
}
