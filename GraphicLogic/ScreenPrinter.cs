public class ScreenPrinter:ITableObserver,IPlayerChangedObserver
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
        Console.WriteLine("turno de :{0}",player.GetIdentifier()); 
        var keyset = player.GetKeys();
        foreach(var a in keyset)
        {
           PrintHorizontalKey(a);           
        }
       Console.WriteLine(" "); 
       Thread.Sleep(900);
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

    public void Update(IEvent<IPlayer> eventinfo)
    {       
        this.PrintPlayer(eventinfo.GetEventData());
    }

    public void GetSpaces(int spacesnumb)
    {
        throw new NotImplementedException();
    }

    public void Update(IEvent<(IKey, int)> eventinfo)
    {
        foreach(var a in eventinfo.GetEventData().Item1.GetAllFaces())
        {
            this.game_board+=a.GetRepresentation();
        }
    }
}