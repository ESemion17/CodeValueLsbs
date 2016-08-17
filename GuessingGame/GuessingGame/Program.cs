using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        class MyGuessingGame
        {
            private static int _count = 0;
            private int _secret;
            public MyGuessingGame()
            {
                _count = 0;
                _secret = new Random().Next(1, 101);
            }
            public int Guess(int num)
            {
                if (_count == 6)
                    return 2;
                ++_count;
                if (num > _secret)
                    return 1;
                if (num < _secret)
                    return -1;
                return 0;
            }
            public int secret
            { get
                {
                    return _secret;
                }
            }
            public int times
            {
                get
                {
                    return _count;
                }
            }
        }
        static void Main(string[] args)
        {
            MyGuessingGame guessingGame = new MyGuessingGame();
            Console.WriteLine("Try to guess my number");
            int gameAns;
            do
            {
                var ans = Console.ReadLine();
                int guessNumber;
                while (!int.TryParse(ans, out guessNumber))
                {
                    Console.WriteLine("It's not a number");
                    ans = Console.ReadLine();
                }
                gameAns = guessingGame.Guess(guessNumber);
                if (gameAns == 1)
                    Console.WriteLine("too big");
                if (gameAns == -1)
                    Console.WriteLine("too small");

            } while (gameAns != 0 && gameAns != 2);
            if (gameAns == 0)
                Console.WriteLine("Congratulations you guesses correctly the number\n"+
                    $"It's take only {guessingGame.times} guesses");
            else
                Console.WriteLine($"You failed. The number was {guessingGame.secret}");
        }
    }
}
