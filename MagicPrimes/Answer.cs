using System.Collections.Generic;

namespace MagicPrimes
{
    public struct Answer 
    {
        public long ElapsedTimeInMs { get; }
        public long Sequence { get; }
        public List<long> Factors { get; }

        public Answer(long elapsedTimeInMs, long sequence, List<long> factors)
        {
            ElapsedTimeInMs = elapsedTimeInMs;
            Sequence = sequence;
            Factors = factors;
        }
    }
}