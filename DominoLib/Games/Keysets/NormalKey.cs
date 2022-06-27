

public class NormalKey : IKey
{

    IFace[] faces;

    public bool Equals(IKey other)
    {
        return other.GetAllFaces().All((elem)=>elem.Equals(faces[0])||elem.Equals(faces[1]));
    }
    public NormalKey(int sideA,int sideB)
    {
         faces = new NumericFace[2];
         faces[0]=new NumericFace(sideA);
         faces[1] = new NumericFace(sideB);
    }
    public IEnumerable<IFace> GetAllFaces()
    {
        return faces;
    }

    public IFace GetFace(int i)
    {
      if(i< faces.Length)return faces[i];

      throw new Exception("error de indexacion");
    }

    public int GetValue()
    {
       return faces[0].GetValue()+faces[1].GetValue();
    }

    public bool FitWith(IKey other)
    {
        foreach(var a in faces)
        {
            foreach(var b in other.GetAllFaces())
            {
                if(a.Equals(b))
                {
                    return true;
                }
            }
        }
        return false;
    }
}