public interface IWinCondition:IWinnerEventManager,IRule//interfaz que describe la condicion de parada de un juego
{
    IPlayer GetWinner();//devuelve el ganador
    bool GameEnded(IEnumerable<IPlayer> players , ITable mesa);//dic si el juego termino
}
