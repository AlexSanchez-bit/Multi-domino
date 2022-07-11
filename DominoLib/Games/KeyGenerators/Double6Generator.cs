
public class Double6Generator:IKeyGenerator
{
    public string Description => "fichas numericas doble seis";

    public string Name => "Doble 6";

    public IEnumerable<IKey> GenerateKeyset()
    {       
     var key_list=new List<NormalKey>();
    for(int i=0;i<7;i++)
     for(int j=i;j<7;j++){
            var generatedKey = new NormalKey(i,j);
            if(!key_list.Contains(generatedKey))
                key_list.Add(generatedKey);
            yield return generatedKey;    
        }
    } 
}
