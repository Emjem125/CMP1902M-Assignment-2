using System;
namespace CMP1903M
{
	public class Game
	{

        Statistics Stats = new Statistics();

        //This method provides the user a choice and whatever is chosen is run.
        public void Run()
		{
			var exitoptionselected = false;
			do
			{
                Console.WriteLine("Choose an option: 1. SevensOut 2.ThreeOrMore 3.RunTests 4.ViewStats 5.Stop");
                var choice = Console.ReadLine();
				if (choice == "1")
				{
					PlaySevens();
					break;
				}
				else if (choice == "2")
				{
                    PlayThreeOrMore();
                    break;
                }
				else if (choice == "3")
				{
                    RunTests();
                    break;

                }
				else if (choice == "4")
				{
                    ViewStats();
                    break;
                }
                else if(choice == "5")
                {
                    Console.WriteLine("Stopping... ");
                    exitoptionselected = true;
					break;
                }

			}
			while (exitoptionselected == false);

			return;
		}

        //Instantiates the SevensOut game and allows for the highscore to be saved after played.
        private void PlaySevens()
        {
			SevensOut game = new SevensOut();
			game.Play();
            Stats.WriteHighScore(game.HighScore());
            Stats.WriteGameCount();
            Run();
            Console.ReadLine();
        }

        //Instantiates the ThreeOrMore game and allows for the game count to be saved after played.
        private void PlayThreeOrMore()
        {
            ThreeOrMore game = new ThreeOrMore();
            game.Play();
            //Everytime the game is played the statisitics are updated.
            Stats.WriteGameCount();
            Run();
            Console.ReadLine();
        }


        //Calls the testing class to be run if chosen
        private void RunTests()
        {
            Testing runTests = new Testing();
            runTests.Run();
        }

        //Allows access for the user to view the statistics of both games from the class Statistics.
        private void ViewStats()
        {
            Stats.ViewStats();
            Run();
            Console.ReadLine();
        }
    }
}

