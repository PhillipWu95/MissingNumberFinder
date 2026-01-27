using MissingNumberFinder.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumberFinder.Test.AlgorithmTests
{
    public class XORMissingNumberFinderTests
    {
        [Theory]
        [InlineData(new int[] { 0, 1, 2 }, new int[] { 3 })]
        [InlineData(new int[] { 0, 2 }, new int[] { 1 })]
        [InlineData(new int[] { 6, 5, 4, 1, 2, 3 }, new int[] { 0 })]
        [InlineData(new int[] { 6, 0, 4, 1, 2, 3 }, new int[] { 5 })]
        public async void XORMissingNumberFinderTest1(int[] input, IEnumerable<int> expected)
        {
            var finder = new XORMissingNumberFinder();

            var result = await finder.FindMissingNumberAsync(input, new CancellationToken());

            Assert.Equal(expected, result);
        }
    }
}
