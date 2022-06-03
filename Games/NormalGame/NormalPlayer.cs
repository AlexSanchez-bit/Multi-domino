


public class NormalPlayer<T> : IPlayer<T>
{

    string name;
    List<IKey<T>> hand;
    public NormalPlayer(string name)
    {
        name=name;
        hand=new List<IKey<T>>();
    }
    public string GetIdentifier()
    {
        return name;
    }

    public IEnumerable<IKey<T>> GetKeys()
    {
      return this.hand;
    }

    public void SetData(IEnumerable<IKey<T>> player_hand)
    {
       foreach(var a in player_hand)
       {
           hand.Add(a);
       }
    }

    public void SimulateRound(ITable<T> table)
    {
        foreach(var a in hand)
        {
            if(table.ValidPlay(a))
            {
                table.PlayKey(a);
                hand.Remove(a);
                return;
            }
        }
    }
}