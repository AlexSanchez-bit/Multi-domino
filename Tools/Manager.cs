 public class Manager<T>
 {
     ITable<T> board;
     IList<IKey<T>> keyset;
     IWinCondition<T> win_condition;
     IPlayerSelector<T> next_player;
     IList<IPlayer<T>> player_list;

     public Manager(ITable<T> board,IEnumerable<IPlayer<T>> players,IWinCondition<T> winCondition, IPlayerSelector<T> playerSelector,Func<IList<IKey<T>>> generator)
     {
         this.board=board;        
         this.win_condition=winCondition;
         this.next_player = playerSelector;
        keyset = generator();
        player_list= new List<IPlayer<T>>();
        foreach(var a in players)
        {
            player_list.Add(a);
        }
     }

    public IPlayer<T> SimulateGame()
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
