public class PlayerListBuilder
{

    LinkedList<IPlayer> players;
    public PlayerListBuilder(IEnumerable<(string,string)> player_info,GameBuilder game_data) 
    {
        players=new LinkedList<IPlayer>();
            foreach(var a in player_info)
            {
                if(game_data.game_board.Name=="Mesa de cartas" || game_data.win_condition.Name=="Shangai")
                {
                players.AddLast(new ShangaiDecorator(BuildPlayer(a.Item1,a.Item2)));                
                continue;
                }
                if(game_data.win_condition.Name=="Robaito")
                {
                 
                players.AddLast(new RobaitoPlayer(BuildPlayer(a.Item1,a.Item2)));                
                continue;
                }
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
