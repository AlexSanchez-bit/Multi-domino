public interface IWinCondition:IWinnerEventManager,IRule
{
    IPlayer GetWinner();
    bool GameEnded(IEnumerable<IPlayer> players , ITable mesa);
}