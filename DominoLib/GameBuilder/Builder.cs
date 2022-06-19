


public class GameBuilder
{
    
    Manager juego;
    ScreenPrinter printer;

    public GameBuilder(ConfigFile cf)
    {
        cf.GameTable.attach(cf.GraphicPrinter);
        cf.PlayerSelector.attach(cf.GraphicPrinter);
        cf.WinCondition.attach(cf.GraphicPrinter);
        juego = new Manager( cf.GameTable,cf.Players,cf.WinCondition,cf.PlayerSelector,cf.KeyGenerator);    
        juego.InitializeGame(cf.KeyDispenser);
        printer=cf.GraphicPrinter;
    }

    public Manager BuildGame()
    {
        return juego;
    }

    public ScreenPrinter GetGraphicalInterface()
    {
       return printer; 
    }

}


