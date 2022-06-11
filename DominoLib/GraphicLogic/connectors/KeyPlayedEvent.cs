
public class KeyPlayedEvent : IEvent<(IKey,int)>
{

    IKey playedKey;
    int position;   
    public KeyPlayedEvent(IKey jugada,int position)
    {
        playedKey=jugada;
        this.position=position;
    }

    public (IKey, int) GetEventData()
    {
        return (playedKey,position);
    }
}