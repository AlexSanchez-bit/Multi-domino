using System;

public class Face<T>
{

 public T Face_value{get;private set;}
 public Face(T representation)
 {
	 this.Face_value = representation;
 }


}
