class LonganaTable : ITable
{

    LinkedList<IKey> board;
    IFace right;
    IFace left;

    IFace up;
    IFace down;
    List<int> heads;
    List<bool> availables;
    LinkedList<IObserver<KeyPlayedEvent>> observers;

    public string Description => "mesa con las reglas de la longana";

    public string Name => "Longana";

    public LonganaTable()
    {
        board = new LinkedList<IKey>();
        observers = new LinkedList<IObserver<KeyPlayedEvent>>();
        heads = new List<int>();
        availables =  new List<bool>();
    }
    public void PlayKey(IKey key)
    {
        if(ValidPlay(key))
        {
             Insert(key);
             //una posicion para poner heads[i]
             
             //una posicion para poner availables[i] false
            board.AddLast(key);                   
           // notify();  
        }
    }

    private void Insert(IKey key)
    {
        int head =0;
      if(board.Count==0)
      {
          right=(key.GetFace(0));
          left=(key.GetFace(0));
          up = (key.GetFace(0));
          down = (key.GetFace(0));
          for(int i = 0;i < 4;i++)
          {
              heads.Add(right.GetValue());
              availables.Add(false);
          }
           notify(key,1); 
           return;
      }
       for(int i =0 ;i < 4 ;i++)
       {
           if(availables[i])
           {
             head = i;
             break;
           }
       }
       if(head == 0)
       {
           if(key.GetFace(0).Equals(heads[0]))
           {
               up = key.GetFace(1);
           }
           up = key.GetFace(0);
       }
       if(head == 1)
       {
           if(key.GetFace(0).Equals(heads[1]))
           {
               up = key.GetFace(1);
           }
           up = key.GetFace(0);
       }
       if(head == 2)
       {
           if(key.GetFace(0).Equals(heads[2]))
           {
               up = key.GetFace(1);
           }
           up = key.GetFace(0);
       }
       if(head == 3)
       {
           if(key.GetFace(0).Equals(heads[3]))
           {
               up = key.GetFace(1);
           }
           up = key.GetFace(0);
       }
     
    }

    public void Reset()
    {
      board.Clear();
    }

    public bool ValidPlay(IKey key)
    {
        if(board.Count()==0)return true;
        for(int i = 0;i < availables.Count;i++)
        {
            if(availables[i])
            {
                if(key.GetAllFaces().Any((elem)=>heads[i].Equals(elem)))
                return true;
            }
        }
        return false;
    }

    public IEnumerable<IFace> CurrentFaces()
    {
         return new IFace[]{right,left,up,down};
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
        observer.SetSpaces(2);
         observers.AddLast(observer);
    }

    public void dettach(ITableObserver obsetver)
    {
         observers.Remove(obsetver);
    }
}


  
