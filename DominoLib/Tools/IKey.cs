public interface IKey
{
    IFace GetFace(int i);
    IEnumerable<IFace> GetAllFaces();
    int GetValue();
}