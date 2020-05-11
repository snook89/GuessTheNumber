using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    /// <summary>
    /// Ask the user to guess a number between a certain range and then guesses that number in the fewest possible guesses
    /// </summary>
   public  class NumberGuesser
    {
        #region Public Properties

        /// <summary>
        /// The largest number we ask the user to guess, between 0 and this number
        /// </summary>
        public int MaximumNumber { get; set; }

        /// <summary>
        /// The current number of guesses  the computer has had
        /// </summary>
        public int CurrentNumberOfGuesses { get; private set; }

        /// <summary>
        /// The current known minimum number the user is thinking of
        /// </summary>
        public int CurrentGuessMinimum { get; private set; }

        /// <summary>
        /// The current known maximum number the user is thinking of
        /// </summary>
        public int CurrentGuessMaximum { get; private set; }

        #endregion

        #region .ctor
        /// <summary>
        /// Default constructor
        /// </summary>
        public NumberGuesser()
        {
            // Set default maximum number
            this.MaximumNumber = 100;

        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Asks the user to think of a number between 0 and the Maximum number
        /// </summary>
        public void InformUser()
        {
            //Ask user to think of a number between 0 to MaximumNumber
            Console.WriteLine($"I want you to think of a number between 0 and { this.MaximumNumber }. Ok?");
            Console.ReadLine();
        }

        /// <summary>
        /// Ask the user a series of questions to discover the number they are thinking of
        /// </summary>
        public void DiscoverNumber()
        {
            // Clear variables to their initial values before a discover
            this.CurrentNumberOfGuesses = 0;
            this.CurrentGuessMinimum = 0;
            this.CurrentGuessMinimum = this.MaximumNumber / 2;

            //While the guess isn't the same
            while (this.CurrentGuessMinimum != this.CurrentGuessMaximum)
            {
                //Increase guess amount (by 1)
                this.CurrentNumberOfGuesses++;

                //Ask the user if their number is between the guess range
                Console.WriteLine($"Is your number between { this.CurrentGuessMinimum } and { this.CurrentGuessMaximum }?");
                string response = Console.ReadLine();

                //If the user confirmed their number is within the current range...
                if (response?.ToLower().FirstOrDefault() == 'y')
                {
                    this.MaximumNumber = this.CurrentGuessMaximum;

                    this.CurrentGuessMaximum = this.CurrentGuessMaximum - (this.CurrentGuessMaximum - this.CurrentGuessMinimum) / 2;
                }
                //The number is greater than gueesMax and less than or equal to max
                else
                {
                    //The new minimum is one above the old maximum
                    this.CurrentGuessMinimum = this.CurrentGuessMaximum + 1;

                    //Guess the bottom half of the new range
                    int remainingDifference = this.MaximumNumber - this.CurrentGuessMaximum;

                    //Set the guess max to half way between the guessMin and max
                    //NOTE: Math.Ceiling will round up the remaining difference to 2, if the difference is 3
                    this.CurrentGuessMaximum += (int)Math.Ceiling(remainingDifference / 2f);
                }

                if (this.CurrentGuessMinimum + 1 == this.MaximumNumber)
                {
                    this.CurrentNumberOfGuesses++;
                    Console.WriteLine($"Is your number { this.CurrentGuessMinimum }?");
                    response = Console.ReadLine();

                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        this.CurrentGuessMinimum = this.MaximumNumber;
                        break;
                    }
                }

            }
        }

        /// <summary>
        /// Announces the number the user was thinking of and the number of guesses it took
        /// </summary>
        public void AnnounceResults()
        {
            Console.WriteLine($"** Your number is {this.CurrentGuessMinimum} **");

            Console.WriteLine($" Guessed in {this.CurrentNumberOfGuesses} guesses");

            Console.ReadLine();
        }

        #endregion
    }
}
