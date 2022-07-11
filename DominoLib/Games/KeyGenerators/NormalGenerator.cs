public class NormalGenerator:IKeyGenerator
{
    public string Description => "fichas numericas doble nueve";

    public string Name => "Double9";

    public IEnumerable<IKey> GenerateKeyset()
    {
     var key_list=new List<NormalKey>();
    for(int i=0;i<10;i++)
     for(int j=i;j<10;j++){
            var generatedKey = new NormalKey(i,j);
            if(!key_list.Contains(generatedKey))
                key_list.Add(generatedKey);
        yield return generatedKey;
     }
    }

}
