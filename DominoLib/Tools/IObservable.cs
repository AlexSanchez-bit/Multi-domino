
public interface IObservable<Observer,T> where Observer:IObserver<T> //implementacion del patron observer en especifico el observable
{
    void attach(Observer observer);//permite asociar el observable a su observador
    void dettach(Observer obsetver);//desasocia el observable de su observador

    void notify(T eventdata);//notifica al observador de un cambio de estado
}
