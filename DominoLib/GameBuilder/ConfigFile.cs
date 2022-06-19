



public class ConfigFile
{

string screenPrinter,keydispenser,game_name;
string save_direction="~/datos/Carpeta nueva/datos/Carpeta nueva/clase_practica/Domino/SavedGames";
    public ConfigFile(string[] data)
    {
        game_name=data[0];
        BuildGame(data);      
    }

    public ConfigFile(string datafile_name)
    {
        this.game_name=datafile_name;
        string[] data = File.ReadAllLines(save_direction+datafile_name);        
        BuildGame(data);
    }

    private void BuildGame(string[] data)
    {

        
        GameTable = new NormalTable();
        Players = new IPlayer[]{new NormalPlayer("arturo"),new NormalPlayer("maria"),new NormalPlayer("jose"),new BFPlayer("bernard")};
        GraphicPrinter= new ScreenPrinter();
        WinCondition= new GeneralWinCondition();
        PlayerSelector=new NormalPlayerSelector();
        KeyGenerator=new NormalGenerator();         
        KeyDispenser=Dispensers.NormalDispenser;                 
    }

    public void SaveData()
    {
        string data=string.Format("Name:{0}\n",this.game_name);
        data+=Parse();
        StreamWriter sw = new StreamWriter(save_direction+this.game_name);
        sw.Write(data);
        sw.Close();    
    }
    private string Parse()
    {

        string game_file="";

        game_file+=string.Format("KeySet:{0},\n",KeyGenerator.Name);
         game_file+=string.Format("Board:{0},\n",GameTable.Name);
         game_file+=string.Format("WinCondition:{0},\n",WinCondition.Name);
         game_file+=string.Format("PlayerSelector:{0},\n",PlayerSelector.Name);   
           game_file+=string.Format("GraphicController:{0},\n",screenPrinter);       
         game_file+=string.Format("KeyDispenser:{0}/n",keydispenser);  
        return game_file;

    }

    public ITable GameTable{get;private set;}
    public IEnumerable<IPlayer> Players{get;private set;}
    public IWinCondition WinCondition{get;private set;}
    public IPlayerSelector PlayerSelector{get;private set;}
    public IKeyGenerator KeyGenerator{get;private set;}
    public Action<IPlayer,IEnumerable<IKey>> KeyDispenser{get;private set;}
    public ScreenPrinter GraphicPrinter{get;private set;}

}
