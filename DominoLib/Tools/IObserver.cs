
public interface IObserver<T> // observador se asocia a un observabe y responde ante los cambios de estado
{
    void Update(T eventinfo);//actualiza el estado del observador cuando el observable lo notifique
}
