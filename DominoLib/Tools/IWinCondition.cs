public interface IWinCondition:IWinnerEventManager
{
    IPlayer GetWinner();
    bool GameEnded(IEnumerable<IPlayer> players , ITable mesa);
}