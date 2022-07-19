
public interface IKeyGenerator:IRule //interfaz que abstrae la logica de un generador de fichas
{
    IEnumerable<IKey> GenerateKeyset();//devuelve el keyset 
}
