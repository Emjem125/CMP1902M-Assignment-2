using System;
namespace CMP1903M
{
    public class ThreeOrMore : GameBase
    {
        //Sets scoring, oppenents and players.
        public int player1Score;
        public int player2Score;
        private int opponent;
        private int player;
        //private int _gamesPlayed;


        //Main method that runs the game everytime the user chooses to play this.
        public void Play()
        {
            Rules();
            player1Score = 0;
            player2Score = 0;
            //Sets the player to 1, so it begins with player 1 first.
            player = 1;
            bool gameOver;
            opponent = SetGame();

            //This keeps running until gameOver is true, this switches between player 1 and player 2 (or computer depending on setgame choice).
            do
            {
                //If the setgame choice is partner then this if statement allows for manual rolling.
                if (opponent == 1 || (opponent == 2 && player == 1))
                {
                    Console.WriteLine("Player " + player + " please press a button to roll");
                    var p2rolling = Console.ReadKey();
                }
                //If computer then their roll is automatic
                else
                {
                    Console.WriteLine($"Computer's Turn:");
                }

                var dice = RollingDice();

                //Check if dice is a scoring dice then the score of the kind is added using the AddScore Method.
                if (DiceScored(dice))
                {
                    AddScore(dice.ToList());
                }
                else
                {
                    TwoOfKind(dice);
                }
                //Checks if game is over.
                gameOver = GameOverCheck();

                //If the game is not over then the player is changed depending whether it is 1 or 2.
                if (!gameOver)
                {
                    player = player == 1 ? 2 : 1;
                }

            }
            while (!gameOver);
            WinCondition();
            PlayAgain();
        }

        private void Rules()
        {
            Console.WriteLine("The rules for Three Or More are as follows: ");
            Console.WriteLine("Roll 5 dice aiming to get 3 of a kind or more.");
            Console.WriteLine("If is is a 2 of a kind then the player may choose to rethrow all, or remaining dice.");
            Console.WriteLine("Points work as such: 3 of a kind = 3 points, 4 of a kind = 6 points, 5 of a kind = 12 points.");
            Console.WriteLine("First to total 20 points wins.");

        }

        //This method makes the user choose between playing multiplayer against a partner or Computer.
        public int SetGame()
        {
            Console.WriteLine("Who would you like to play against? 1. Partner or 2. The Computer");
            var option = Console.ReadKey();

            switch (option.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return 1;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:

                    return 2;
                default:
                    Console.WriteLine("You have picked an invalid option.");
                    SetGame();
                    return 0;
            }
        }


        //This method occurs if the dice roll 
        private void TwoOfKind(List<int> dice)
        {
            var dieCount = DiceGroup(dice);

            //Cycles through all the dice values checking if it is 2 of a kind.
            foreach (var item in dieCount)
            {
                if (item.Value == 2)
                {
                    string choice = "0";
                    Console.WriteLine("You have rolled 2 of a kind ");
                    //Provides the choice to reroll all or the 2 dice that are the same.
                    Console.WriteLine("You can either 1. Reroll all dice or 2. Reroll remaining dice");
                    //If multiplaying with partners then the user chooses manually, computer randomly chooses from the options given.
                    if (opponent == 1 || (opponent == 2 && player == 1))
                    {
                        choice = Console.ReadLine();
                    }
                    else if (opponent == 2 && player == 2)
                    {
                        var roll = new Random(Guid.NewGuid().GetHashCode());
                        choice = roll.Next(1, 3).ToString();
                    }
                   

                    if (choice == "1")
                    {
                        //Rerolls all dice and checks if the dice values rolled score points or not.
                        dice = RollingDice();
                        if (DiceScored(dice))
                        {
                            AddScore(dice.ToList());
                            break;
                        }
                    }
                    else if (choice == "2")
                    {
                        //Rolls remaining dice and checks if the dice values rolled score points or not.
                        ReRollRemaining(item.Key, dice);
                        if (DiceScored(dice))
                        {
                            AddScore(dice.ToList());
                            break;
                        }
                    }
                    else
                    {
                        //Exception handing if a choice is incorrect.
                        throw new ArgumentException("Invalid Choice");

                    }

                }
            }
        }

        //This method is used when the player chooses to reroll remaining dice.
        private void ReRollRemaining(int value, List<int> dice)
        {
            //Checks through all the dice values to find those that are not the same as the 2 of a kind.
            var timeToRoll = dice.Count(x => x != value);
            dice.RemoveAll(x => x != value);

            for (var i = 0; i < timeToRoll; i++)
            {
                dice.Add(Roll());
            }
            foreach (int die in dice)
            {
                //Prints out all the dice values
                Console.WriteLine($"You rolled a {die}");
            }
        }

        //This method checks whether there are 3 or more dice of the same value so that this will return true as 3,4,5 of a kind all score points.
        private static bool DiceScored(List<int> dice)
        {
            var diceCount = DiceGroup(dice);
            foreach (var item in diceCount)
            {
                if (item.Value >= 3)
                    return true;
            }
            
            return false;

        }

        //This Method add scores to the players scores depending on the 3,4,5 of a kind.
        public void AddScore(List<int> dice)
        {
            int total = 0;
            var dieCount = DiceGroup(dice);
            //This cycles through the dice value.
            foreach (var item in dieCount)
            {
                //If 3 of a kind then the user's total will add 3.
                if (item.Value == 3)
                {
                    Console.WriteLine("You have rolled a Three of a Kind!");
                    total += 3;

                }
                // 4 of a kind the user's total will add 6.
                else if (item.Value == 4)
                {
                    Console.WriteLine("You have rolled a Four of a Kind!");
                    total += 6;

                }
                // 5 of a kind the user's total will add 12.
                else if (item.Value == 5)
                {
                    Console.WriteLine("You have rolled a Five of a Kind!");
                    total += 12;
                }
                else
                {
                    total += 0;
                }
                //Console.WriteLine($"Total {total}");
            }

            //Depending on the player currently rolling the total will be assigned to either player1Score or player2Score.
            if (player == 1)
            {
                player1Score += total;
                Console.WriteLine("Player 1 score is " + player1Score);
            }
            else
            {
                player2Score += total;
                Console.WriteLine("Player 2 score is " + player2Score);
            }
        }

        //This method checks whether the game is over depending on whether either player 1 or player 2 reach 20 or above.
        public bool GameOverCheck()
        {
            switch (player)
            {
                case 1:
                    return player1Score >= 20;

                case 2:
                    return player2Score >= 20;

                default:
                    return false;


            }
        }



        //This checks who the winner is depending on who reaches 20 first, displays this to the players.
        private void WinCondition()
        {

            if (player1Score >= 20)
            {
                Console.WriteLine("Player 1 you have won!");
            }
            else
            {
                Console.WriteLine("Player 2 you have won");
            }

        }


        //This groups together the dice values in the list.
        private static Dictionary<int, int> DiceGroup(List<int> dice)
        {
            return dice
                .GroupBy(item => item)
                .ToDictionary(item => item.Key, item => item.Count());
        }

        //This method rolls 5 dice using the method from the parent class, adding them to a list and displaying them to the users.
        private List<int> RollingDice()
        {
            List<int> diceThrow = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                diceThrow.Add(Roll());
            }

            Console.WriteLine("You have rolled:" + diceThrow[0] + "," + diceThrow[1] + "," + diceThrow[2] + "," + diceThrow[3] + "," + diceThrow[4]);

            return diceThrow;
        }

        //Gives the user a choice to play again or go back to game menu to choose again.
        private void PlayAgain()
        {
            Console.WriteLine("Would you like to 1. Play again 2. Stop and return to menu");
            var optionchoice = Console.ReadLine();
            if (optionchoice == "1")
            {
                Play();
            }
            else if (optionchoice == "2")
            {
                Console.WriteLine("Stopping...");
            }
            else
            {
                Console.WriteLine("Invalid Option");
                PlayAgain();
            }


            
        }

    }
}