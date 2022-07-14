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

    public void InitializeGame(Action<IPlayer,IEnumerable<IKey>,int> repartir_fichas,int cant_fichas)
    {
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
        do
        {
                SimulateRound();
        }
        while(!win_condition.GameEnded(player_list,board));
       return win_condition.GetWinner();
    }
    public void SimulateRound()
    {
        var currentPlayer= next_player.GetNextPlayer();
        currentPlayer.SimulateRound(board);       
    }

 }
