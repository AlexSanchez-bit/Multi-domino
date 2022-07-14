
public class CardGamePlayerSelector : IPlayerSelector,ITableObserver
{

    List<IPlayer> jugadores;
    LinkedList<IPlayerChangedObserver> observers;
    IPlayer lastPlayer;
    int last_player_count=0;

    IKey last_played;
    int index=0;
    bool inverted=false;
    bool familion=false;

    public CardGamePlayerSelector()
    {
        jugadores=new List<IPlayer>();
        observers = new LinkedList<IPlayerChangedObserver>();
    }

    public string Description => "pasa los turnos de acuerdo a las reglas del shangai o uno";

    public string Name => "Turnos juego de Cartas";

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
       lastPlayer=ret;        
       if(!inverted){
       index=(index+1+jugadores.Count)%jugadores.Count;
       }else{
  index=(index-1+jugadores.Count)%jugadores.Count;
       }
       
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

    public void SetSpaces(int spacesnumb)
    {        
    }

    public void Update(KeyPlayedEvent eventinfo)
    {
        last_played=eventinfo.GetEventData().Item1;
        if(last_played.GetValue()==11 || last_played.GetValue()==12)
        {
            inverted=!inverted;
        }
        if(last_played.GetValue()==7){
            familion=true;
            ShangaiDecorator.familion=true;
            last_player_count=lastPlayer.GetKeys().Count()+1;
        }
    }
}
