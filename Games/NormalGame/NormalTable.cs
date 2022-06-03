



class NormalTable : ITable
{

    LinkedList<IKey> board;
    IFace right;
    IFace left;
    public NormalTable()
    {
        board = new LinkedList<IKey>();
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
}


  