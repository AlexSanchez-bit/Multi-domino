public interface IPlayerChanged : IObservable<IPlayerChangedObserver,IEvent<IPlayer>>
{
    //Observable especializado para cuando se cambie el jugador el unico objetivo de esta interfaz es dar un nombre mas comodo de usar


}
