
public class Manager<T>{

	int current_player; 
	IWinCondition<T> win_condition;	
	IGetNextPlayer<T> move_next;
	IPlayer<T>[] player_list;
    ITable<T> mesa;

	public Manager(ITable<T> mesa,IEnumerable<IPlayer<T>> jugadores,IWinCondition<T> winc,IGetNextPlayer<T> next_player)
	{
		this.mesa=mesa;
		player_list= new IPlayer<T>[jugadores.Count()];	
		int index =0;
		foreach(var jug in jugadores)
		{
			player_list[index++]=jug;
		}

		win_condition=winc;
		move_next=next_player;

	}


     
}

