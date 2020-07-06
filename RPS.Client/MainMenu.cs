using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Client
{
    class MainMenu
    {
        private Player player;
        public MainMenu(Player ply)
        {
            player = ply;
            ShowMenu();
        }

        public void ShowMenu()
        {
            Console.WriteLine("How many rounds do you want to play?");
            int RoundAmount = 3;

            try
            {
                RoundAmount = Int32.Parse(player.GetInput());
            }
            catch { }




            Console.WriteLine("Do you want to play online? (Y/N)");

            if (player.GetInput() == "y")
            {
                MultiplayerGame mpGame = new MultiplayerGame(player);
                mpGame.ConnectLobby();
            }
            else
            {
                //SoloGame g = new SoloGame(player);
                //g.Start(RoundAmount);
            }

        }
    }
}
