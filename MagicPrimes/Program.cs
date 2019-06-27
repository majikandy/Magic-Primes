using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MagicPrimes
{ 
    public class Program
    {
        public static IEnumerable<int> Primes
        {
            get
            {
                for (var i = 1; true; i++)
                {
                    if (i.IsPrime())
                    {
                        yield return (i);
                    }
                }
            }
        }

        private static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            var answer = Primes.Between(101,1000).FindFactorsForSequence(4, 12, stopwatch);

            Console.WriteLine(answer.ElapsedTimeInMs + "ms : " + answer.Sequence + " = " + string.Join(" * ", answer.Factors));
            Console.ReadLine();
        }
    }
}
