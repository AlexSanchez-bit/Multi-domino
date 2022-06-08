var game= new GameBuilder(new ConfigFile(new string[2]));
var manager = game.BuildGame();
var screen = game.GetGraphicalInterface();
var mainThread = new Thread(()=>{
for(int i=0;i<100;i++)
{
    manager.SimulateRound();
}
});
mainThread.Start();
screen.Start();
mainThread.Join();



