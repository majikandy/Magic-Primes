using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicPrimes
{
    public class Sequence
    {
        private static List<List<int>> validDigitSequences = new List<List<int>>();

        public List<long> ValidSequences { get; set; } = new List<long>();

        public Sequence(int length)
        {
           
            var validSequence = Enumerable.Repeat(1, length).ToList();

            validDigitSequences.Add(validSequence);
            ValidSequences.Add(validSequence.ToLong());

            var i = validSequence.Count() - 1;

            while (validDigitSequences.Last()[0] != 9)
            {
                GetNextValidSequence(validDigitSequences.Last(), i);
            }
        }

        private void GetNextValidSequence(List<int> previousValidSequence, int i)
        {
            while (true)
            {
                var validSequence = new List<int>(previousValidSequence);

                if (validSequence[0] == 9) break;

                var IsFirstDigit = i == 0;

                if (validSequence[i] != 9 && (IsFirstDigit || ValueIsSameAsIndexMinus1(i, validSequence)))
                {
                    IncrementAtIndexAndResetAllToTheRight(i, validSequence);
                    validDigitSequences.Add(validSequence);
                    ValidSequences.Add(validSequence.ToLong());
                }
                else
                {
                    i--;
                    previousValidSequence = validSequence;
                    continue;
                }

                break;
            }
        }

        private static bool ValueIsSameAsIndexMinus1(int i, List<int> validSequence)
        {
            return validSequence[i - 1] == validSequence[i];
        }

        private static void IncrementAtIndexAndResetAllToTheRight(int i, List<int> validSequence)
        {
            validSequence[i]++;
            for (int j = i + 1; j < validSequence.Count(); j++)
            {
                validSequence[j] = validSequence[i]; // sets all to the right as the same
            }
        }

    }
}
