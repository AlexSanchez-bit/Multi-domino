


class NormalPlayerSelector<T> : IPlayerSelector<T>
{

    List<IPlayer<T>> jugadores;

    public NormalPlayerSelector()
    {
        jugadores=new List<IPlayer<T>>();
    }
    int index=0;
    public IPlayer<T> GetNextPlayer()
    {
       var ret = jugadores[index];
       index=(index+1)%jugadores.Count;
       return ret;
    }

    public void SetPlayerList(IEnumerable<IPlayer<T>> player_list)
    {
       foreach(var a in player_list)
       {
           jugadores.Add(a);
       }
    }
}