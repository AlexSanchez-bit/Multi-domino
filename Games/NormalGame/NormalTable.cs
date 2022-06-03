



class NormalTable<T> : ITable<T>
{

    LinkedList<IKey<T>> board;
    Stack<T> right;
    Stack<T> left;
    public NormalTable()
    {
        board = new LinkedList<IKey<T>>();
        right=new Stack<T>();
        left=new Stack<T>();
    }
    public void PlayKey(IKey<T> key)
    {
        if(ValidPlay(key))
        {
             Insert(key);
            board.Append(key);           
        }
    }

    private void Insert(IKey<T> key)
    {
        if(board.Count==0)
        {
            right.Push(key.GetFace(0));
            left.Push(key.GetFace(1));
        }

        T left_side=left.Peek();
        T right_side = right.Peek();
        var key_faces = key.GetAllFaces();
        if( key_faces.Contains(left_side))
        {
            foreach(var a in key_faces)
            {
                if(!a.Equals(left_side))
                {
                    left.Push(a);
                }
            }
            return;
        }
         foreach(var a in key_faces)
            {
                if(!a.Equals(right_side))
                {
                    right.Push(a);
                }
            }

    }

    public void Reset()
    {
      board.Clear();
      right.Clear();
      left.Clear();
    }

    public bool ValidPlay(IKey<T> key)
    {
        if(board.Count()==0)return true;

        return key.GetAllFaces().Any((elem)=>right.Contains(elem)||left.Contains(elem));
    }
   
    IEnumerable<T> ITable<T>.CurrentFaces()
    {
       return new T[]{right.Peek(),left.Peek()};
    }

    IEnumerable<IKey<T>> ITable<T>.OnTableKeys()
    {
        return board;
    }
}