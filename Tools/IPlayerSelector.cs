public interface IPlayerSelector
{

    void SetPlayerList(IEnumerable<IPlayer> player_list);
    IPlayer GetNextPlayer();

}