public interface IPlayer
{
    string GetIdentifier();
    void SimulateRound(ITable table);

    IEnumerable<IKey> GetKeys();
    void SetData(IEnumerable<IKey> player_hand);    


}