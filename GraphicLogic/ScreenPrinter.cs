public class ScreenPrinter:ITableObserver ,IPlayerChangedObserver,IWinnerObserver
{


    List<IFace>[] game_board;    
    public ScreenPrinter()
    {        
    }

    public void Start()
    {
         while(true)
        {
            Console.Clear();
            PrintTable();
            Thread.Sleep(1000);
        }
    }
    
    public void PrintTable()
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        int index=0;
        foreach(var a in game_board ){
        Console.SetCursorPosition(0,height/2+index);
          foreach(var b in a)
          {
              Console.Write(b.GetRepresentation());
          }
          index++;
        }
        Console.SetCursorPosition(0,0);
    }



    public void PrintPlayer(IPlayer player)
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;
        Console.WriteLine("turno de : {0}",player.GetIdentifier()); 
        var keyset = player.GetKeys();
        Console.SetCursorPosition((width/2)-(keyset.Count()*7)/2,height-2);
        foreach(var a in keyset)
        {
           PrintHorizontalKey(a);           
        }
        Console.SetCursorPosition(0,0);
    }
   
   private void PrintVerticalKey(IKey key,bool up=false)
   {
        foreach(var b in key.GetAllFaces()){
            var coord_ant = Console.GetCursorPosition();
              Console.Write(b.GetRepresentation());              
            Console.SetCursorPosition(coord_ant.Item1,coord_ant.Item2+(up?-1:1));
         }
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
        var index = eventinfo.GetEventData().Item2-1;
        if(game_board.All((elem)=>elem.Count()==0))
        {
             foreach(var a in game_board)
             {
                 foreach(var b in key.GetAllFaces())
                     a.Add(b);
             }
        }else
        {
            var faces = key.GetAllFaces();
            foreach(var a in game_board)
            {
                if(faces.Any((elem)=>elem.Equals(a.Last())||elem.Equals(a.Last())))
                {
                    if(key.GetFace(0).Equals(a.Last()))
                    {
                        foreach(var i in faces)
                            a.Add(i);
                    }   
                    else
                    {
                        for(int i=faces.Count()-1 ;i>=0;i--)
                        {
                            a.Add(key.GetFace(i));
                        }
                        
                    }
                    return;
                }
            }
        }
           
    }


    public void Update(IEvent<IPlayer> eventinfo)
    {       
        this.PrintPlayer(eventinfo.GetEventData());
    }


     public void Update(IPlayer eventinfo)
    {       
        Console.WriteLine(eventinfo.GetIdentifier());
    }



    public void SetSpaces(int spacesnumb)
    {
       game_board=new List<IFace>[spacesnumb];
        for(int i=0;i<spacesnumb;i++)
        {
            game_board[i]=new List<IFace>();
        }
    }

    #endregion endImplementors
}
