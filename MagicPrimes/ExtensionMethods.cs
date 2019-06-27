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
                                        
            var sqrt = (int) Math.Sqrt(candidate);

            for (var i = 3; i <= sqrt; i += 2)
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

        public static Answer FindFactorsForSequence(this IEnumerable<int> primes, int factorsCount, int sequenceLength, Stopwatch stopwatch)
        {
            var sequences = new Sequence(sequenceLength).validDigitSequences.ToArray();
            var primesArray = primes.ToArray();

            foreach (var candidateSequenceDigits in sequences)
            {
                var candidateSequence = candidateSequenceDigits.ToLong();

               var count = 0;
                var factors = new List<int>();
                foreach (var prime in primesArray)
                {
                    if (candidateSequence % prime != 0)
                    {
                        continue;
                    }
                    factors.Add(prime);
                    count++;
                    if (count == factorsCount)
                    {
                        break;
                    }
                }

                if (count == factorsCount &&
                    (long) factors[0] * factors[1] * factors[2] * factors[3] == candidateSequence)
                {
                    return new Answer(stopwatch.ElapsedMilliseconds, candidateSequence, factors);
                }
            }

            throw new KeyNotFoundException();
        }
    }
}
