using System;
using System.Collections.Generic;
using System.Text;
using Khud0.Utility;

namespace SumOfTwo
{
    internal class MethodTester
    {    
        public void TestMethods<TInput, TOutput>(TInput input, params Func<TInput, TOutput>[] methods)
        {
            int methodsCount = methods.Length;
            for (int i=0; i<methodsCount; i++)
            {
                Stopwatcher.Start();
                TOutput result = methods[i].Invoke(input);
                Console.WriteLine($"\nMethod {methods[i].Method.Name} returned: {result}.");
                Stopwatcher.Stop();
            }
        }

        public void TestMethods<TInput>(TInput input, params Predicate<TInput>[] methods)
        {
            int methodsCount = methods.Length;
            for (int i=0; i<methodsCount; i++)
            {
                Stopwatcher.Start();
                bool result = methods[i].Invoke(input);
                Console.WriteLine($"\nMethod {methods[i].Method.Name} returned: {result}.");
                Stopwatcher.Stop();
            }
        }
    }
}
