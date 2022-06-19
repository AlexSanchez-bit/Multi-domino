
public class BFPlayer : IPlayer
{
    public  List<IKey> Keyset;
    string name;
    IComparer<IKey> comparer;    
    List<IKey> ValidKeys;
    
    public BFPlayer(string name)
    {
      
        this.name = name;
        Keyset = new List<IKey>();      
    }
    public void Play(ITable board)
    {
        ValidKeys =  new List<IKey>();
        IKey bestKey = null;
        foreach(var item in Keyset)
        {
            if(board.ValidPlay(item))
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
                if(bestKey.GetValue()<item.GetValue())
                {
                    bestKey = item;
                }
            }

        }
        board.PlayKey(bestKey);
        Keyset.RemoveAt(Keyset.IndexOf(bestKey));
                 return;

    }
    public IEnumerable<IKey> GetKeys()
    {
        return this.Keyset;
    }

    public string GetIdentifier()
    {
        return this.name;
    }

    public void SimulateRound(ITable table)
    {
       foreach(var a in Keyset)
        {
            if(table.ValidPlay(a))
            {
                table.PlayKey(a);
                Keyset.Remove(a);
                Thread.Sleep(1555);
                return;
            }
        }
    }

    public void SetData(IEnumerable<IKey> player_hand)
    {
        foreach(var a in player_hand)
        {
            Keyset.Add(a);
        }
        
    }
}
