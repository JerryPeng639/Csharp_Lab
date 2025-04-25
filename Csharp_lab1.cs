using System;

class NumberGuessingGame
{
    static void Main()
    {
        Random random = new Random();
        int secret = random.Next(0, 100); // Generates number between 0 and 99
        int low = 0;
        int high = 99;
        int attempts = 0;

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("Guess the secret number between 0 and 99.");

        while (high - low > 1)
        {
            Console.WriteLine($"Current range: ({low}, {high})");
            Console.Write("Enter your guess: ");
            string input = Console.ReadLine();

            int guess;
            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }

            if (guess < low || guess > high)
            {
                Console.WriteLine($"out of range! try again.?");
                continue;
            }

            attempts++;

            if (guess == secret)
            {
                Console.WriteLine($"BINGO!");
                return;
            }
            else if (guess < secret)
            {
                low = guess + 1;
            }
            else
            {
                high = guess - 1;
            }
        }

        Console.WriteLine($"Only one number left ({low}) and it's not the secret number ({secret}).");
        Console.WriteLine("GG!");
    }
}
