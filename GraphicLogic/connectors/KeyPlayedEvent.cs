
public class KeyPlayedEvent : IEvent<IKey>
{

    IKey playedKey;

    public KeyPlayedEvent(IKey jugada)
    {
        playedKey=jugada;
    }
    public IKey GetEventData()
    {
        return playedKey;
    }
}