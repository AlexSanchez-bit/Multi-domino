public interface IPlayerSelector:IPlayerChanged
{

    void SetPlayerList(IEnumerable<IPlayer> player_list);
    IPlayer GetNextPlayer();

}