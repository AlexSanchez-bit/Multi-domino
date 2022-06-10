var game= new GameBuilder(new ConfigFile(new string[2]));
var manager = game.BuildGame();
var screen = game.GetGraphicalInterface();
var mainThread = new Thread(()=>{
      var winner=manager.SimulateGame();
      Console.Clear();
      Console.WriteLine(winner.GetIdentifier());
});
mainThread.Start();
screen.Start();
mainThread.Join();



