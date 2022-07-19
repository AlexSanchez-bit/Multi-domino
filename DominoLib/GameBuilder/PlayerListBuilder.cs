public class PlayerListBuilder
//clase que se encarga de construir a los jugadores
{

    LinkedList<IPlayer> players;
    public PlayerListBuilder(IEnumerable<(string,string)> player_info,GameBuilder game_data) 
    {
        //obtiene el nombre y tipo de cada jugador ademas de las reglas que se jugaran y construye la lista de jugadores 
        players=new LinkedList<IPlayer>();
            foreach(var a in player_info)
            {
                if(game_data.game_board.Name=="Mesa de cartas" || game_data.win_condition.Name=="Shangai")
                {
                players.AddLast(new ShangaiDecorator(BuildPlayer(a.Item1,a.Item2,game_data)));                
                continue;
                }
                if(game_data.win_condition.Name=="Robaito")
                {
                 
                players.AddLast(new RobaitoPlayer(BuildPlayer(a.Item1,a.Item2,game_data)));                
                continue;
                }
                players.AddLast(BuildPlayer(a.Item1,a.Item2,game_data));                
            }
            
    }  

    public IEnumerable<IPlayer> GetPlayers()
    {
        return players;
    }
    
    private IPlayer BuildPlayer(string name,string type,GameBuilder gb)
    {
        if(type=="Random")
        {
            return new NormalPlayer(name);
        }
        if(type=="BotaGorda")
        {
            return new BFPlayer(name);
        }
         if(type=="Euristic Player")
        {
            var player= new EuristicPlayer(name);            
            gb.player_selector.attach(player);
            return player;
        }
        return new NormalPlayer(name);
    }
}
