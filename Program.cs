// See https://aka.ms/new-console-template for more information
using System.Threading;

var basic_keyset = new LinkedList<IKey<int>>();//conjunto de fichas

for(int i=0;i<10;i++)
{
   for(int j=0;j<10;j++)
   {
      basic_keyset.AddLast(new RegularKey<int>(i,j));   
   } 
}


var table = new NormalTable<int>(basic_keyset);

var player1 = table.GetPlayerKeys();
var player2 = table.GetPlayerKeys();
var player3 = table.GetPlayerKeys();
var player4 = table.GetPlayerKeys();

bool game_finished = false;
int current_player=0;


while(!game_finished)
{
Console.Clear();
print_player_number(current_player+1);
switch(current_player)
{
    case 0:
       print_player_keys(player1);
       break;

       case 1:
       print_player_keys(player2);
       break;

       case 2:
       print_player_keys(player3);
       break;

       case 3:
       print_player_keys(player4);
       break;       
}
Marcar_Ficha(2,player1);
Thread.Sleep(1000);


}

void Marcar_Ficha(int numb,IEnumerable<IKey<int>> jugador)
{
    int screen_width = Console.WindowWidth;
int screen_height = Console.WindowHeight;
Console.SetCursorPosition((screen_width/2)-((jugador.Count()/2)*5)+(numb*4)+1,screen_height-4);
Console.Write("*");
}

void print_player_number(int number)
{
Console.SetCursorPosition(0,0);
Console.WriteLine("Turno del jugador: {0}",number);

}


void print_player_keys(IEnumerable<IKey<int>> jugador)
{

int screen_width = Console.WindowWidth;
int screen_height = Console.WindowHeight;


Console.SetCursorPosition((screen_width/2)-((jugador.Count()/2)*5),screen_height-3);
    foreach(var key in jugador)
    {
        Console.Write("[{0}|{1}]",key.GetFace(0).Face_value,key.GetFace(1).Face_value);
    }
    Console.WriteLine();

}