using OOP_DiceRollGame.Game.Die;
using OOP_DiceRollGame.Game.Play;

namespace DiceRollGame
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello, this is a guessing game!");
            Console.WriteLine("");
            Console.WriteLine("rolling the die");
            Console.WriteLine("");

            // instatiate a Die
            Die theDie = new();

            // start a game
            bool win = Play.TimeToGuess(theDie.Value, 3);

            // check for win
            Play.CheckForWin(win);

            Console.ReadKey();
        }
    }
}