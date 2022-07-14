
using System.IO;

public class Program{

      public static void Main(string[] args)
      {

            ConfigFile cf;
            string parent_directory="./SavedGames";
            var games = Directory.GetFiles(parent_directory);
            int option=0;
            do{
            Console.Clear();
            for(int i=0;i<games.Length;i++)
            {
                  var name = games[i].Split("/");
                  games[i]=name[name.Length-1];
                  Console.WriteLine("{0}-jugar {1}",i+1,games[i]);
            }
            Console.WriteLine("s-salir");
            Console.Write("seleccione una opcion:  ");
          var opt=Console.ReadLine();          
           if(opt=="s" || opt=="S")return;
           else 
           {
                 var to_play=int.Parse(opt)-1;
                 cf= new ConfigFile(games[to_play],"./SavedGames");
                 break;
          }
            }while(option==0);

var game= new GameBuilder(cf);
var players=new (string,string)[]{("juan","Random"),("julian","BotaGorda"),("pedro","Euristic Player")};
var player_list =new PlayerListBuilder(players,game); 
var screen = new ScreenPrinter();
     game.ConnectGame(screen); 
var manager = game.BuildGame(player_list.GetPlayers(),Dispensers.NormalDispenser,5);
var mainThread = new Thread(()=>{
      var winner=manager.SimulateGame();
      Console.Clear();
      Console.WriteLine(winner.GetIdentifier());
});
mainThread.Start();
screen.Start();
mainThread.Join();
 }
}
