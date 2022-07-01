


public class GameBuilder
{
    
    Manager juego;

    public GameBuilder(ConfigFile cf)
    {

      public ITable game_board{get;private set;}
        IWinCondition win_condition{get;private set;}
        IPlayerSelector player_selector{get;private set;}
        IKeyGenerator keyset{get;private set;}

        if(cf.GameName=="Normal")
        {
            game_board=new NormalTable();
        }

        if(cf.Keyset=="Double9")
        {
            keyset= new NormalGenerator();
        }
        if(cf.PlayerSelector=="Ordered")
        {
            player_selector= new PlayerSelector();
        }
        if(cf.WinCondition=="NormalWinCondition")
        {
            win_condition= new GeneralWinCondition(); 
        }

    }

    public void ConnectGame(ScreenPrinter graphic_interface)
    {
        game_board.attach(graphic_interface);
        win_condition.attach(graphic_interface);
        player_selector.attach(graphic_interface);
    }

    public Manager BuildGame(IEnumerable<IPlayer> players,string dispenser)
    {
        juego=new Manager(game_board,players,winCondition,player_selector,keyset);
        juego.InitializeGame(dispenser);
            return juego;
    }
}


