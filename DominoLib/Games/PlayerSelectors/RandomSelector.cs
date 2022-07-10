


public class RandomSelector : IPlayerSelector
{

    List<IPlayer> jugadores;
    LinkedList<IPlayerChangedObserver> observers;
    int index=0;

    public RandomSelector()
    {
        jugadores=new List<IPlayer>();
        observers = new LinkedList<IPlayerChangedObserver>();
    }

    public string Description => "Cambia los jugadores de forma aleatoria";

    public string Name => "Aleatorio";

    public void attach(IPlayerChangedObserver observer)
    {
        observers.AddLast(observer);
    }

    public void dettach(IPlayerChangedObserver obsetver)
    {
        observers.Remove(obsetver);
    }

    public IPlayer GetNextPlayer()
    {
        var rand = new Random();
       var ret = jugadores[index];
       index= rand.Next(0,jugadores.Count());
       notify(new CustomEvent<IPlayer>(ret));
       return ret;
    }

    public void notify(IEvent<IPlayer> current)
    {
        foreach(var a in observers)
        {
            a.Update(current);
        }
    }

    public void notify()
    {
        throw new NotImplementedException();
    }

    public void SetPlayerList(IEnumerable<IPlayer> player_list)
    {
       foreach(var a in player_list)
       {
           jugadores.Add(a);
       }
    }
   
}
