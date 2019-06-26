﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicPrimes
{
    public class Sequence
    {
        public List<int[]> validDigitSequences = new List<int[]>();

        public Sequence(int length)
        {
            var validSequence = new int[length];
            for (int j = 0; j < length; j++)
            {
                validSequence[j] = 1;
            }

            validDigitSequences.Add(validSequence);

            var i = validSequence.Count() - 1;

            while (validDigitSequences.Last()[0] != 9)
            {
                GetNextValidSequence(validDigitSequences.Last(), i);
            }
        }

        private void GetNextValidSequence(int[] previousValidSequence, int i)
        {
            while (true)
            {
                var validSequence = new int[previousValidSequence.Length];
                for (int j = 0; j < previousValidSequence.Length; j++)
                {
                    validSequence[j] = previousValidSequence[j];
                }

                var IsFirstDigit = i == 0;

                if (validSequence[i] != 9 && (IsFirstDigit || ValueIsSameAsIndexMinus1(i, validSequence)))
                {
                    IncrementAtIndexAndResetAllToTheRight(i, validSequence);
                    validDigitSequences.Add(validSequence);
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

        private static bool ValueIsSameAsIndexMinus1(int i, int[] validSequence)
        {
            return validSequence[i - 1] == validSequence[i];
        }

        private static void IncrementAtIndexAndResetAllToTheRight(int i, int[] validSequence)
        {
            validSequence[i]++;
            for (var j = i + 1; j < validSequence.Count(); j++)
            {
                validSequence[j] = validSequence[i]; // sets all to the right as the same
            }
        }
    }
}
