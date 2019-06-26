using System.Collections.Generic;

namespace MagicPrimes
{
    public struct Answer 
    {
        public long ElapsedTimeInMs { get; }
        public long Sequence { get; }
        public List<int> Factors { get; }

        public Answer(long elapsedTimeInMs, long sequence, List<int> factors)
        {
            ElapsedTimeInMs = elapsedTimeInMs;
            Sequence = sequence;
            Factors = factors;
        }
    }
}