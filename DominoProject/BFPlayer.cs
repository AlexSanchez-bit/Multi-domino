public class BFPlayer<T> : IPlayer<T>
{
    public  List<IKey<T>> Keyset;
    IComparer<IKey<T>> comparer;    
    List<IKey<T>> ValidKeys;
    
    public BFPlayer(IEnumerable<IKey<T>> keyset,IComparer<IKey<T>> comparer)
    {
        this.Keyset =  new List<IKey<T>>();
        foreach(var item  in keyset)
        {
            this.Keyset.Add(item);
        }
        this.comparer =  comparer;
    }
    public void Play(ITable<T> board)
    {
        ValidKeys =  new List<IKey<T>>();
        IKey<T> bestKey = null;
        foreach(var item in Keyset)
        {
            if(board.IsValid(item))
            {
                ValidKeys.Add(item);
            }
        }
        foreach(var item in ValidKeys)
        {
            if(bestKey ==null)
            {
                bestKey = item;
            }
            else
            {
                if(comparer.Compare(bestKey,item) > 0)
                {
                    bestKey = item;
                }
            }

        }
        board.PlayKey(bestKey);
        Keyset.RemoveAt(Keyset.IndexOf(bestKey));
                 return;

    }
    public IEnumerable<IKey<T>> GetKeys()
    {
        return this.Keyset;
    }
}