




public class CardGameTable : ITable
{

    LinkedList<IKey> board;
    IFace card;        

    LinkedList<ITableObserver> observers;

    string IRule.Description { get => "mesa para juegos de cartas";}
    string IRule.Name { get => "Mesa de cartas";}

    public CardGameTable()
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
          card=(key.GetFace(0));
           notify(key,2);                           
           if(card.GetValue()==2 || card.GetValue()==3)
           {
               ShangaiDecorator.parobar+=card.GetValue();
           }
    }

    public void Reset()
    {
      board.Clear();
    }

    public bool ValidPlay(IKey key)
    {
        if(board.Count()==0)return true;
        return key.GetFace(0).Equals(card);
    }

    public IEnumerable<IFace> CurrentFaces()
    {
        yield return card;
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


  
