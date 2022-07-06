public class Multp5Table : ITable
{
    LinkedList<IKey> board;
    LinkedList<IObserver<KeyPlayedEvent>> observers;
    List<IFace> heads;

    public string Description => "tablero con regla de multiplo de 5";

    public string Name => "mult5";

    public Multp5Table()
    {
        board = new LinkedList<IKey>();
        observers = new LinkedList<IObserver<KeyPlayedEvent>>();
        heads =  new List<IFace>();
    }
    public void attach(ITableObserver observer)
    {
        observer.SetSpaces(4);
         observers.AddLast(observer);
    }

    public IEnumerable<IFace> CurrentFaces()
    {
        return heads;
    }

    public void dettach(ITableObserver obsetver)
    {
        observers.Remove(obsetver);
    }

    public void notify(IKey key, int position)
    {
        foreach(var a in observers)
        {
            a.Update(new KeyPlayedEvent(key,position));
        }
    }

    public void notify(KeyPlayedEvent eventdata)
    {
        foreach(var a in observers)
        {
            a.Update(eventdata);
        }
    }

    public IEnumerable<IKey> OnTableKeys()
    {
        return board;
    }
    public  void Insert(IKey key)
    {
         if(board.Count == 0)
         {
             foreach(var a in key.GetAllFaces())
             {
                 heads.Add(a);
                 notify(key,3);
             }
         }
         for(int i=0;i<heads.Count;i++)
         {
             if(key.GetFace(0).Equals(heads[i]))
             {
                 heads[i] = key.GetFace(1);
             }
         }
         notify(key,1);
         notify(key,2);
         notify(key,3);
         notify(key,4);
    }
    public void PlayKey(IKey key)
    {
        if(ValidPlay(key))
        {
          Insert(key);
          board.AddLast(key);
          var rand = new Random();
          notify(key,rand.Next(1,4));
        }
    }

    public void Reset()
    {
        board.Clear();
    }

    public bool ValidPlay(IKey key)
    {
        if(board.Count()==0)return true;
        for(int i = 0;i < heads.Count;i++)
        {
            
            
                if(key.GetAllFaces().Any((elem)=>heads[i].Equals(elem)))
                return true;
            
        }
        return false;
    }
}
