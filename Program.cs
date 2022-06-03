var winC = new GeneralWinCondition();
var Pselect = new NormalPlayerSelector();
var board = new NormalTable();
var player_list = new NormalPlayer[]{new NormalPlayer("arturo"),new NormalPlayer("maria")};//,new NormalPlayer("jose"),new NormalPlayer("bernard")};
var manager = new Manager(board,player_list,winC,Pselect,KeyGenerators.NormalGenerator);
var screen = new ScreenPrinter();
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

for(int i=0;i<5;i++){
  manager.SimulateRound();
  }

manager.SimulateGame();

Console.WriteLine("tablero");
screen.PrintTable(board);
Console.WriteLine("caras disponibles");
foreach(var face in board.CurrentFaces())
{
    Console.WriteLine(face.GetRepresentation());
}
Console.WriteLine("despues");

foreach(var player in player_list)
{
     screen.PrintPlayer(player);
}