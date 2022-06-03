


class NormalPlayerSelector : IPlayerSelector
{

    List<IPlayer> jugadores;

    public NormalPlayerSelector()
    {
        jugadores=new List<IPlayer>();
    }
    int index=0;
    public IPlayer GetNextPlayer()
    {
       var ret = jugadores[index];
       index=(index+1+jugadores.Count)%jugadores.Count;
       return ret;
    }

    public void SetPlayerList(IEnumerable<IPlayer> player_list)
    {
       foreach(var a in player_list)
       {
           jugadores.Add(a);
       }
    }
}