var screen = new ScreenPrinter();
var winC = new GeneralWinCondition();
var Pselect = new NormalPlayerSelector();
//Pselect.attach(screen);
var board = new NormalTable();
board.attach(screen);
var player_list = new NormalPlayer[]{new NormalPlayer("arturo"),new NormalPlayer("maria"),new NormalPlayer("jose"),new NormalPlayer("bernard")};
var manager = new Manager(board,player_list,winC,Pselect,KeyGenerators.NormalGenerator);
var selected=new List<IKey>();
manager.InitializeGame((player,fichas)=>{
    int cantidad=0;
    var data = new IKey[10];
        foreach(var a in fichas)
        {
            if(selected.Contains(a))continue;
            if(cantidad==10)break;
            data[cantidad++]=a;  
            selected.Add(a);              
        }
        player.SetData(data);      
        screen.PrintPlayer(player);
});
var mainThread = new Thread(()=>{
for(int i=0;i<100;i++)
{
    manager.SimulateRound();
}
});
mainThread.Start();
screen.Start();
mainThread.Join();
screen.PrintPlayer(winC.GetWinner());
screen.PrintTable(board);


