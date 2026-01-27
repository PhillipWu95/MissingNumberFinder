using MissingNumberFinder.Contracts;
using MissingNumberFinder.Factory.Contracts;
using MissingNumberFinder.Factory.DataModels;

namespace MissingNumberFinder.Factory
{
    public class AlgorithmFactory(IEnumerable<IMissingNumberFinder> _finder) : IAlgorithmFactory
    {
        public IMissingNumberFinder CreateAlgorithm(AlgorithmDataContext context)
        {
            var result = _finder.FirstOrDefault(f => f.AlgorithmName == context.UserInputAlgorithm && f.SupportFindingMultipleNumbers);
            return result ?? _finder.First(f => f.AlgorithmName == "Dictionary");
        }
    }
}
