public class ColorKeyGenerator:IKeyGenerator
{
    public string Description => "fichas cuyas caras son colores";

    public string Name => "Fichas de colores";

    public IEnumerable<IKey> GenerateKeyset()
    {
       for(int i=0;i<9;i++)
     for(int j=i;j<9;j++){
            yield return new DualKey(i,j);            
     }

    }

    private List<DualKey> NumericGenerator()
    {
     var key_list=new List<DualKey>();
    
        return key_list;
    } 
}