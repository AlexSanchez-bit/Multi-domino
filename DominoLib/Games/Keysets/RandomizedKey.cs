public class RandomizedKey : IKey
{
  
    IFace[] faces;

    public bool Equals(IKey other)
    {
        return other.GetAllFaces().Any((elem)=>elem.Equals(faces[0])||elem.Equals(faces[1]));
    }
    public RandomizedKey()
    {
         faces = new IFace[2];
        var rand = new Random();

        faces[0]=get_face(rand.Next(1,4));
          faces[1]=get_face(rand.Next(1,4));
    }

    private IFace get_face(int numb)
    {
        IFace ret = null;
        var rand = new Random();
        switch(numb)
        {
            case 1:
               ret = new NumericFace(rand.Next(0,10));
               break;
               case 2:
               ret=new ColorFace(rand.Next(1,6));
               break;
               case 3:
               ret = new CardFace(rand.Next(1,11),rand.Next(1,5));
               break;
        }
        return ret;
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

