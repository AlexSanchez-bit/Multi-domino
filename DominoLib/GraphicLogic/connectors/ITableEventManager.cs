

public interface ITableEventManager:IObservable<ITableObserver,KeyPlayedEvent>
{
   void notify(IKey key,int position);   
}