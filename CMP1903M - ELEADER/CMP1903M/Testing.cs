using System;
using System.Diagnostics;

namespace CMP1903M
{
	public class Testing
	{
		internal void Run()
		{
			Console.WriteLine("Would you like to test 1. SevensOut or 2. ThreeOrMore");
			var choice = Console.ReadLine();
			if (choice == "1")
			{
				SevensOutTest();
			}
			else if (choice == "2")
			{
				ThreeOrMoreTest();
			}
			else
			{
				Console.WriteLine("Invalid Option, choose again");
				Run();
			}
			PlayAgain();
		}


		public void SevensOutTest()
		{
			SevensOutSevenTotal();
		}

		public void ThreeOrMoreTest()
		{
			ThreeOrMoreScoreCheck();
		}
  


		public void SevensOutSevenTotal()
		{
			SevensOut testSevenTotal = new SevensOut();
			int p1TestSeven = testSevenTotal.Sum();

			Debug.Assert(p1TestSeven == 7, "Testing : Sum did not equal 7");
			//Checks that the total of two 6 sided dice is between expected range - not including the double calc.
			Debug.Assert(p1TestSeven >= 2 && p1TestSeven <= 12);
		}


		public void ThreeOrMoreScoreCheck()
		{
			ThreeOrMore testScore = new ThreeOrMore();
			testScore.Play();
			Debug.Assert(testScore.player1Score >= 20 || testScore.player2Score >= 20, "Testing : Score did not equal 20 or more");
			

		}
    

		public void DieMade()
		{
			Die testDie = new Die();
			if (testDie == null)
			{
				throw new ArgumentException();
			}
		}

		public void TestDieRange()
		{
			Die testDie = new Die();
			var testResult = testDie.Roll();
			Debug.Assert(testResult > 0 && testResult < 7);
			Debug.Assert(testResult >= 1 && testResult <= 6);

		}

        //Gives the user a choice to test again or go back to game menu to choose again.
        private void PlayAgain()
        {
            Console.WriteLine("Would you like to 1. Test Others 2.Stop");
            var optionchoice = Console.ReadLine();
            if (optionchoice == "1")
            {
				//Resets the points to 0 again for the next game.
				Run();
            }
            else if (optionchoice == "2")
            {
                Console.WriteLine("Stopping");

            }
            else
            {
                Console.WriteLine("Invalid Option");
                PlayAgain();
            }
        }
    }
}

