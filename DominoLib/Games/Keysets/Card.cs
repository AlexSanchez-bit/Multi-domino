

public class Card : IKey
{

IFace face;
    public Card(IFace face)
    {
        this.face=face;
    }
    public bool FitWith(IKey other)
    {
        return other.GetAllFaces().Any(elem=>elem.Equals(face));
    }

    public IEnumerable<IFace> GetAllFaces()
    {
        yield return face;
    }

    public IFace GetFace(int i)
    {
        return face;
    }

    public int GetValue()
    {
        return face.GetValue();
    }
}