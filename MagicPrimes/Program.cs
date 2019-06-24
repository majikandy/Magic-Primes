using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MagicPrimes
{ 
    public class Program
    {
        public static IEnumerable<int> Integers
        {
            get
            {
                for (var i = 1; true; i++) yield return (i);
            }
        }

        private static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            var primes = Integers
                .Where(i => i.IsPrime());

            var answers = primes
                .FindFactorsForSequence(4, 12, 0, 1000, stopwatch);

            foreach (var answer in answers)
            {
               Console.WriteLine(answer.ElapsedTimeInMs + "ms : " + answer.Sequence + " = " + string.Join(" * ", answer.Factors));
            }

            Console.ReadLine();
        }
    }
}
