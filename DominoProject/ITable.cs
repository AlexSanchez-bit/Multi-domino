using System;
using System.Collections.Generic;
public interface ITable<T>
{
	   IEnumerable<Face<T>> ValidKeys();
	   void PlayKey(IKey<T> key);

	   bool IsValid(IKey<T> key);

	   IEnumerable<IKey<T>> OnTableKeys();
       
	   IEnumerable<IKey<T>> GetPlayerKeys();

	   IComparer<T> comparer();

}
