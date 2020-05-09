using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask user to think of a number between 0 to 100
            Console.WriteLine("I want you to think of a number between 0 and 100. Ok?");
            Console.ReadLine();

            //Define Maximum number the user can guess
            int max = 100;

            //Keep track of the number of guesses
            int guesses = 0;

            //The start guess from
            int guessMin = 0;

            //The start guess to (half of the max)
            int guessMax = max / 2;

            //While the guess isn't the same
            while (guessMin != max)
            {
                //Increase guess amount (by 1)
                guesses++;

                //Ask the user if their number is between the guess range
                Console.WriteLine($"Is your number between { guessMin } and { guessMax }?");
                string response = Console.ReadLine();

                //If the user confirmed their number is within the current range...
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    max = guessMax;

                    guessMax = guessMax - (guessMax - guessMin) / 2;
                }
                //The number is greater than gueesMax and less than or equal to max
                else
                {
                    //The new minimum is one above the old maximum
                    guessMin = guessMax + 1;

                    //Guess the bottom half of the new range
                    int remainingDifference = max - guessMax;

                    //Set the guess max to half way between the guessMin and max
                    //NOTE: Math.Ceiling will round up the remaining difference to 2, if the difference is 3
                    guessMax += (int)Math.Ceiling(remainingDifference / 2f);
                }

                if (guessMin + 1 == max)
                {
                    guesses++;
                    Console.WriteLine($"Is your number { guessMin }?");
                    response = Console.ReadLine();

                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        guessMin = max;
                        break;
                    }
                }

            }

            Console.WriteLine($"** Your number is {guessMin} **");

            Console.WriteLine($" Guessed in {guesses} guesses");

            Console.ReadLine();
        }
    }
}
