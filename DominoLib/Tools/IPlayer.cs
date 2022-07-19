public interface IPlayer //representacion abstracta de un jugador
{
    string GetIdentifier(); //devuelve el identificador "nombre" del jugador
    void SimulateRound(ITable table);//simula una ronda del jugador

    IEnumerable<IKey> GetKeys();//devuelve las fichas del jugador
    void SetData(IEnumerable<IKey> player_hand);// agrega las fichas a la mano del jugador


}
