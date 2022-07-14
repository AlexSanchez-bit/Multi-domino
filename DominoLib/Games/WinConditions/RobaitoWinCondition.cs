


public class RobaitoWinCondition : IWinCondition
{
    IPlayer winner;
    List<IWinnerObserver> observers;
    int minimalScore=int.MaxValue;

    string IRule.Description { get => "seleccion de ganador del robaito , gana el que se quede sin fichas o tenga menos puntos al quedarse el banco sin fichas"; }
    string IRule.Name { get => "Robaito"; }

    public RobaitoWinCondition()
    {
        observers= new List<IWinnerObserver>();
        winner = new NormalPlayer("error");
    }
    public bool GameEnded(IEnumerable<IPlayer> players, ITable mesa)
    {
        foreach(var a in players)
        {
            if(a.GetKeys().Count()==0)
            {
                winner=a;
                Console.WriteLine("se quedo sin fichas");
         notify(winner);
                return true;
            }

            if(HasLeftPlays(a,mesa))
            {
              Console.WriteLine("aun se puede jugar");
                return false;
            }
            var aux = PlayerHandValue(a);
            if(aux<=minimalScore)
            {
                minimalScore=aux;
                winner=a;
            }
        }
        if(RobaitoPlayer.list_of_keys.Count()==0){
           notify(winner);
           Console.WriteLine("se vacio el banco");
            return true;                   
         }
        return false;
    }

private int PlayerHandValue(IPlayer player)
{
    return player.GetKeys().Count();
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

    
}
