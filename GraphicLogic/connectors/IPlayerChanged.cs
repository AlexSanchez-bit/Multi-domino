public interface IPlayerChanged : IObservable<IPlayerChangedObserver,IEvent<IPlayer>>
{

void notify(IPlayer current);

}