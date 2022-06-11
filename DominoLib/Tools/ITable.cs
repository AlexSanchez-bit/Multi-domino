
public interface ITable:ITableEventManager
{
    bool ValidPlay(IKey key);
    IEnumerable<IFace> CurrentFaces();
    IEnumerable<IKey> OnTableKeys();
    void PlayKey(IKey key);    

    void Reset();
 }