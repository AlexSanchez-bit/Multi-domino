public interface IPlayerSelector:IPlayerChanged,IRule //interfaz que representa al pasador de turnos
{

    void SetPlayerList(IEnumerable<IPlayer> player_list);//inicializa la lista de jugadores
    IPlayer GetNextPlayer();//devuelve el proximo jugador 

}
