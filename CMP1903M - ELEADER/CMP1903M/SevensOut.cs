using System;
namespace CMP1903M
{
    public class SevensOut : GameBase
    {

        private int _setUpGame;

        public int SetUpGame
        {
            get { return _setUpGame; }
            set { _setUpGame = value; }
        }

        //Sets scoring system and oppenents for the game.
        private int P1TotalScore;
        private int P2TotalScore;
        private int opponent = 0;
        


        //Main method that runs the game everytime the user chooses to play this.
        public void Play()
        {
            //Carries out each method in order to follow the game rules of SevensOut
            Rules();
            opponent = SetGame();
            Console.WriteLine("Starting P1 Game");
            Player1Roll();
            //Depending on the return value from SetGame, the if statement will provide a partner player method or computer roll method.
            if (opponent == 2)
            {
                Player2Roll();
            }
            else if (opponent == 3)
            {
                CompRoll();
            }
            WinCondition();
            PlayAgain();
        }

        //Displays the Rules to the user 
        private void Rules()
        {
            Console.WriteLine("The rules for Sevens Out are as follows: ");
            Console.WriteLine("Roll 2 dice and the total of both will be calculated.");
            Console.WriteLine("If it is a 7 then your turn is over.");
            Console.WriteLine("If it is a double then your score will be doubled, eg. (3,3 would add 12 to total.");

        }

        //This method makes the user choose between playing single player, multiplayer against a partner or Computer.
        public int SetGame()
        {
            Console.WriteLine("Who would you like to play against? 1. By Yourself, 2. Partner or 3. The Computer");
            var option = Console.ReadKey();

            switch (option.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return 1;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:

                    return 2;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:

                    return 3;

                default:
                    Console.WriteLine("You have picked an invalid option.");
                    SetGame();
                    return 0;
            }
        }


        //This Method is used for Player 1's go following the rules of SevensOut.
        public int Player1Roll()
        {
            int Sum = 0;

            //The User will keep rolling until a sum of 7 occurs then the do,while will end.
            do
            {
                //Allows for the user to manually roll - unlike the computer.
                Console.WriteLine($"Player 1, please press a button to roll.");
                var p1roll = Console.ReadKey();

                //Uses the method from the parent class.
                int dice1 = Roll();
                int dice2 = Roll();

                Console.WriteLine("Player 1 you have rolled:" + dice1);
                Console.WriteLine("Player 1 you have rolled:" + dice2);
                //Adds dice values together assigning it to sum.
                Sum = dice1 + dice2;

                //Checks for doubles in the dice value so that it will add double points.
                if (dice1 == dice2)
                {
                    Console.WriteLine("You rolled a double! Well done you get double points.");
                    Sum *= 2;

                }
                
                //Checks if sum is 7 if so this will show the user final score and stop their go.
                if (Sum == 7)
                {
                    Console.WriteLine($"Player 1, your total is 7 therefore your go has ended.");
                    Console.WriteLine("Your final score is: " + P1TotalScore);

                    break;
                }
                //Assigns sum value to Player 1's score.
                
                P1TotalScore += Sum;
                
            }
            while (Sum != 7);
            return P1TotalScore;

        }

        //This method is used for Testing
        public int Sum()
        {
            int Sum = 0;

            do
            {
                //Uses the method from the parent class.
                int dice1 = Roll();
                int dice2 = Roll();

                Console.WriteLine("Player 1 you have rolled:" + dice1);
                Console.WriteLine("Player 1 you have rolled:" + dice2);
                //Adds dice values together assigning it to sum.
                Sum = dice1 + dice2;


            }
            while (Sum != 7);
            return Sum;
        }

        //This Method is used for Player 2's go following the rules of SevensOut - if chosen in SetGame Options.
        public int Player2Roll()
        {
            int Sum = 0;

            //The User will keep rolling until a sum of 7 occurs then the do,while will end.
            do
            {
                //Allows for the user to manually roll
                Console.WriteLine($"Player 2, please press a button to roll.");
                var p1roll = Console.ReadKey();

                //Uses the method from the parent class.
                int dice1 = Roll();
                int dice2 = Roll();

                Console.WriteLine("Player 2 you have rolled:" + dice1);
                Console.WriteLine("Player 2 you have rolled:" + dice2);
                Sum = dice1 + dice2;

                //Checks for doubles in the dice value so that it will add double points.
                if (dice1 == dice2)
                {
                    Console.WriteLine("You rolled a double! Well done you get double points.");
                    Sum *= 2;

                }

                //Checks if sum is 7 if so this will show the user final score and stop their go.
                if (Sum == 7)
                {
                    Console.WriteLine($"Player 2, your total is 7 therefore your go has ended.");
                    Console.WriteLine("Your final score is: " + P2TotalScore);

                    break;
                }
                //Assigns sum value to Player 2's score.
                P2TotalScore += Sum;


            }
            while (Sum != 7);
            return P2TotalScore;

        }

        //This Method is used for Computers go following the rules of SevensOut - if chosen in SetGame Options.
        public int CompRoll()
        {
            int Sum = 0;
            do 
            {
                    //Uses the method from the parent class - automatically rolling no manual input needed.
                    int dice1 = Roll();
                    int dice2 = Roll();

                    Console.WriteLine($"Player 2 you have rolled:" + dice1);
                    Console.WriteLine($"Player 2 you have rolled:" + dice2);
                    Sum = dice1 + dice2;

                    //Checks for doubles in the dice value so that it will add double points.
                    if (dice1 == dice2)
                    {
                        Console.WriteLine("You rolled a double! Well done you get double points.");
                        Sum *= 2;

                    }

                    //Checks if sum is 7 if so this will show the user final score and stop their go.
                    if (Sum == 7)
                    {
                        Console.WriteLine("Player 1, your total is 7 therefore your go has ended.");
                        Console.WriteLine("Your final score is: " + P2TotalScore);
                        break;
                    }
                     //Assigns sum value to Player 2's score.
                    P2TotalScore += Sum;
            }
            while (Sum != 7);
            return P2TotalScore;

        }


        //This method checks who us the winner using the scores stored in P1TotalScore and P2TotalScore, if the game was a mulitplayer game.
        private void WinCondition()
        {
            if (opponent == 2 || opponent == 3)
            {
                if (P1TotalScore > P2TotalScore)
                {
                    Console.WriteLine("Player 1 you have won with " + P1TotalScore);
                }
                else if (P2TotalScore > P1TotalScore)
                {
                    Console.WriteLine("Player 2 you have won with " + P2TotalScore);
                }

                else
                {
                    Console.WriteLine("Players you have a draw.");
                }
            }
        }

        //Gives the user a choice to play again or go back to game menu to choose again.
        private void PlayAgain()
        {
            Console.WriteLine("Would you like to 1. Play again 2.Go back to menu");
            var optionchoice = Console.ReadLine();
            if (optionchoice == "1")
            {
                //Resets the points to 0 again for the next game.
                P1TotalScore = 0;
                P2TotalScore = 0;
                Play();
            }
            else if (optionchoice == "2")
            {
                Console.WriteLine("Game Menu");
            }
            else
            {
                Console.WriteLine("Invalid Option");
                PlayAgain();
            }
        }

        private int _highScore = 0;

        //Checks the points with the highscore and assigns the new score depending on whether it is higher or not.
        public int HighScore()
        {
       
            if (P1TotalScore > _highScore)
            {
                _highScore = P1TotalScore;
            }

            if (P2TotalScore > _highScore)
            {
                _highScore = P2TotalScore;
            }

            return _highScore;
        }

    }

}

	

		