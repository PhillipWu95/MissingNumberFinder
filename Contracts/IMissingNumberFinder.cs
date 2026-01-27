namespace MissingNumberFinder.Contracts
{
    public interface IMissingNumberFinder
    {
        string AlgorithmName { get; }
        bool SupportFindingMultipleNumbers { get; }
        Task<IEnumerable<int>> FindMissingNumberAsync(int[] numbers, CancellationToken cancellationToken);
    }
}
