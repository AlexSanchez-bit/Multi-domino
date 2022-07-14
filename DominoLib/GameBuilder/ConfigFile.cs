



public class ConfigFile
{

string save_direction="../SavedGames";


    public void SaveData()
    {
        string data=string.Format("Name:{0}\n",this.GameName);
        data+=Parse();
        StreamWriter sw = new StreamWriter(save_direction+"/"+this.GameName+".dom");        
        sw.Write(data);
        sw.Close();    
    }
    private string Parse()
    {

        string game_file="";

        game_file+=string.Format("KeySet:{0}\n",this.Keyset);
         game_file+=string.Format("Board:{0}\n",GameTable);
         game_file+=string.Format("WinCondition:{0}\n",WinCondition);
         game_file+=string.Format("PlayerSelector:{0}\n",PlayerSelector);   
         game_file+=string.Format("KeyDispenser:{0}\n",KeyDispenser);  
        return game_file;
    }

  public string GameName{get;private set;}
  public string GameTable{get;private set;}
  public string Keyset{get;private set;}
  public string WinCondition{get;private set;}
  public string PlayerSelector{get;private set;}
  public string KeyDispenser{get;private set;}
  public IEnumerable<(string,string)> PLayers{get;private set;}


  public ConfigFile(string file_name)
  {
    StreamReader sr = new StreamReader(save_direction+"/"+file_name);
    var reading = sr.ReadToEnd().Split("\n");
    sr.Close();
    List<string> configs=new List<string>();
        foreach(var a in reading)
        {
          if(a=="" || a==null)continue;
          configs.Add(a.Split(":")[1]);
        }
        init_Config_file(configs.ToArray());
  }
  public ConfigFile(string file_name,string load_direction)
  {
    StreamReader sr = new StreamReader(load_direction+"/"+file_name);
    var reading = sr.ReadToEnd().Split("\n");
    sr.Close();
    List<string> configs=new List<string>();
        foreach(var a in reading)
        {
          if(a=="" || a==null)continue;
          configs.Add(a.Split(":")[1]);
        }
        init_Config_file(configs.ToArray());
  }

  public ConfigFile(string[] configs)
  {
    init_Config_file(configs);
  }

  private void init_Config_file(string[] configs)
  {
      GameName=configs[0];
      Keyset=configs[1];    
      GameTable=configs[2];
      WinCondition=configs[3];
      PlayerSelector=configs[4];
      KeyDispenser=configs[5];
  }

}
