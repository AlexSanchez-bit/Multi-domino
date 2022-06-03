public interface IPlayer<T>
{
    string GetIdentifier();
    void SimulateRound(ITable<T> table);

    IEnumerable<IKey<T>> GetKeys();
    void SetData(IEnumerable<IKey<T>> player_hand);    


}