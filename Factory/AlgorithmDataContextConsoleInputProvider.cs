using MissingNumberFinder.Factory.Contracts;
using MissingNumberFinder.Factory.DataModels;

namespace MissingNumberFinder.Factory
{
    public class AlgorithmDataContextConsoleInputProvider : IAlgorithmDataContextInputProvider
    {
        public AlgorithmDataContext CreateDataContext()
        {
            AlgorithmDataContext result = new();
            var algorithmName = Console.ReadLine();
            result.UserInputAlgorithm = algorithmName;
            return result;
        }
    }
}
