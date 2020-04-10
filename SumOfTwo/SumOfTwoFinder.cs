using System;
using System.Linq;
using System.Collections.Generic;

namespace SumOfTwo
{
    
    class SumOfTwoFinder
    {
        public int[] a { get; set; }
        public int[] b { get; set; }
        public int aLength { get; set; }
        public int bLength { get; set; }

        private readonly int minNumber = -100;
        private readonly int maxNumber = 100;


        
        public SumOfTwoFinder(int arrayLength1, int arrayLength2)
        {
            this.aLength = arrayLength1;
            this.bLength = arrayLength2;

            ArrayCreator arrayCreator = new ArrayCreator(minNumber, maxNumber);
            a = arrayCreator.CreateAndFillArray(aLength);
            b = arrayCreator.CreateAndFillArray(bLength);
        }

        

        

        /// <summary>
        /// Loops through every possible pair, the worst case scenario.
        /// </summary>
        /// <returns> Whether there is a pair of number from "a" and a number from "b" 
        ///           which produce desiredSum when added together. </returns>
        public bool StraightForward(int sumToSearchFor)
        {
            for (int i=0; i<aLength; i++)
            {
                for (int ii=0; ii<bLength; ii++)
                {
                    if (a[i] + b[ii] == sumToSearchFor) 
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
        public bool MissingNumber(int sumToSearchFor)
        {
            for (int i=0; i<aLength; i++)
            {
                int requiredMatch = sumToSearchFor - a[i];
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
        public bool MissingNumberImproved(int sumToSearchFor)
        {
            Dictionary<int, bool> missingNumbers = new Dictionary<int, bool>();

            for (int i=0; i<aLength; i++)
            {
                int missingNumber = sumToSearchFor - a[i];
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
