using System;
namespace CMP1903M
{
	public class Statistics
	{
        private int highscore;
        private int gameCount;

        //The Statistic Menu that asks the user whether they wish to view Highscore or Game Count.
        public void ViewStats()
		{
			Console.WriteLine("Would you like to see the High Score or Played Game Count 1. HighScore or 2. Played Game Count.");
			var choice = Console.ReadLine();
			if (choice == "1")
			{
                Console.WriteLine("The current highscore is: " + highscore);
                PlayAgain();
            }
            else if (choice == "2")
            {
                Console.WriteLine($"You have played {gameCount} games");
                PlayAgain();
            }
			else
			{
                //Exception Handling if an unexpected choice occurs
				throw new ArgumentException("Invalid Option");
				
                
			}
        }

        //Checks whether the currect highscore is lower then the score that has been passed from SevensOut.
        public void WriteHighScore(int score)
        {
            if (score > highscore)
            {
                //Reassigning the score to highscore if it is higher.
                highscore = score;
            }
        }

        //Adds 1 everytime a game of threeormore is run.
        public void WriteGameCount()
        {
            gameCount ++;
        }

        //Gives the user a choice to play again or go back to game menu to choose again.
        private void PlayAgain()
        {
            Console.WriteLine("Would you like to 1.Go back to menu or 2. choose another option?");
            var optionchoice = Console.ReadLine();
            if (optionchoice == "1")
            {
                Console.WriteLine("Game Menu");
            }
            else if(optionchoice == "2")
            {
                ViewStats();
            }
            else
            {
                Console.WriteLine("Invalid Option");
                PlayAgain();
            }
        }

    }
}

