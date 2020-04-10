using System;
using System.Collections.Generic;
using System.Text;

namespace SumOfTwo
{
    class ArrayCreator
    {
        private int minNumber, maxNumber = 0;

        public ArrayCreator(int minNumber, int maxNumber)
        {
            this.minNumber = minNumber;
            this.maxNumber = maxNumber;
        }

        public int[] CreateAndFillArray(int length)
        {
            int[] newArray = new int[length];
            Random random = new Random();

            for (int i=0; i<length; i++)
            {
                newArray[i] = random.Next(minNumber, maxNumber+1);
            }

            return newArray;
        }
    }
}
