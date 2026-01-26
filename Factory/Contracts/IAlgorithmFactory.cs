using MissingNumberFinder.Contracts;
using MissingNumberFinder.Factory.DataModels;

namespace MissingNumberFinder.Factory.Contracts
{
    public interface IAlgorithmFactory
    {
        IMissingNumberFinder CreateAlgorithm(AlgorithmDataContext context);
    }
}
