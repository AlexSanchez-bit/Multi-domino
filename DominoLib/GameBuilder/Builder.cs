


public class GameBuilder
{
    //esta clase se encarga de construir el juego en dependencia de la configuracion seleccionada
    
    Manager juego;
      public ITable game_board{get;private set;}
       public IWinCondition win_condition{get;private set;}
       public IPlayerSelector player_selector{get;private set;}
       public IKeyGenerator keyset{get;private set;}

    public GameBuilder(ConfigFile cf)
    {
        //toma el configFile y aplica las reglas para construir el juego
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
     if(cf.GameTable=="Mesa de cartas")
     {
         game_board=new CardGameTable();
     }
//fichas
        if(cf.Keyset=="Doble 9")
        {
            keyset= new NormalGenerator();
        }
        if(cf.Keyset=="Doble 6")
        {
            keyset= new Double6Generator();
        }
        if(cf.Keyset=="Fichas de colores")
        {
            keyset= new ColorKeyGenerator();
        }
        if(cf.Keyset=="Cartas")
        {
            keyset=new CardGenerator();
        }
        if(cf.Keyset=="Aleatorio")
        {
            keyset=new RandomizedKeyGenerator();
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
        if(cf.PlayerSelector=="Turnos juego de Cartas")
        {
            player_selector=new CardGamePlayerSelector();
            game_board.attach((ITableObserver)player_selector);
        }
        //winconditions
        if(cf.WinCondition=="Normal")
        {
            win_condition= new GeneralWinCondition(); 
        }
        if(cf.WinCondition=="Shangai")
        {
            win_condition= new CardGameWinCondition(); 
        }
        if(cf.WinCondition=="Robaito")
        {
            win_condition= new RobaitoWinCondition();
        }
         if(cf.WinCondition=="multiplo de 5")
        {
            win_condition= new Multp5WinCondition(); 
            player_selector.attach((IPlayerChangedObserver)win_condition);
        }


         //conexiones auiliares
         if(cf.GameTable=="Longana")
         {
             player_selector.attach((IPlayerChangedObserver)game_board);
         }
    }

    public void ConnectGame(IScreen graphic_interface)
    {
        //conecta el juego a la parte grafica
        game_board.attach(graphic_interface);
        win_condition.attach(graphic_interface);
        player_selector.attach(graphic_interface);
    }

    public Manager BuildGame(IEnumerable<IPlayer> players,Action<IPlayer,IEnumerable<IKey>,int> dispenser,int cant_fichas)
    {        
        //construye y devuelve el juego
        if(game_board.Name=="Longana")
        {
            ((LonganaTable)game_board).SetPlayers(players);
        }
        juego=new Manager(game_board,players,win_condition,player_selector,keyset);
        juego.InitializeGame(dispenser,cant_fichas);
            return juego;
    }
}


