using System;

public class Player<T>:IPlayer<T>
{
   public  List<IKey<T>> Keyset;
        
    
    
    public Player(IEnumerable<IKey<T>> keyset)
    {
        this.Keyset =  new List<IKey<T>>();
        foreach(var item  in keyset)
        {
            this.Keyset.Add(item);
        }
    }
    public void Play(ITable<T> board)
    {
        foreach(var item in this.Keyset)
        {
            if(board.IsValid(item))
            {
                board.PlayKey(item);
                Keyset.RemoveAt(Keyset.IndexOf(item));
                 return;
            }
        }
    }
    public IEnumerable<IKey<T>> GetKeys()
    {
        return this.Keyset;
    }
}


