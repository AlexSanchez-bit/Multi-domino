

public interface ITableObserver:IObserver<KeyPlayedEvent>
{
    //observador para cuando se juege una ficha
    void SetSpaces(int spacesnumb);  
}
