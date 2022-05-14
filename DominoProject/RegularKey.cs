using System;

public class RegularKey<T>:IKey<T>
{
    Face<T>[] faces;

    public RegularKey(T face1,T face2)
    {
       faces = new Face<T>[2];
       faces[0] = new Face<T>(face1);
       faces[1] = new Face<T>(face2);
    }
    public IEnumerable<Face<T>> GetFaces()
    {
            return faces;
    }
	public Face<T> GetFace(int face)
    {    
        return this.faces[face];
    }
}
