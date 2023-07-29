namespace OOP_DiceRollGame.Game.Play
{
    public static class Play
    {
        static public bool TimeToGuess(int NumberToGuess, int rounds)
        {
            for (int guess = 1; guess <= rounds; guess++)
            {
                int userGuessedNumber = AskForANumber(rounds - guess + 1);
                if (userGuessedNumber == NumberToGuess)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Wrong number");
                }
            }
            return false;
        }
        static public int AskForANumber(int leftGuesses)
        {
            int guessedNumber;
            bool isNumber;
            do
            {
                Console.WriteLine($"You have still {leftGuesses} guesses left. Please guess a number: ");
                isNumber = int.TryParse(Console.ReadLine(), out guessedNumber);
            } while (!isNumber);

            return guessedNumber;
        }
        static public void CheckForWin(bool win)
        {
            string message = win ? "You win :) !" : "You Loose :( !";
            Console.WriteLine(message);
        }
    }
}