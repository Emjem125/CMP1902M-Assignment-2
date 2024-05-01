using System;
namespace CMP1903M
{
	public class GameBase
	{
        //Parent Class that creates a new dice roll whenever it needs to be used in either ThreeOrMore or SevensOut.
        public int Roll()
        {
            Die newDice = new Die();
            return newDice.Roll();
            
            
        }


    }
}

