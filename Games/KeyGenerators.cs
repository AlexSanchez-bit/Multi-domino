class KeyGenerators{
 public static List<IKey<int>> NormalGenerator()
 {
     var key_list=new List<IKey<int>>();
    for(int i=0;i<10;i++)
     for(int j=0;j<10;j++)
         key_list.Add(new NormalKey(i,j));

return key_list;
 } 

}