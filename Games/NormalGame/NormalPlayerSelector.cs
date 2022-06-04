


class NormalPlayerSelector : IPlayerSelector ,IPlayerChanged
{

    List<IPlayer> jugadores;
    LinkedList<IObserver<IPlayer>> observers;
    int index=0;

    public NormalPlayerSelector()
    {
        jugadores=new List<IPlayer>();
        observers = new LinkedList<IObserver<IPlayer>>();
    }

    public IPlayer GetNextPlayer()
    {
       var ret = jugadores[index];
       index=(index+1+jugadores.Count)%jugadores.Count;
       notify(ret);
       return ret;
    }

    public void SetPlayerList(IEnumerable<IPlayer> player_list)
    {
       foreach(var a in player_list)
       {
           jugadores.Add(a);
       }
    }

    public void attach(IObserver<IPlayer> observer)
    {
        observers.AddLast(observer);
    }

    public void dettach(IObserver<IPlayer> obsetver)
    {
     observers.Remove(obsetver);
    }

    public void notify()
    {
       
    }

    public void notify(IPlayer current)
    {
         foreach(var a in observers)
        {
            a.Update(new CustomEvent<IPlayer>(current));
        }
    }
}