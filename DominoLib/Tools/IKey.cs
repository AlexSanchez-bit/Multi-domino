public interface IKey
{
    IFace GetFace(int i);
    IEnumerable<IFace> GetAllFaces();       
    bool FitWith(IKey other);
    int GetValue();
}