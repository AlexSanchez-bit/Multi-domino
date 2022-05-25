interface IGetNextPlayer<T>
{
  IPlayer<T> next_player(IEnumerable<IPlayer<T>> player_list);	
}
