using MissingNumberFinder.Contracts;

namespace MissingNumberFinder
{
    public class GaussianMissingNumberFinder : IMissingNumberFinder
    {
        /// <summary>
        /// Calculates the missing number by taking the difference between the Gaussian sum and the adhoc sum.
        /// This method assumes the input is correct. i.e. only 1 number is missing and the maximum number is part of the list.
        /// </summary>
        /// <param name="numbers">The list of number to be calculated.</param>
        /// <returns>The value of the missing integer.</returns>
        public int FindMissingNumber(int[] numbers)
        {
            var maxNumber = numbers.Length; // The length of the array represents the max possible number according to the requirement
            var maximumSum = ((1 + maxNumber) * numbers.Length) / 2; // Calculates the Gaussian sum of (1 + n) * n / 2
            return maximumSum - numbers.Sum();
        }
    }
}
