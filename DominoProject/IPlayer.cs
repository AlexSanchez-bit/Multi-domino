using System;

public interface IPlayer<T>
{
   IEnumerable<IKey<T>> GetKeys();
   
   void Play(ITable<T> table)
   {

   }
   
}