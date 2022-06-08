


public static class Dispensers
{

    static List<IKey> selected = new List<IKey>();
    public static void NormalDispenser(IPlayer player,IEnumerable<IKey> fichas){
        int cantidad=0;
         var data = new IKey[10];
            foreach(var a in fichas)
            {    
            if(selected.Contains(a))continue;
            if(cantidad==10)break;
            data[cantidad++]=a;  
            selected.Add(a);              
            }
        player.SetData(data);         
        }    
}
