public class ScreenPrinter
{

    public ScreenPrinter()
    {  

    }
    
    public void PrintTable(ITable board)
    {
        int screensize=Console.WindowWidth-10;
        foreach(var key in board.OnTableKeys())
        {
            PrintHorizontalKey(key);
        }
    }
    public void PrintPlayer(IPlayer player)
    {
        Console.WriteLine(player.GetIdentifier()); 
        var keyset = player.GetKeys();
        foreach(var a in keyset)
        {
           PrintHorizontalKey(a);           
        }
       Console.WriteLine(" "); 
    }
   
   private void PrintVerticalKey(IKey key)
   {

   }

   public static void PrintHorizontalKey(IKey key)
   {
        foreach(var b in key.GetAllFaces())
              Console.Write(b.GetRepresentation());
     Console.Write(" ");  
   }
}