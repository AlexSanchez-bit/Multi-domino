
public interface IObservable<T>
{
    void attach(IObserver<T> observer);
    void dettach(IObserver<T> obsetver);

    void notify();
}