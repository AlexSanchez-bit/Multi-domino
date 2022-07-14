


public static class Dispensers
{

    static List<IKey> selected = new List<IKey>();    
    public static void NormalDispenser(IPlayer player,IEnumerable<IKey> keys,int cant){
       List<IKey> keyset = keys.ToList();
       var rand = new Random();
        int cantidad=0;
         var data = new IKey[cant];

         while(cantidad<cant)
         {
            var auxiliar_key = keyset[rand.Next(keyset.Count)];
            if(selected.Contains(auxiliar_key))continue;
            data[cantidad]=auxiliar_key;
            selected.Add(auxiliar_key);
            cantidad++;
         }

        player.SetData(data);         
        }    

      public static void PointDispenser(IPlayer player,IEnumerable<IKey> keys,int cant)
      {

       List<IKey> keyset = keys.ToList();
       var rand = new Random();
        int cantidad=cant;
         var data = new IKey[cant];
         var point =rand.Next(keyset.Count);

         while(cantidad>cant/2)
         {
            var auxiliar_key = keyset[(((point++)+keyset.Count)%keyset.Count)];
            if(selected.Contains(auxiliar_key))continue;
            data[cantidad--]=auxiliar_key;
            selected.Add(auxiliar_key);
         }
         point =rand.Next(keyset.Count);

         while(cantidad>0)
         {
            var auxiliar_key = keyset[(((point++)+1+keyset.Count)%keyset.Count)];
            if(selected.Contains(auxiliar_key))continue;
            data[cantidad--]=auxiliar_key;
            selected.Add(auxiliar_key);
         }

        player.SetData(data);         
      }
}
