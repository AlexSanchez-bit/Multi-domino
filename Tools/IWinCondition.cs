public interface IWinCondition
{
    IPlayer GetWinner();
    bool GameEnded(IEnumerable<IPlayer> players , ITable mesa);
}