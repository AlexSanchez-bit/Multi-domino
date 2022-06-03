

public class GeneralWinCondition : IWinCondition
{
    IPlayer winner;
    int higherScore=int.MinValue;

    public GeneralWinCondition()
    {
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
                return true;
            }

            if(HasLeftPlays(a,mesa))
            {
              Console.WriteLine("aun se puede jugar");
                return false;
            }
            Console.WriteLine("{0} no le quedan jugadas",a.GetIdentifier());
            var aux = PlayerHandValue(a);
            if(aux>=higherScore)
            {
                higherScore=aux;
                winner=a;
            }

        }
         Console.WriteLine("ya nadie tuvo jugadas");
        return false;       
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
}