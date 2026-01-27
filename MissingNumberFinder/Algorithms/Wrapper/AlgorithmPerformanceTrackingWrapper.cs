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

        public async Task<IEnumerable<int>> FindMissingNumberAsync(int[] numbers, CancellationToken cancellationToken)
        {
            var ws = new Stopwatch();
            ws.Start();
            var result = await _finder.FindMissingNumberAsync(numbers, cancellationToken);
            ws.Stop();
            _logger.Log(LogLevel.Information, "The {AlgorithmName} runs for {ElapsedTime}", AlgorithmName, ws.Elapsed);
            return result;
        }
    }
}
