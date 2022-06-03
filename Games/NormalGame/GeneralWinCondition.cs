

public class GeneralWinCondition<T> : IWinCondition<T>
{
    IPlayer<T> winner;
    int higherScore=int.MinValue;
    public bool GameEnded(IEnumerable<IPlayer<T>> players, ITable<T> mesa)
    {
        foreach(var a in players)
        {
            if(a.GetKeys().Count()==0)
            {
                winner=a;
                return true;
            }

            if(HasLeftPlays(a,mesa))return false;
            
            var aux = PlayerHandValue(a);
            if(aux<=higherScore)
            {
                higherScore=aux;
                winner=a;
            }

        }
        return true;       
    }

private int PlayerHandValue(IPlayer<T> player)
{
    int val=0;
    foreach(var a in player.GetKeys())
    {
        val+=a.GetValue();
    }
    return val;
}
    private bool HasLeftPlays(IPlayer<T> player,ITable<T> board)
    {
        foreach(var a in player.GetKeys())
        {
            if(board.ValidPlay(a))return true;
        }
        return false;
    }

    public IPlayer<T> GetWinner()
    {
        return winner;
    }
}