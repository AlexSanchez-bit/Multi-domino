


public class EuristicPlayer : IPlayer,IPlayerChangedObserver
{
    //jugador euristico (cuenta cuantas veces se pasa alguien con una cara y juega en consecuencia)
    //para esto implementa el observer de cuando se cambian los turnos

    string name;
    List<IKey> hand;
    List<IFace> PassKeys;
    IPlayer Last_in_play;
    ITable board;
    int Cantidad_Fichas;
    public EuristicPlayer(string name)
    {
        this.name=name;
        hand=new List<IKey>();
        Last_in_play = null;
         PassKeys =  new List<IFace>();
    }
    public async void Play(ITable board)
    {
        List<IKey> validplays =  new List<IKey>();
        if(board == null)
        {
        this.board = board;  
        }
        IKey bestKey = null; 
        foreach(var a in this.GetKeys())
        {
            if(board.ValidPlay(a))
            {
                validplays.Add(a);
            }
        }
        foreach(var a in validplays)
        {
            if(PassKeys != null)
            {
                foreach(var item in PassKeys)
                {
                    if(item == a.GetFace(0) || item == a.GetFace(1))
                    {
                        bestKey = a;
                    }
                }
            }
        }
        if(bestKey != null && this.GetKeys().Contains(bestKey))
        {
        board.PlayKey(bestKey);
        }
        board.PlayKey(validplays[0]);

    }
    public string GetIdentifier()
    {
        return name;
    }

    public IEnumerable<IKey> GetKeys()
    {
      return this.hand;
    }

    public void SetData(IEnumerable<IKey> player_hand)
    {
       foreach(var a in player_hand)
       {
           hand.Add(a);
       }
    }

    public void SimulateRound(ITable table)
    {
        foreach(var a in hand)
        {
            if(table.ValidPlay(a))
            {
                table.PlayKey(a);
                hand.Remove(a);
                Thread.Sleep(1555);
                return;
            }
        }
    }

    //update que se llama cuando se cambia un turno
    public void Update(IEvent<IPlayer> eventinfo)
    {
         var actual = eventinfo.GetEventData();
         if(Last_in_play == null)
         {
             Last_in_play = actual;
             Cantidad_Fichas = actual.GetKeys().Count();
         }         
         if(Last_in_play.Equals(actual))
         {
             return;
         }else if(Cantidad_Fichas >= Last_in_play.GetKeys().Count() && board!=null)
         {
             foreach(var a in board.CurrentFaces())
             {
                 PassKeys.Add(a);
             }
         }
         Last_in_play = actual;
         Cantidad_Fichas = actual.GetKeys().Count();
    }
}
