using MissingNumberFinder.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace MissingNumberFinder.Algorithms
{
    public class DictionaryMissingNumberFinder : IMissingNumberFinder
    {
        public string AlgorithmName => "Dictionary";

        public bool SupportFindingMultipleNumbers => true;

        public async Task<IEnumerable<int>> FindMissingNumberAsync(int[] numbers, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var dict = new Dictionary<int, int>(numbers.Length);

            for (var i = 0; i<numbers.Length; i++)
            {
                if(i % 5000 == 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Yield();
                }
                _ = dict.TryGetValue(i, out _) ? dict[i] += 1 : dict[i] = 1;
                _ = dict.TryGetValue(numbers[i], out _) ? dict[numbers[i]] += 1 : dict[numbers[i]] = 1;
            }
            for(var i = numbers.Length; i<=numbers.Length + 1; i++)
            {
                _ = dict.TryGetValue(i, out _) ? dict[i] += 1 : dict[i] = 1;
            }
            return dict.Where(d => d.Value < 2).Select(d => d.Key);
        }
    }
}
