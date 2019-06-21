using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicPrimes
{
    public class Sequence
    {
        public List<int[]> validDigitSequences = new List<int[]>();

        public Sequence(int length)
        {
            var validSequence = Enumerable.Repeat(1, length).ToArray();

            //validDigitSequences.Add(new []{1,2,3,3,3,4,4,4,4,5,6,7});
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
                var validSequence = (int[]) previousValidSequence.Clone();

                if (validSequence[0] == 9) break;

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


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace MagicPrimes
//{
//    public class Sequence
//    {
//        //private static List<List<int>> validDigitSequences = new List<List<int>>();

//        public List<long> ValidSequences { get; set; } = new List<long>();

//        public Sequence(int length)
//        {
//            long firstValidSequnce = 0;
//            for (int j = 0; j < length; j++)
//            {
//                firstValidSequnce += (long)Math.Pow(10, j); // all the 1s
//            }

//            ValidSequences.Add(firstValidSequnce);

//            var i = length - 1;

//            while (ValidSequences.Last() + 1 != Math.Pow(10, length))
//            {
//                GetNextValidSequence(ValidSequences.Last(), i);
//            }
//        }

//        private void GetNextValidSequence(long previousValidSequence, int i)
//        {
//            while (true)
//            {
//                var validSequence = previousValidSequence;

//                if (validSequence[0] == 9) break;

//                var IsFirstDigit = i == 0;

//                if (validSequence[i] != 9 && (IsFirstDigit || ValueIsSameAsIndexMinus1(i, validSequence)))
//                {
//                    IncrementAtIndexAndResetAllToTheRight(i, validSequence);
//                    validDigitSequences.Add(validSequence);
//                    ValidSequences.Add(validSequence.ToLong());
//                }
//                else
//                {
//                    i--;
//                    previousValidSequence = validSequence;
//                    continue;
//                }

//                break;
//            }
//        }

//        private static bool ValueIsSameAsIndexMinus1(int i, List<int> validSequence)
//        {
//            return validSequence[i - 1] == validSequence[i];
//        }

//        private static void IncrementAtIndexAndResetAllToTheRight(int i, List<int> validSequence)
//        {
//            validSequence[i]++;
//            for (int j = i + 1; j < validSequence.Count(); j++)
//            {
//                validSequence[j] = validSequence[i]; // sets all to the right as the same
//            }
//        }

//    }
//}
