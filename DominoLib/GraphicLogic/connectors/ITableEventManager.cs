

public interface ITableEventManager:IObservable<ITableObserver,KeyPlayedEvent>
{
   //evento para cuando se juege una ficha
   void notify(IKey key,int position);   
}
