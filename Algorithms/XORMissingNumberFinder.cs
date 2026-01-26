using MissingNumberFinder.Contracts;

namespace MissingNumberFinder.Algorithms
{
    public class XORMissingNumberFinder : IMissingNumberFinder
    {
        public string AlgorithmName => "XOR";

        public int FindMissingNumber(int[] numbers)
        {
            var result = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                result ^= i + 1;
                result ^= numbers[i];
            }
            return result;
        }
    }
}
