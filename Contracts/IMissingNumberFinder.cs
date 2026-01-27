namespace MissingNumberFinder.Contracts
{
    public interface IMissingNumberFinder
    {
        string AlgorithmName { get; }
        bool SupportFindingMultipleNumbers { get; }
        IEnumerable<int> FindMissingNumber(int[] numbers);
    }
}
