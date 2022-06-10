


class NormalPlayerSelector : IPlayerSelector ,IPlayerChanged
{

    List<IPlayer> jugadores;
    LinkedList<IPlayerChangedObserver> observers;
    int index=0;

    public NormalPlayerSelector()
    {
        jugadores=new List<IPlayer>();
        observers = new LinkedList<IPlayerChangedObserver>();
    }

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
       var ret = jugadores[index];
       index=(index+1+jugadores.Count)%jugadores.Count;
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