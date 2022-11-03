using NUnitDemo;
using System;
using Xunit;

namespace Tests
{
    public class StuffDoerTests
    {
        [Fact]
        public void StuffDoer_SumOfArray()
        {
            StuffDoer stuffDoer = new StuffDoer();

            int[] numbers = new int[] { 1, 2, 3 };

            int result = stuffDoer.SumOfArray(numbers);

            Assert.Equal(6, result);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 10)]
        [InlineData(100, 100)]
        public void StuffDoer_AddNumbers(int one, int two)
        {
            StuffDoer stuffDoer = new StuffDoer();
            
            int expected = one + two;

            int result = stuffDoer.AddNumbers(one, two);

            Assert.Equal(expected, result);
        }
    }
}
