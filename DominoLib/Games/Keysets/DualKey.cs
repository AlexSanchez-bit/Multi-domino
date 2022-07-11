
public class DualKey : IKey
{
    IFace[] faces;

    public bool Equals(IKey other)
    {
        return other.GetAllFaces().Any((elem)=>elem.Equals(faces[0])||elem.Equals(faces[1]));
    }
    public DualKey(int sideA,int sideB)
    {
         faces = new ColorFace[2];
         faces[0]=new ColorFace(sideA);
         faces[1] = new ColorFace(sideB);
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
       return 1;
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