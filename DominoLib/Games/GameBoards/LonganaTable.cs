class LonganaTable : ITable,IPlayerChangedObserver
{
    //mesa con rgla de la longana para esto implementa el observer de cuando se cambia un turno

    LinkedList<IKey> board;
   const bool locked=false;
    IPlayer last_player;
    int cant_fichas;             
     Dictionary<IPlayer,(IFace,bool)> playable_heads;        
    List<bool> availables;

    LinkedList<ITableObserver> observers;

    public string Description => "mesa con las reglas de la longana";

    public string Name => "Longana";

    public LonganaTable()
    {
        board = new LinkedList<IKey>();
        observers = new LinkedList<ITableObserver>();
        playable_heads=new Dictionary<IPlayer,(IFace,bool)>();
        availables =  new List<bool>();
    }

    public void SetPlayers(IEnumerable<IPlayer> player_list)
    {
        foreach(var a in  player_list)
        {
            playable_heads.Add(a,(null,locked));
        }

        foreach(var a in observers)
        {        
              a.SetSpaces(player_list.Count());    
        }
    }
    public void PlayKey(IKey key)
    {
        if(ValidPlay(key))
        {
             Insert(key);
             board.AddLast(key);
        }
    }

    private void Insert(IKey key)
    {           
        if(board.Count()==0)
        {
            foreach(var a in playable_heads.Keys)
            {
                var data=(key.GetFace(0),locked);
                playable_heads[a]=data;
            }
            notify(key,1);
            return;
        }

        int to_play_index=1;

        foreach(var a in playable_heads)
        {        
            if(a.Key.Equals(last_player) || a.Value.Item2!=locked)
            {
                var actual_face =a.Value.Item1;
                 var key_faces = key.GetAllFaces();
                 if(key_faces.First().Equals(actual_face))
                 {
                     playable_heads[a.Key]=(key_faces.Last(),a.Value.Item2);
                 }else{
                     playable_heads[a.Key]=(key_faces.First(),a.Value.Item2);
                 }
                notify(key,to_play_index);
                return;
            }
            to_play_index++;
        }
     
    }

    public void Reset()
    {
      board.Clear();
    }

    public bool ValidPlay(IKey key)
    {
     if(board.Count()==0)
     {
        if(IsDouble(key))
        {
            return true;    
        }    
        return false;
     }else
     {
         try{
         var duenno= playable_heads.Keys.Where(elem=>elem.GetKeys().Contains(key)).First();
         var verifable_heads=playable_heads.Where(elem=>elem.Value.Item2!=locked || elem.Key==duenno).Select(elem=>elem.Value.Item1).ToList();

        foreach(var a in verifable_heads)
        {
            if(key.GetAllFaces().Any(elem=>elem.Equals(a)))return true;
        }
        return false;
         }catch(Exception e)
         {
             return false;
         }
     }
    }

    private bool IsDouble(IKey key)
    {
        return key.GetAllFaces().All(elem=>elem.Equals(key.GetFace(0)));
    }
    public IEnumerable<IFace> CurrentFaces()
    {
       return playable_heads.Values.Select(elem=>elem.Item1);
    }

    public IEnumerable<IKey> OnTableKeys()
    {
       return board;
    }
   
    public void notify(KeyPlayedEvent eventdata)
    {         
       foreach(var a in observers)
       {
           a.Update(eventdata);
       }
       
    }

    public void notify(IKey key, int position)
    {
         foreach(var a in observers)
        {
            a.Update(new KeyPlayedEvent(key,position));
        }
       
    }

    public void attach(ITableObserver observer)
    {      
         observers.AddLast(observer);
    }

    public void dettach(ITableObserver obsetver)
    {
         observers.Remove(obsetver);
    }

    //update que se llama cuando un turno se cambia
    public void Update(IEvent<IPlayer> eventinfo)
    {
         var actual_player=eventinfo.GetEventData(); 
        if(last_player==null)
        {
            last_player=actual_player;
            cant_fichas=last_player.GetKeys().Count();
            return;
        }              
        if(actual_player.Equals(last_player))
        {
            
        }else if(cant_fichas >= last_player.GetKeys().Count()){
            var state=playable_heads[last_player];
            playable_heads[last_player]=(state.Item1,locked);
        }else{
              var state=playable_heads[last_player];
            playable_heads[last_player]=(state.Item1,!locked);
        }
        last_player=actual_player;
        cant_fichas=actual_player.GetKeys().Count();
    }
}


  
