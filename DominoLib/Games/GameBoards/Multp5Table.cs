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
        observer.SetSpaces(2);
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
        throw new NotImplementedException();
    }

    public void notify(KeyPlayedEvent eventdata)
    {
        throw new NotImplementedException();
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
             }
         }
         for(int i=0;i<heads.Count;i++)
         {
             if(key.GetFace(0).Equals(heads[i]))
             {
                 heads[i] = key.GetFace(1);
             }
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