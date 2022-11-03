using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitDemo
{
    public class StuffDoer
    {

        /// <summary>
        /// Returns the sum of all integers in the given int[]
        /// </summary>
        /// <param name="nums">The integer array to be summed</param>
        /// <returns></returns>
        public int SumOfArray(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            return sum;
        }

        public int AddNumbers(int num1, int num2)
        {
            return num1 + num2;
        }

        public decimal DivideBy(decimal numerator, decimal denominator)
        {
            throw new NotImplementedException();
        }
    }
}
