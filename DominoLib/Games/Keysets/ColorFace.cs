public class ColorFace : IFace
{

   string color;
    public ColorFace(int color)    
    {        
      switch(color)
      {
        case 1 :
          this.color="Black";
          break;
          case 2 :
          this.color="yellow";
          break;
          case 3 :
          this.color="pink";
          break;
          case 4 :
          this.color="Blue";
          break;
          case 5 :
          this.color="red";          
          break;
           case 6 :
          this.color="purple";          
          break;
           case 7 :
          this.color="orange";          
          break;
           case 0 :
          this.color="0";          
          break;
           case 8 :
          this.color="green";          
          break;
      }
    }
    
    public bool Equals(IFace face)
    {
     return  face.GetRepresentation()==GetRepresentation();
    }   
    public string GetRepresentation()
    {
        return string.Format("[{0}]",color);
    }

    public int GetValue()
    {
        return 1;
    }
}
