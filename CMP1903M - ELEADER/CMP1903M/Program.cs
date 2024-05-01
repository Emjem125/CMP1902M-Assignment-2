using System;

namespace CMP1903M;

class Program
{
    static int Main(string[] args)
    {
        try
        {
            //Instantiates the Game class.
            Game game = new Game();
            game.Run();
        }
        //Catches any unexpected exceptions that occurs and lets the user know.
        catch(Exception e)
        {
            Console.WriteLine("An error has occured "+ e.Message);
            return 1;
        }
        return 0;



    }
}

