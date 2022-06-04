
public interface IObserver<T>
{
    void Update(IEvent<T> eventinfo);
}