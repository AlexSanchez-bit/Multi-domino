public interface IWinCondition<T>
{
    IPlayer<T> GetWinner();
    bool GameEnded(IEnumerable<IPlayer<T>> players , ITable<T> mesa);
}