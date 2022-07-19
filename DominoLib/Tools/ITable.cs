
public interface ITable:ITableEventManager,IRule//abstraccion de una mesa
//tiene el evento de cuando se juega una ficha y el rule para saber el nombre y regla que describe
{
    bool ValidPlay(IKey key);//indica si una jugada es valida
    IEnumerable<IFace> CurrentFaces();//devuelve las caras en juego
    IEnumerable<IKey> OnTableKeys();//devuelve las fichas que se han jugado
    void PlayKey(IKey key);    //juega una ficha 

    void Reset();//reinicia la mesa
 }
