using System;
using System.Collections.Generic;


public class NormalTable<T>:ITable<T>
{

		List<IKey<T>> Keyset;
		LinkedList<IKey<T>> board;


		public NormalTable(IEnumerable<IKey<T>> keyset)
		{
			Keyset = new List<IKey<T>>();
			board = new LinkedList<IKey<T>>();			    
			foreach(var a in keyset)
			{
				this.Keyset.Add(a);
			}
		}

	 public IEnumerable<IKey<T>> GetPlayerKeys()
	 {
			var rand = new Random();
			Stack<IKey<T>> player_hand=new Stack<IKey<T>>();

			while(player_hand.Count()<10)
	        {
				int random_key = rand.Next()%Keyset.Count();
				if(Keyset[random_key]==null)continue;

				player_hand.Push(Keyset[random_key]);
				Keyset.RemoveAt(random_key);				
			}

			return player_hand;
	 }
	  public IEnumerable<Face<T>> ValidKeys()
	  {
		  if(board.Count()==0)
		  {
			yield break;
		  }else{
			yield return board.First.Value.GetFace(0);	
			yield return board.Last.Value.GetFace(0);		  
		  }
	  }
	   public void PlayKey(IKey<T> key){
			board.AddLast(key);
	   }

	   public bool IsValid(IKey<T> key){
		   if(board.Count()==0)return true;
		   else{
			   var valid = ValidKeys();
			   foreach(var face in key.GetFaces())
			   {
				   if(valid.Contains(face))return true;
			   }
			   return false;
		   }
	   }

	   public IEnumerable<IKey<T>> OnTableKeys()
	   {
			return board;
	   }


}
