

public class NormalKey : IKey<int>
{

    int[] faces;

    public NormalKey(int faceA,int faceB)
    {
        faces=new int[2];
        faces[0]=faceA;
        faces[1]=faceB;
    }
    public IEnumerable<int> GetAllFaces()
    {
        return faces;
    }

    public int GetFace(int i)
    {
        if(i<faces.Length)
        {
            return faces[i];
        }
        throw new IndexOutOfRangeException(string.Format("cara invalida seleccionada en la ficha : {0}|{1}",faces[0],faces[1]));
    }

    public int GetValue()
    {
         return faces[0]+faces[1];
    }

    public bool Equals(IKey<int> key)
    {
        return key.GetFace(0)==this.GetFace(0) && key.GetFace(1)==this.GetFace(1);
    }
}