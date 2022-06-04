public class ScreenPrinter:ITableObserver
{


    string game_board;
    public ScreenPrinter()
    {  
        game_board="";       
    }

    public void Start()
    {
         while(true)
        {
            Console.Clear();
            foreach(var a in game_board)
            {Console.Write(a);}           
            Thread.Sleep(1000);
        }
    }
    
    public void PrintTable(ITable board)
    {
        int screensize=Console.WindowWidth-10;
        foreach(var key in board.OnTableKeys())
        {
            PrintHorizontalKey(key);
        }
    }
    public void PrintPlayer(IPlayer player)
    {
        Console.WriteLine(player.GetIdentifier()); 
        var keyset = player.GetKeys();
        foreach(var a in keyset)
        {
           PrintHorizontalKey(a);           
        }
       Console.WriteLine(" "); 
    }
   
   private void PrintVerticalKey(IKey key)
   {

   }

   public static void PrintHorizontalKey(IKey key)
   {
        foreach(var b in key.GetAllFaces())
              Console.Write(b.GetRepresentation());
     Console.Write(" ");  
   }

    public void Update(IEvent<IKey> eventinfo)
    {
        var data = eventinfo.GetEventData();
        foreach(var a in data.GetAllFaces())
        {           
            game_board+=a.GetRepresentation();

        }      
    }
}