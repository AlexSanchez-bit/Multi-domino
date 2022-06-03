
public interface ITable<T>
{
    bool ValidPlay(IKey<T> key);
    IEnumerable<T> CurrentFaces();
    IEnumerable<IKey<T>> OnTableKeys();
    void PlayKey(IKey<T> key);    

    void Reset();
 }