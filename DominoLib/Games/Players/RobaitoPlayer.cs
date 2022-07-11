public class RobaitoPlayer : IPlayer
{
    IPlayer Player;
    
    List<IKey> hand;
    public static Stack<IKey> list_of_keys;

    public RobaitoPlayer(IPlayer player)
    {        
        hand=new List<IKey>();
        Player = player;    
    }
    public string GetIdentifier()
    {
        return Player.GetIdentifier();
    }

    public IEnumerable<IKey> GetKeys()
    {
      return Player.GetKeys();
    }

    public void SetData(IEnumerable<IKey> player_hand)
    {
       Player.SetData(player_hand);
    }
    private bool HaveSteal(ITable table)
    {
        if(RobaitoPlayer.list_of_keys.Count()==0)return false;
        foreach(var a in Player.GetKeys())
        {
           if(table.ValidPlay(a))
           {
               return false;
           }
        }
        return true;
    } 
    private void Steal(ITable table)
    {
        if(!HaveSteal(table))return;
        List<IKey> hand =  Player.GetKeys().ToList();
        while(HaveSteal(table)){
            var stealed_key  = RobaitoPlayer.list_of_keys.Pop();
            hand.Add(stealed_key);
        }
            Player.SetData(hand);
        
    }  

    public void SimulateRound(ITable table)
    {
            Steal(table);
        Player.SimulateRound(table);
    }
}
