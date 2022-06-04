

public interface ITableObserver:IObserver<(IKey,int)>
{
    void GetSpaces(int spacesnumb);
    void Update(IEvent<(IKey,int)> eventinfo);
}