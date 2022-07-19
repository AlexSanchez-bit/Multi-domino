public class RobaitoPlayer : IPlayer
{
    //decorador para agregar a cualquier player las reglas del robaito
    IPlayer Player;
    
    List<IKey> hand;
    public static Stack<IKey> list_of_keys;//lista estatica de las fichas remanentes todos los jugadores con el decorador observaran la misma lista

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
    private bool HaveSteal(ITable table) //para saber si tiene que robar fichas
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
    private void Steal(ITable table)//roba una ficha mientras no tenga jugadas
    {
        if(!HaveSteal(table))return;
        List<IKey> hand =  new List<IKey>();
        while(HaveSteal(table)){
            var stealed_key  = RobaitoPlayer.list_of_keys.Pop();            
            hand.Add(stealed_key);
            if(table.ValidPlay(stealed_key))break;
        }        
            Player.SetData(hand);
        
    }  

    public void SimulateRound(ITable table)
    {
        Player.SimulateRound(table);
            Steal(table);
    }
}
