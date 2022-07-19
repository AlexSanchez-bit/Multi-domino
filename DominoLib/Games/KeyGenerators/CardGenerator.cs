public class CardGenerator:IKeyGenerator
{
public string Description => "cartas de la baraja europea";

    public string Name => "Cartas";

    public IEnumerable<IKey> GenerateKeyset()
    {
        for(int j=1;j<5;j++)      
        {
          for(int i=1;i<14;i++)
           {
            yield return new Card(new CardFace(i,j));
           }
       }
    }
}
