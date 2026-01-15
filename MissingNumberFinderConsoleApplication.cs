using MissingNumberFinder.Contracts;

namespace MissingNumberFinder
{
    public class MissingNumberFinderConsoleApplication(
        INumberInputProvider _numberInputHandler,
        IMissingNumberFinder _missNumberFinder,
        INumberOutputPrinter _outputPrinter)
    {
        public void Run()
        {
            Console.WriteLine("Please enter your input starting with [ and ending with ], numbers separated by comma. Press ctrl + C to exit:");
            try
            {
                var numbers = _numberInputHandler.GetNumberFromInput();
                var missingNumber = _missNumberFinder.FindMissingNumber(numbers);
                Console.WriteLine($"The missing number is: {missingNumber}.");
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
