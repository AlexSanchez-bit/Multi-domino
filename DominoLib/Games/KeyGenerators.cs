public class KeyGenerators{
 public static List<NormalKey> NormalGenerator()
 {
     var key_list=new List<NormalKey>();
    for(int i=0;i<10;i++)
     for(int j=i;j<10;j++){
            var generatedKey = new NormalKey(i,j);
            if(!key_list.Contains(generatedKey))
                key_list.Add(generatedKey);
     }

return key_list;
 } 

}
