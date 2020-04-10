using System;
using System.Collections.Generic;
using System.Text;

namespace SumOfTwo
{
    /*
    *  You are given two arrays of int numbers ("a" and "b").
    *  Range: -1,000,000 to +1,000,000.
    *  Method must return a boolean:
    *   Can you make number X by adding any number from "a" to a number from "b"?
    */
    class Menu
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Collection of methods to test
                SumOfTwoFinder finder = new SumOfTwoFinder(15, 15);

                // Show full contents of an array to the user
                Console.Clear();
                Console.WriteLine("Given Arrays: \n");
                ConsolePrinter printer = new ConsolePrinter();
                printer.PrintOutArray(finder.a);
                printer.PrintOutArray(finder.b);

                // Accept user input, sum to search for in the arrays
                UserInput input = new UserInput();
                int desiredSum = input.AcceptInteger("desired sum");

                // Fire all methods using user input
                MethodTester tester = new MethodTester();
                tester.TestMethods( desiredSum,
                                    new Predicate<int>(finder.StraightForward),
                                    new Predicate<int>(finder.MissingNumber),
                                    new Predicate<int>(finder.MissingNumberImproved) 
                                  );

                // Restart application
                Console.WriteLine("\n --Press any key to start again.-- \n");
                Console.ReadKey();
            }
        }
    }
}
