 public class Manager
 {
     ITable board;
     List<IKey> keyset;
     IWinCondition win_condition;
     IPlayerSelector next_player;
     IList<IPlayer> player_list;

     public Manager(ITable board,IEnumerable<IPlayer> players,IWinCondition winCondition, IPlayerSelector playerSelector,IKeyGenerator generator)
     {
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

    public void InitializeGame(Action<IPlayer,IEnumerable<IKey>> repartir_fichas)
    {
        foreach(var player in this.player_list)
        {
            repartir_fichas(player,this.keyset);
        }
        next_player.SetPlayerList(player_list);
    }
    public IPlayer SimulateGame()
    {
        while(!win_condition.GameEnded(player_list,board))
        {
                SimulateRound();
        }
       return win_condition.GetWinner();
    }
    public void SimulateRound()
    {
        var currentPlayer= next_player.GetNextPlayer();
        currentPlayer.SimulateRound(board);       
    }

 }
