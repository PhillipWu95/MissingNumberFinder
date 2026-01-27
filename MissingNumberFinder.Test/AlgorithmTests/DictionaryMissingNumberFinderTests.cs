using MissingNumberFinder.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumberFinder.Test.AlgorithmTests
{
    public class DictionaryMissingNumberFinderTests
    {
        [Theory]
        [InlineData(new int[] { 0, 1, 2 }, new int[] { 3, 4 })]
        [InlineData(new int[] { 0, 2 }, new int[] { 1,3 })]
        [InlineData(new int[] { 6, 5, 4, 1, 2, 3 }, new int[] { 0, 7 })]
        [InlineData(new int[] { 6, 0, 4, 1, 2, 3 }, new int[] { 5, 7 })]
        [InlineData(new int[] { 0, 4, 1, 2, 3 }, new int[] { 5, 6 })]
        [InlineData(new int[] { 4, 2, 3, 5, 6 }, new int[] { 0, 1 })]
        [InlineData(new int[] { 5, 4, 1, 2, 3 }, new int[] { 0, 6 })]
        [InlineData(new int[] { 5, 0, 4, 1, 2, 3 }, new int[] { 6 , 7 })]
        [InlineData(new int[] { 6, 0, 4, 1, 2}, new int[] { 3, 5 })]
        public async void DictionaryMissingNumberFinderTest1(int[] input, IEnumerable<int> expected)
        {
            var finder = new DictionaryMissingNumberFinder();

            var result = await finder.FindMissingNumberAsync(input, new CancellationToken());
            Assert.Equal(expected, result);
        }
    }
}
