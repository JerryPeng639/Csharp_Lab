namespace Lab4App
{
    interface IStragey
    {
        public int Next(int low, int high);
    }
    abstract class Player : IStragey
    {
        public string Name { get;  }
        public Player(string name)
        {
            Name = name;
        }

        public abstract int Next(int low, int high);
    }
    class HumanPlayer : Player 
    {
        public HumanPlayer(string name) : base(name)
        {
        }

        public override int Next(int low, int high)
        {
            return int.Parse(Console.ReadLine());
        }
    }

    class RandomGuess : Player
    {
        public RandomGuess(string name) : base(name)
        {
        }

        public override int Next(int low, int high)
        {
            Random rng = new Random();
            return rng.Next(low, high + 1);
        }
    }

    class BinarySearch : Player
    {
        public BinarySearch(string name) : base(name)
        {
        }

        public override int Next(int low, int high)
        {
            return (low + high) / 2;
        }
    }

    class SuperAI : Player
    {
        public SuperAI(string name) : base(name)
        {
        }

        public override int Next(int low, int high)
        {
            return low;
        }
    }

    class Game
    {
        private int low, high;
        private int s;
        private bool win;
        private Player player;

        public Game(Player player, int low = 0, int high = 99)
        {
            this.low = low;
            this.high = high;
            Random rng = new Random();
            s = rng.Next(low, high + 1);
            win = false;
            this.player = player;
        }

        public bool Win()
        {
            return win;
        }

        public void Run()
        {
            while (true)
            {
                // Console.WriteLine("({0}, {1})?", low, high);
                int g = player.Next(low, high);
                // Console.WriteLine(g);

                if (s == g)
                {
                    // Console.WriteLine("Bingo.");
                    win = true;
                    break;
                }
                else if (g > s)
                {
                    // Console.WriteLine("Too large.");
                    high = g - 1;
                }
                else
                {
                    // Console.WriteLine("Too small.");
                    low = g + 1;
                }

                if (high == low)
                {
                    // Console.WriteLine("Game over.");
                    break;
                }

            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player[] candidates = { new RandomGuess("Random Guess"),
                                    new BinarySearch("Binary Search"),
                                    new SuperAI("Super AI") };

            foreach (var player in candidates)
            {
                Benchmark(player, 10000);
            }
        }

        static void Benchmark(Player player, int N)
        {
            int wins = 0;
            for (int i = 1; i <= N; i++)
            {
                Game game = new Game(player);
                game.Run();
                if (game.Win()) wins++;
            }

            Console.WriteLine("{0}'s winning rate = {1, 6:F2} %", player.Name
                                                              , 100.0 * wins / N);
        }
    }
}
