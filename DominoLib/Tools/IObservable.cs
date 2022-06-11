
public interface IObservable<Observer,T> where Observer:IObserver<T>
{
    void attach(Observer observer);
    void dettach(Observer obsetver);

    void notify(T eventdata);
}