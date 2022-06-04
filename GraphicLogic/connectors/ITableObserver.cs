

public interface ITableObserver:IObserver<IKey>
{
    void GetSpaces(int spacesnumb);
    void Update(IKey key,int space);
}