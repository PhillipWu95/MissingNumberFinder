using Microsoft.Extensions.Logging;
using MissingNumberFinder.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingNumberFinder.Algorithms.Wrapper
{
    public class AlgorithmPerformanceTrackingWrapper(IMissingNumberFinder _finder, ILogger<IMissingNumberFinder> _logger) : IMissingNumberFinder
    {
        public string AlgorithmName => _finder.AlgorithmName;

        public bool SupportFindingMultipleNumbers => _finder.SupportFindingMultipleNumbers;

        public IEnumerable<int> FindMissingNumber(int[] numbers)
        {
            var ws = new Stopwatch();
            ws.Start();
            var result = _finder.FindMissingNumber(numbers);
            ws.Stop();
            _logger.Log(LogLevel.Information, "The {AlgorithmName} runs for {ElapsedTime}", AlgorithmName, ws.Elapsed);
            return result;
        }
    }
}
