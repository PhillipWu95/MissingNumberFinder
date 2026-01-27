using MissingNumberFinder.Contracts;

namespace MissingNumberFinder.Algorithms
{
    public class XORMissingNumberFinder : IMissingNumberFinder
    {
        public string AlgorithmName => "XOR";

        public bool SupportFindingMultipleNumbers => false;

        public async Task<IEnumerable<int>> FindMissingNumberAsync(int[] numbers, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var result = 0;
            for (var i = 0; i < numbers.Length; i++)
            {
                if (i % 5000 == 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Yield();
                }
                result ^= i + 1;
                result ^= numbers[i];
            }
            return [result];
        }
    }
}
