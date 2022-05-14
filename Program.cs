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
int ficha_actual=0;
IEnumerable<IKey<int>> player_keys = player1;
while(!game_finished)
{
Console.Clear();
print_player_number(current_player+1);
switch(current_player)
{
    case 0:
        player_keys=player1;
       break;

       case 1:
        player_keys=player2;
       break;
       case 2:
        player_keys=player3;
            break;
       case 3:
         player_keys=player4;
       break;       
}
print_player_keys(player_keys);
Marcar_Ficha(ficha_actual,player_keys);
ImrimirAcciones();
var reading = Console.ReadKey();


int available_choices = get_valid_choices(table,player_keys);

if(available_choices==0)
{
    SendMessage("no tienes jugadas disponibles , pasando de turno");
     current_player=(current_player+1)%4;
     continue;
}

if(reading.KeyChar == 'a' ||  reading.KeyChar == 'A')
{
    ficha_actual= ((ficha_actual-1)+player_keys.Count())%player_keys.Count();
}
if(reading.KeyChar == 's' ||  reading.KeyChar == 'S')
{
    ficha_actual= ((ficha_actual+1)+player_keys.Count())%player_keys.Count();
}
if(reading.KeyChar == 'j' ||  reading.KeyChar == 'J')
{    
    IKey<int> ficha = player_keys.ElementAt(ficha_actual);  

    if(table.IsValid(ficha))
    {
        
        table.PlayKey(ficha);
         current_player=(current_player+1)%4;
         if(player_keys.Count()==0)game_finished=true;
           player_keys = player_keys.Where(elem=>elem!=ficha);
         continue;

    }else{
        SendMessage("Jugada no Valida");
    }
}
if(reading.KeyChar == 't' ||  reading.KeyChar == 'T')
{
    if(available_choices!=0)
    {
        SendMessage("aun quedan jugadas validas");
        continue;
    }
    current_player=(current_player+1)%4;
}
Thread.Sleep(1000/60);
}



int get_valid_choices(ITable<int> mesa , IEnumerable<IKey<int>> fichas)
{
    var jugadas = mesa.ValidKeys();
    if(jugadas.Count()==0)return 1;
    return fichas.Where(elem=> jugadas.Contains(elem.GetFace(0)) || jugadas.Contains(elem.GetFace(1))).Count();
}


void Marcar_Ficha(int numb,IEnumerable<IKey<int>> jugador)
{
    int screen_width = Console.WindowWidth;
int screen_height = Console.WindowHeight;
Console.SetCursorPosition(((screen_width/2)-((jugador.Count()/2)*5)+(numb*5))+2,screen_height-4);
Console.Write("*");
}

void SendMessage(string message)
{

    int screen_width = Console.WindowWidth;
int screen_height = Console.WindowHeight;
Console.SetCursorPosition((screen_width/2)-(message.Length/2),screen_height/2);
Console.BackgroundColor= ConsoleColor.DarkMagenta;
Console.ForegroundColor= ConsoleColor.DarkRed;
Console.WriteLine(message);
Console.ResetColor();
Thread.Sleep(3000);

}


void ImrimirAcciones(){
    Console.SetCursorPosition(0,Console.WindowHeight);
    Console.Write("[A]nterior ficha ");
     Console.Write("[S]iguiente ficha ");
     Console.Write("[J]ugar ficha actual ");
      Console.Write("[T]erminar turno ");
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