public class CardFace : IFace
{

   public string sign{get;private set;}
   public string type{get;private set;}

    int numb;
    public CardFace(int numb,int color)
    {
        this.numb=numb;
        switch(color)
        {
            case 1:
            type="C";
            break;

               case 2:
            type="T";
            break;

               case 3:
            type="P";
            break;

               case 4:
            type="R";
            break;            
        }

        switch(numb)
        {
            case 1:
            sign="A";
            break;
               case 11 :
            sign="J";
            break;
               case 12:
            sign="Q";
            break;
               case 13:
            sign="K";
            break;
            default:
            sign=numb.ToString();
            break;
        }
    }
    public bool Equals(IFace face)
    {        
      var rep = face.GetRepresentation();
      var other_type="";
      var other_sign="";
        other_type+=rep[rep.Length-2];

      for(int i=0;i<rep.Length;i++)
      {
        if(rep[i]=='[')continue;
        if(rep[i]==other_type[0])break;
        other_sign+=rep[i];
      }
      return other_sign==sign || other_type==type;
    }

    public string GetRepresentation()
    {
        return string.Format("[{0}{1}]",sign,type);
    }

    public int GetValue()
    {
        return numb==1?14:numb;
    }
}
