public class PlayerListBuilder
{

    LinkedList<IPlayer> players;
    public PlayerListBuilder(IEnumerable<(string,string)> player_info) 
    {
        players=new LinkedList<IPlayer>();
            foreach(var a in player_info)
            {
                players.AddLast(BuildPlayer(a.Item1,a.Item2));
            }
    }  

    public IEnumerable<IPlayer> GetPlayers()
    {
        return players;
    }
    
    private IPlayer BuildPlayer(string name,string type)
    {
        if(type=="Random")
        {
            return new NormalPlayer(name);
        }
        if(type=="BotaGorda")
        {
            return new BFPlayer(name);
        }
        return new NormalPlayer(name);
    }
}
