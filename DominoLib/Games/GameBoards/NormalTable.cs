



public class NormalTable : ITable
{

    LinkedList<IKey> board;
    IFace right;
    IFace left;

    LinkedList<ITableObserver> observers;

    string IRule.Description { get => "mesa normal de dos salidas";}
    string IRule.Name { get => "Normal";}

    public NormalTable()
    {
        board = new LinkedList<IKey>();
        observers = new LinkedList<ITableObserver>();
    }
    public void PlayKey(IKey key)
    {
        if(ValidPlay(key))
        {
             Insert(key);
            board.AddLast(key);                   
           // notify();  
        }
    }

    private void Insert(IKey key)
    {
      if(board.Count==0)
      {
          right=(key.GetFace(0));
          left=(key.GetFace(1));
           notify(key,1); 
           return;
      }
       
      var faces = key.GetAllFaces();

       bool derecha = faces.Any((elem)=>elem.Equals(right));

       if(derecha)
       {
           if(key.GetFace(0).Equals(right))
           {
               right=key.GetFace(key.GetAllFaces().Count()-1);
           }else{
               right=key.GetFace(0);
           }
           notify(key,1); 
              return;   
       }    
           if(key.GetFace(0).Equals(left))
           {
               left=key.GetFace(key.GetAllFaces().Count()-1);
           }else{
               left=key.GetFace(0);
           }
             notify(key,2); 
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


  
