

public interface ITableEventManager:IObservable<(IKey,int)>
{
   void notify(IKey key,int position);   
}