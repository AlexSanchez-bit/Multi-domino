 public class Manager
 //el manaager se encarga de tomar todas las reglas y unificarlas para construir el juego
 {
     ITable board;
     List<IKey> keyset;
     IWinCondition win_condition;
     IPlayerSelector next_player;
     IList<IPlayer> player_list;

     public Manager(ITable board,IEnumerable<IPlayer> players,IWinCondition winCondition, IPlayerSelector playerSelector,IKeyGenerator generator)
     {
         //construye el juego con las reglas dadas por el constructor
         this.board=board;        
         this.win_condition=winCondition;
         this.next_player = playerSelector;
         keyset=new List<IKey>();
        foreach(var a in generator.GenerateKeyset())
        {
            keyset.Add(a);
        }
        player_list= new List<IPlayer>();
        foreach(var a in players)
        {
            player_list.Add(a);
        }
     }

    public void InitializeGame(Action<IPlayer,IEnumerable<IKey>,int> repartir_fichas,int cant_fichas)
    {
        //inicializa el juego y reparte las fichas a los jugadores
        foreach(var player in this.player_list)
        {
            repartir_fichas(player,this.keyset,cant_fichas);
        }        
        RobaitoPlayer.list_of_keys= new Stack<IKey>();        
        foreach(var a in keyset)
        {
            if(player_list.Any(elem=>elem.GetKeys().Contains(a)))continue;
          RobaitoPlayer.list_of_keys.Push(a);
        }
        next_player.SetPlayerList(player_list);
    }

    public IPlayer SimulateGame()
    {
        //simula un juego completo
        do
        {
                SimulateRound();
        }
        while(!win_condition.GameEnded(player_list,board));
       return win_condition.GetWinner();
    }
    public void SimulateRound()
    {
        //simula una ronda del juego
        var currentPlayer= next_player.GetNextPlayer();
        currentPlayer.SimulateRound(board);       
    }

 }
