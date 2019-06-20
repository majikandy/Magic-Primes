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

            var primes = Program.Integers.Where(i => i.IsPrime());
           
            var answers = primes.FindFactorsForSequence(4,12, 0,1000, stopwatch);

            foreach (var answer in answers)
            {
                this.testOutput.WriteLine(answer.ElapsedTimeInMs + "ms : " + answer.Sequence + " = " + string.Join(" * ", answer.Factors));
            }

            //answers.Count().Should().Be(1);
            //answers.Single().Sequence.Should().Be(123334444567);
            //answers.Single().Factors.Should().BeEquivalentTo(new List<long>() { 313, 563, 811, 863 });
        }
    }
}
