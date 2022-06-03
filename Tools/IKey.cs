public interface IKey<T>
{
    T GetFace(int i);
    IEnumerable<T> GetAllFaces();
    int GetValue();
}