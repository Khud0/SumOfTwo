using System;
using System.Collections.Generic;
using System.Text;

namespace SumOfTwo
{
    class UserInput
    {
        public int AcceptInteger(string inputDescription)
        {
            Console.WriteLine($"Please enter {inputDescription}:\n");
            string input = Console.ReadLine();
            int parsedInput;
            if (int.TryParse(input, out parsedInput))
            {
                return parsedInput;
            } else 
            {
                Console.WriteLine("Invalid input. Using default value: 0");
                return 0;
            }  
        }
    }
}
