public class Multp5WinCondition : IWinCondition,IPlayerChangedObserver
{
    IPlayer winner;
    List<IWinnerObserver> observers;
    int higherScore=int.MinValue;
    Dictionary<IPlayer,int> player_score;
    IPlayer Last_in_play;

    public string Description => "condicion de parada de los multiplos de 5";

    public string Name => "multiplo de 5";

    public Multp5WinCondition()
    {
        observers= new List<IWinnerObserver>();
        winner = new NormalPlayer("error");
        player_score =  new Dictionary<IPlayer, int>();
        Last_in_play = new NormalPlayer("error");
    }
    public bool GameEnded(IEnumerable<IPlayer> players, ITable mesa)
    {
        int score =0;
        foreach(var b in mesa.CurrentFaces())
        {
          score += b.GetValue();
        }
        if(score%5==0)
        {
           player_score[Last_in_play] = score;
        }
        foreach(var a in players)
        {
            if(a.GetKeys().Count()==0)
            {
                Winner(player_score);
            }

            if(HasLeftPlays(a,mesa))
            {
              Console.WriteLine("aun se puede jugar");
                return false;
            }
            
            Console.WriteLine("{0} no le quedan jugadas",a.GetIdentifier());
            var aux = PlayerHandValue(a);
           

        }
         notify(winner);
        return true;       
    }
    
 public void Winner(Dictionary<IPlayer,int> players)
 {
     int highvalue =0;
     foreach (var item in players)
     {
         if(highvalue < item.Value)
         {
             highvalue = item.Value;
             winner = item.Key;
         }
     }
     
 }
private int PlayerHandValue(IPlayer player)
{
    int val=0;
    foreach(var a in player.GetKeys())
    {
        val+=a.GetValue();
    }
    return val;
}
    private bool HasLeftPlays(IPlayer player,ITable board)
    {
        foreach(var a in player.GetKeys())
        {
            if(board.ValidPlay(a))return true;
        }
        return false;
    }

    public IPlayer GetWinner()
    {
        return winner;
    }

    public void attach(IWinnerObserver observer)
    {
        observers.Add(observer);
    }

    public void dettach(IWinnerObserver obsetver)
    {
        observers.Remove(obsetver);
    }

    public void notify(IPlayer eventdata)
    {
       foreach(var a in observers)
       {
           a.Update(eventdata);
       }
    }

    public void Update(IEvent<IPlayer> eventinfo)
    {
        Last_in_play = eventinfo.GetEventData();
    }
}
