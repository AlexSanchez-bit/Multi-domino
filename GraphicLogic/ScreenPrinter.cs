public class ScreenPrinter:ITableObserver ,IPlayerChangedObserver
{


    List<IKey>[] game_board;    
    public ScreenPrinter()
    {         
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
    
    public void PrintTable()
    {
       
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
    }
   
   private void PrintVerticalKey(IKey key)
   {

   }

   public void PrintHorizontalKey(IKey key)
   {
        foreach(var b in key.GetAllFaces())
              Console.Write(b.GetRepresentation());
     Console.Write(" ");  
   }


#region implementations
    public void Update(KeyPlayedEvent eventinfo)
    {
          var key = eventinfo.GetEventData().Item1;
        var index = eventinfo.GetEventData().Item2;
        if(game_board.All((elem)=>elem.Count()==0))
        {
             foreach(var a in game_board)
             {
               a.Add(key);
             }
        }else
        {
            game_board[index].Add(key);
        }
           
    }


    public void Update(IEvent<IPlayer> eventinfo)
    {       
        this.PrintPlayer(eventinfo.GetEventData());
    }


  

    public void SetSpaces(int spacesnumb)
    {
       game_board=new List<IKey>[spacesnumb];
        for(int i=0;i<spacesnumb;i++)
        {
            game_board[i]=new List<IKey>();
        }
    }

    #endregion endImplementors
}