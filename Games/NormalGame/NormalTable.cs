



class NormalTable : ITable
{

    LinkedList<IKey> board;
    IFace right;
    IFace left;

    LinkedList<IObserver<(IKey,int)>> observers;
    public NormalTable()
    {
        board = new LinkedList<IKey>();
        observers = new LinkedList<IObserver<(IKey,int)>>();
    }
    public void PlayKey(IKey key)
    {
        if(ValidPlay(key))
        {
             Insert(key);
            board.AddLast(key);                   
           // notify();  esto manda la ultima ficha a la interfaz pero no a la mesa                                            
        }
    }

    private void Insert(IKey key)
    {
      if(board.Count==0)
      {
          right=(key.GetFace(0));
          left=(key.GetFace(1));
      }
       
      var faces = key.GetAllFaces();

       bool derecha = faces.Any((elem)=>elem.Equals(right));

       if(derecha)
       {
           foreach(var a in faces)
            {
                if(!a.Equals(right))
                {
                    right=a;                  
                }
            }     
              return;   
       }    
        foreach(var a in faces)
            {
                if(!a.Equals(left))left=a;
            }
    }

    public void Reset()
    {
      board.Clear();
    }

    public bool ValidPlay(IKey key)
    {
        if(board.Count()==0)return true;
        return key.GetAllFaces().Any((elem)=>right.Equals(elem)||left.Equals(elem));
    }

    public IEnumerable<IFace> CurrentFaces()
    {
         return new IFace[]{right,left};
    }

    public IEnumerable<IKey> OnTableKeys()
    {
       return board;
    }

    public void attach(IObserver<(IKey,int)> observer)
    {
        observers.AddLast(observer);       
    }

    public void dettach(IObserver<(IKey,int)> obsetver)
    {
        observers.Remove(obsetver);
    }

    public void notify()
    {         
       
       
    }

    public void notify(IKey key, int position)
    {
         foreach(var a in observers)
        {
            a.Update(new KeyPlayedEvent(key,position));
        }
       
    }
}


  