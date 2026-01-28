namespace MissingNumberFinder.API.Controllers
{
    public class MissingNumberRequest
    {
        public required string AlgorithmName { get; set; }
        public required int[] Numbers { get; set; }
    }
}