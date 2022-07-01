public class Multp5Player : IPlayer
{
    string name;
    List<IKey> hand;
   public int score;
    public Multp5Player(string name)
    {
        this.name =  name;
        hand =  new List<IKey>();
        score = 0;
    }

    public string GetIdentifier()
    {
        return this.name;
    }

    public IEnumerable<IKey> GetKeys()
    {
        return this.hand;
    }

    public void SetData(IEnumerable<IKey> player_hand)
    {
        foreach(var a in player_hand)
        {
            hand.Add(a);
        }
    }

    public void SimulateRound(ITable table)
    {
        foreach(var a in hand)
        {
            if(table.ValidPlay(a))
            {
                table.PlayKey(a);
                hand.Remove(a);
                Thread.Sleep(1555);
                return;
            }
        }
    }
}