


public class GameBuilder
{
    
    Manager juego;
      public ITable game_board{get;private set;}
       public IWinCondition win_condition{get;private set;}
       public IPlayerSelector player_selector{get;private set;}
       public IKeyGenerator keyset{get;private set;}

    public GameBuilder(ConfigFile cf)
    {
        //tableros
        if(cf.GameTable=="Normal")
        {
            game_board=new NormalTable();
        }
         if(cf.GameTable=="Longana")
        {
            game_board=new LonganaTable();
        }
     if(cf.GameTable=="multiplo de 5")
        {
            game_board=new Multp5Table();
        }
//fichas
        if(cf.Keyset=="Doble 9")
        {
            keyset= new NormalGenerator();
        }
        //selectors
        if(cf.PlayerSelector=="Ordenado")
        {
            player_selector= new NormalPlayerSelector();
        }
        if(cf.PlayerSelector=="Aleatorio")
        {
            player_selector= new RandomSelector();
        }
        //winconditions
        if(cf.WinCondition=="Normal")
        {
            win_condition= new GeneralWinCondition(); 
        }
        if(cf.WinCondition=="Torneo")
        {
            win_condition= new TournamentWinCondition(); 
        }
         if(cf.WinCondition=="multiplo de 5")
        {
            win_condition= new Multp5WinCondition(); 
            player_selector.attach((IPlayerChangedObserver)win_condition);
        }
    }

    public void ConnectGame(IScreen graphic_interface)
    {
        game_board.attach(graphic_interface);
        win_condition.attach(graphic_interface);
        player_selector.attach(graphic_interface);
    }

    public Manager BuildGame(IEnumerable<IPlayer> players,Action<IPlayer,IEnumerable<IKey>> dispenser )
    {
        juego=new Manager(game_board,players,win_condition,player_selector,keyset);
        juego.InitializeGame(dispenser);
            return juego;
    }
}


