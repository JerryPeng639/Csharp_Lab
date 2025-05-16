using System;
using System.Net.Sockets;


public interface IPlayer
{
    int MakeGuess();
}


public class HumanPlayer : IPlayer
{
    int input;
    public int MakeGuess()
    {
        try
        {
            input = int.Parse(Console.ReadLine());
            Console.WriteLine(input);
            
        }
        catch (FormatException e)
        {
            Console.WriteLine($"{e.Message}");
            this.MakeGuess();
        }
        catch (OverflowException e)
        {
            Console.WriteLine($"{e.Message}");
            this.MakeGuess();
        }
        
        return input;
    }
}


public class Game
{
    private int secret;
    private IPlayer player;

    public Game(IPlayer player, int low = 1, int high = 99)
    {
        this.secret = new Random().Next(low, high + 1);
        this.player = player;
    }

    public void Play()
    {
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("Guess the secret number between 0 and 99.");
        int high = 99;
        int low = 0;
        while ((high - low) > 1)
        {
            Console.WriteLine($"Current range: ({low}, {high})");

            int guess = player.MakeGuess();

            if (guess < low || guess > high)
            {
                Console.WriteLine($"out of range! try again.?");
                continue;
            }

            if (guess == secret)
            {
                Console.WriteLine($"BINGO!");
                return;
            }
            else if (guess < secret)
            {
                Console.WriteLine("Too low.");
                low = guess + 1;
            }
            else
            {
                Console.WriteLine("Too high.");
                high = guess - 1;
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        IPlayer player = new HumanPlayer(); // or new RandomPlayer(1, 100);
        Game game = new Game(player);
        game.Play();
    }
}