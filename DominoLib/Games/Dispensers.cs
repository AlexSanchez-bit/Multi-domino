


public static class Dispensers
{

    static List<IKey> selected = new List<IKey>();    
    public static void NormalDispenser(IPlayer player,IEnumerable<IKey> keys){
       List<IKey> keyset = keys.ToList();
       var rand = new Random();
        int cantidad=0;
         var data = new IKey[10];

         while(cantidad<10)
         {
            var auxiliar_key = keyset[rand.Next(keyset.Count)];
            if(selected.Contains(auxiliar_key))continue;
            data[cantidad]=auxiliar_key;
            selected.Add(auxiliar_key);
            cantidad++;
         }

        player.SetData(data);         
        }    
}
