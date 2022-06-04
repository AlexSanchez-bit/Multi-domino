public interface IPlayerChanged : IObservable<IPlayer>
{

void notify(IPlayer current);

}