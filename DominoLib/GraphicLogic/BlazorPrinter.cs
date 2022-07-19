
using DominoLib;
public class BlazorPrinter : IScreen
                             //implementacion concreta de un Screen para Blazor
{

    int playable_heads;

    //callbacks para gestionar la pantalla
    public Action<IKey,int> PlayKey{get;set;}
    public Action<IEnumerable<IKey>> PrintPlayerKeys{get;set;}
    public Action RemovePlayerKeys{get;set;}
    public Action<string> PrintPlayerName{get;set;}
    public Action<string> NotifyWinner{get;set;}
    public Action<int> SetBoardCount{get;set;}

    //pone los espacios de fichas
    public void SetSpaces(int spacesnumb)
    {
        playable_heads = spacesnumb;
        SetBoardCount(spacesnumb);
    }

    //no se necesita en este caso
    public void Start()
    {
    }

    //no se necesita en este caso
    public void Stop()
    {
    }

    //este update corresponde al KeyPlayedEvent que se encarga de jugar la ficha en la grafica
    public void Update(KeyPlayedEvent eventinfo)
    {
        var data = eventinfo.GetEventData();
        PlayKey(data.Item1,data.Item2);
    }

//se encarga de dar los datos del nuevo jugador cuando se cambia de turno
    public void Update(IEvent<IPlayer> eventinfo)
    {
        var data =eventinfo.GetEventData();
        PrintPlayerName(data.GetIdentifier());
        RemovePlayerKeys();
        PrintPlayerKeys(data.GetKeys());
    }

    //indica por pantalla quien ha ganado la partida
    public void Update(IPlayer eventinfo)
    {
        NotifyWinner("ha ganado "+eventinfo.GetIdentifier());
    }
}
