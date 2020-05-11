﻿using System;
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
            //Create new instance of our number guesser class
            var numberGuesser = new NumberGuesser();

            //Change the default maximum number to 200
            numberGuesser.MaximumNumber = 100;

            //Ask the user to think of a number
            numberGuesser.InformUser();

            //Discover the number the user is thinking of
            numberGuesser.DiscoverNumber();

            //Announce the result
            numberGuesser.AnnounceResults();
        }
    }
}
