using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace MagicPrimes.Tests
{
    public class MagicPrimeFactorsTests
    {
        private readonly ITestOutputHelper testOutput;

        public MagicPrimeFactorsTests(ITestOutputHelper testOutput)
        {
            this.testOutput = testOutput;
        }

        [Fact]
        public void Get_factors_of_valid_sequence_length_12_for_primes_up_to_1000()
        {
            var stopwatch = Stopwatch.StartNew();

            var answer = Program.Primes.Between(101,1000).FindFactorsForSequence(4,12, stopwatch);

            this.testOutput.WriteLine(answer.ElapsedTimeInMs + "ms : " + answer.Sequence + " = " + string.Join(" * ", answer.Factors));

            answer.Sequence.Should().Be(123334444567);
            answer.Factors.Should().BeEquivalentTo(new List<long>() { 313, 563, 811, 863 });
        }
    }
}
