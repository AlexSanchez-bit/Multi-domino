using System;
using System.Collections.Generic;
public interface IKey<T>
{
	IEnumerable<Face<T>> GetFaces();	
	Face<T> GetFace(int face);    
}
