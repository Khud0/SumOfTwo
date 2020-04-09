using System;
using System.Linq;
using System.Collections.Generic;

namespace SumOfTwo
{
    /* <summary>
    *  You are given two arrays of int numbers ("a" and "b").
    *  Range: -1,000,000 to +1,000,000.
    *  Method must return a boolean:
    *   Can you make number X by adding any number from "a" to a number from "b"?
    */
    class SumOfTwoFinder
    {
        private static int[] a = {0, 1, 0, 57, -1, 2104, 159, 199, -7, 4, -5, 2};
        private static int[] b = {-3, 48, 130, -2501, 5, 32, 105, 1230, -3, 7};
        private static int desiredSum = -8;
        private static int aLength;
        private static int bLength;
        
        static void Main(string[] args)
        {
            aLength = a.Length;
            bLength = b.Length;

            desiredSum = -8;

            Console.WriteLine(StraightForward());
            Console.WriteLine(MissingNumber());
            Console.WriteLine(MissingNumberImproved());
        }

        /// <summary>
        /// Loops through every possible pair, the worst case scenario.
        /// </summary>
        /// <returns> Whether there is a pair of number from "a" and a number from "b" 
        ///           which produce desiredSum when added together. </returns>
        private static bool StraightForward()
        {
            for (int i=0; i<aLength; i++)
            {
                for (int ii=0; ii<bLength; ii++)
                {
                    if (a[i] + b[ii] == desiredSum) 
                    {
                        return true;
                    }
                }
            }

            return false;
        } 

        /// <summary>
        /// Checks whether there is a missing number in the second array.
        /// For example, if the sum you're looking for is 5 and current number is 2,
        /// Then you need 5-2 = 3 in another array.
        /// </summary>
        private static bool MissingNumber()
        {
            for (int i=0; i<aLength; i++)
            {
                int requiredMatch = desiredSum - a[i];
                if (b.Contains(requiredMatch)) 
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Adds all of the required missing numbers to a dictionary and checks the other array only once.
        /// Missing number is a number which will produce desiredSum when added to current number.
        /// </summary>
        private static bool MissingNumberImproved()
        {
            Dictionary<int, bool> missingNumbers = new Dictionary<int, bool>();

            for (int i=0; i<aLength; i++)
            {
                int missingNumber = desiredSum - a[i];
                if (!missingNumbers.ContainsKey(missingNumber)) missingNumbers.Add(missingNumber, true);           
            }
            
            for (int i=0; i<bLength; i++)
            {
                if (missingNumbers.ContainsKey(b[i])) return true;
            }

            return false;
        }
    }
}
