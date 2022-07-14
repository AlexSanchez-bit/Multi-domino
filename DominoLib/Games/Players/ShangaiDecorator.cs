
public class ShangaiDecorator : IPlayer
{
    IPlayer Player;
    IPlayer internal_player;
    public static int parobar=0; 
    public static bool familion=false;
    List<IKey> hand;
    public ShangaiDecorator(IPlayer player)
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

    public void SimulateRound(ITable table)
    {
        if(!can_play(table))
        {
            var hand = new List<IKey>();

            if(RobaitoPlayer.list_of_keys.Count()>0){
            hand.Add(RobaitoPlayer.list_of_keys.Pop());
            }           
            SetData(hand);
            return;
        }
        if(parobar!=0)
        {
            if(RobaitoPlayer.list_of_keys.Count()!=0){
            var hand =new List<IKey>();
            for(int i=0;i<parobar+1;i++)
            {
                hand.Add(RobaitoPlayer.list_of_keys.Pop());
                return;
            }
            SetData(hand);
                }
            parobar=0;
        }
        if(familion)
        {
            while(can_play(table))
            {
                Player.SimulateRound(table);
            }
            familion=false;
            return;
        }
    
        Player.SimulateRound(table);
    }

    bool can_play(ITable table)
    {
        foreach(var a in GetKeys())
        {
            if(table.ValidPlay(a))return true;
        }
        return false;
    }
}
