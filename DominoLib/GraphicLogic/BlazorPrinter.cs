
using DominoLib;
public class BlazorPrinter : IScreen
{

    int playable_heads;

    public Action<IKey,int> PlayKey{get;set;}
    public Action<IEnumerable<IKey>> PrintPlayerKeys{get;set;}
    public Action RemovePlayerKeys{get;set;}
    public Action<string> PrintPlayerName{get;set;}
    public Action<string> NotifyWinner{get;set;}
    public Action<int> SetBoardCount{get;set;}

    public void SetSpaces(int spacesnumb)
    {
        playable_heads = spacesnumb;
        SetBoardCount(spacesnumb);
    }

    public void Start()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

    public void Update(KeyPlayedEvent eventinfo)
    {
        var data = eventinfo.GetEventData();
        PlayKey(data.Item1,data.Item2);
    }

    public void Update(IEvent<IPlayer> eventinfo)
    {
        var data =eventinfo.GetEventData();
        PrintPlayerName(data.GetIdentifier());
        RemovePlayerKeys();
        PrintPlayerKeys(data.GetKeys());
    }

    public void Update(IPlayer eventinfo)
    {
        NotifyWinner("ha ganado "+eventinfo.GetIdentifier());
    }
}
