public class NumericFace : IFace
{
    int number;

    public NumericFace(int numb)
    {
        this.number=numb;
    }
    public bool Equals(IFace face)
    {
      return face.GetRepresentation() == this.GetRepresentation();
    }

    public string GetRepresentation()
    {
        return string.Format("[{0}]",number);
    }

    public int GetValue()
    {
        return number;
    }
}