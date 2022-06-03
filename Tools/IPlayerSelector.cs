public interface IPlayerSelector<T>
{

    void SetPlayerList(IEnumerable<IPlayer<T>> player_list);
    IPlayer<T> GetNextPlayer();

}