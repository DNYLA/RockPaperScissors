using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPS.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Player ply = new Player();

            Server.Connect sConnect = new Server.Connect();
            if (!sConnect.InitializeConnection(out ply.clientSock))
            {
                Console.WriteLine("Could Not Connect To Server...");
                //return;
            }

            ply.UpdateMessenger();
            MainMenu m = new MainMenu(ply);
        }
    }
}
