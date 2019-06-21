using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MagicPrimes
{
    public static class ExtensionMethods
    {
        public static bool IsPrime(this int candidate)
        {
            if (candidate <= 1)
                return false;

            if ((candidate & 1) == 0)
                return (candidate == 2);

            var num = (int) Math.Sqrt(candidate);

            for (var i = 3; i <= num; i += 2)
            {
                if ((candidate % i) == 0)
                    return false;
            }

            return true;
        }

        public static IEnumerable<int> Between(this IEnumerable<int> theList, int lowerLimit, int upperLimit)
        {
            return theList.Take(upperLimit).Where(i => i >= lowerLimit && i <= upperLimit);
        }

        public static long ToLong(this List<int> digits)
        {
            return long.Parse(string.Join(string.Empty, digits));
        }

        public static List<Answer> FindFactorsForSequence(this IEnumerable<int> theList, int factorsCount, int sequenceLength, int lowerLimit, int upperLimit, Stopwatch stopwatch)
        {
            var sequences = new Sequence(sequenceLength).ValidSequences;

            var digitMinimum = sequenceLength / factorsCount; // eg 3....   12/4

            var lowestFactor = (int)Math.Pow(10, digitMinimum-1); // eg 100

            var primesInRange = theList.Between(lowestFactor, upperLimit).ToList(); // eg 100-1000
            var primesBelowRange = theList.Between(lowerLimit, lowestFactor).ToList(); // eg 0-100

            var answers = new List<Answer>();

            foreach (var candidateSequence in sequences)
            {
                if (primesBelowRange.Any(p => candidateSequence % p == 0))
                {
                    // Note: if any factor is in the range, it means the sequence length can never be met
                    continue;
                }

                var count = 0;
                var answer = new List<long>();
                foreach (var p in primesInRange)
                {
                    if (candidateSequence % p == 0)
                    {
                        count++;
                        answer.Add(p);
                    }
                }

                if (count != factorsCount || answer.Aggregate((a, b) => a * b) != candidateSequence)
                {
                    // Note : aggregate check here might be redundant
                    continue;
                }

                answers.Add(new Answer(stopwatch.ElapsedMilliseconds, candidateSequence, answer));
            }

            return answers;
        }
    }
}
