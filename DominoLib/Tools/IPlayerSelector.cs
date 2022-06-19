public interface IPlayerSelector:IPlayerChanged,IRule
{

    void SetPlayerList(IEnumerable<IPlayer> player_list);
    IPlayer GetNextPlayer();

}