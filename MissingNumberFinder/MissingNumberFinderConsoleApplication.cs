using MissingNumberFinder.Contracts;
using MissingNumberFinder.Factory.Contracts;

namespace MissingNumberFinder
{
    public class MissingNumberFinderConsoleApplication(
        INumberInputProvider _numberInputHandler,
        IAlgorithmDataContextInputProvider _algorithmDataContextInputProvider,
        IAlgorithmFactory _algorithmFactory,
        INumberOutputPrinter _outputPrinter)
    {
        public async Task Run(CancellationToken cancellationToken)
        {
            try
            {
                Console.WriteLine("Please enter your input starting with [ and ending with ], numbers separated by comma. Press ctrl + C to exit:");
                var numbers = _numberInputHandler.GetNumberFromInput();
                Console.WriteLine("Please choose an algorithm:");
                var dataContext = _algorithmDataContextInputProvider.CreateDataContext();
                var missingNumber = await _algorithmFactory.CreateAlgorithm(dataContext).FindMissingNumberAsync(numbers, cancellationToken);
                Console.Write("The missing number is:");
                _outputPrinter.Print(missingNumber);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Null input detected.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Your input format is incorrect.");
            }
        }
    }
}
