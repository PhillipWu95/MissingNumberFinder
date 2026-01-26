namespace MissingNumberFinder.Contracts
{
    public interface IMissingNumberFinder
    {
        string AlgorithmName { get; }
        int FindMissingNumber(int[] numbers);
    }
}
