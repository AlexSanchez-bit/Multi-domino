



public class ConfigFile
{

    public ConfigFile(string[] data)
    {
        GameTable = new NormalTable();
        Players = new NormalPlayer[]{new NormalPlayer("arturo"),new NormalPlayer("maria"),new NormalPlayer("jose"),new NormalPlayer("bernard")};
        GraphicPrinter= new ScreenPrinter();
        WinCondition= new GeneralWinCondition();
        PlayerSelector=new NormalPlayerSelector();
        KeyGenerator=KeyGenerators.NormalGenerator;         
        KeyDispenser=Dispensers.NormalDispenser;
        
           PlayerSelector.attach(GraphicPrinter);
        GameTable.attach(GraphicPrinter);

    }

    public ConfigFile(string datafile_name)
    {

    }

    public ITable GameTable{get;private set;}
    public IEnumerable<IPlayer> Players{get;private set;}
    public IWinCondition WinCondition{get;private set;}
    public IPlayerSelector PlayerSelector{get;private set;}
    public Func<IEnumerable<IKey>> KeyGenerator{get;private set;}
    public Action<IPlayer,IEnumerable<IKey>> KeyDispenser{get;private set;}
    public ScreenPrinter GraphicPrinter{get;private set;}

}
