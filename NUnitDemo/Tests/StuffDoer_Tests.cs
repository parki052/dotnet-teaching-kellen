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

        [Theory]
        [InlineData(6, 3)]
        [InlineData(0.5, 5.5)]
        [InlineData(5, 0)]
        public void StuffDoer_DivideBy(decimal num, decimal denom)
        {
            decimal expected = num / denom;

            StuffDoer stuffDoer = new StuffDoer();

            decimal result = stuffDoer.DivideBy(num, denom);

            Assert.Equal(expected, result);
        }
    }
}
