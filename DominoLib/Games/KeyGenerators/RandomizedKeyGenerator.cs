
public class RandomizedKeyGenerator:IKeyGenerator
{
public string Description => "fichas con caras de tipo aleatorio";

    public string Name => "Aleatorio";

    public IEnumerable<IKey> GenerateKeyset()
    {
        for(int i=0;i<100;i++){
        yield return new RandomizedKey();
      }
   }
}
