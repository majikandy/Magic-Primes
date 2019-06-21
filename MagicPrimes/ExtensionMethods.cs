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

        public static long ToLong(this int[] digits)
        {
            long result = 0;

            for (var i = 0; i < digits.Length; i++)
            {
                var digit = digits[i];
                result += (long)Math.Pow(10, digits.Length - i - 1) * digit;
            }

            return result;
        }

        public static List<Answer> FindFactorsForSequence(this IEnumerable<int> primes, int factorsCount, int sequenceLength, int lowerLimit, int upperLimit, Stopwatch stopwatch)
        {
            var sequences = new Sequence(sequenceLength).validDigitSequences.ToArray();

            var digitMinimum = sequenceLength / factorsCount; // eg 3....   12/4

            var lowestFactor = (int)Math.Pow(10, digitMinimum-1); // eg 100

            var primesInRange = primes.Between(lowestFactor, upperLimit).ToArray(); // eg 100-1000
            var primesBelowRange = primes.Between(lowerLimit, lowestFactor).ToArray(); // eg 0-100

            var answers = new List<Answer>();

            foreach (var candidateSequenceDigits in sequences)
            {
                var candidateSequence = candidateSequenceDigits.ToLong();

                bool hasLowFactor = false;
                foreach (var p in primesBelowRange)
                {
                    if (candidateSequence % p == 0)
                    {
                        hasLowFactor = true;
                        break;
                    }
                }

                if (hasLowFactor)
                {
                    continue;
                }

                var count = 0;
                var factors = new List<long>();
                foreach (var p in primesInRange)
                {
                    if (candidateSequence % p != 0)
                    {
                        continue;
                    }

                    count++;
                    factors.Add(p);
                    //if (count == 4) break;
                }

                if (count != factorsCount)// || factors.Aggregate((a, b) => a * b) != candidateSequence)
                {
                    // Note : aggregate check here might be redundant
                    continue;
                }

                answers.Add(new Answer(stopwatch.ElapsedMilliseconds, candidateSequence, factors));
                
            }

            return answers;
        }
    }
}
