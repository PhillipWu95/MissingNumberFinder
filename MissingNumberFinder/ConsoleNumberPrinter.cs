using MissingNumberFinder.Contracts;

namespace MissingNumberFinder
{
    public class ConsoleNumberPrinter : INumberOutputPrinter
    {
        /// <summary>
        /// Print a number to the console.
        /// </summary>
        /// <param name="numbers">The number to be printed.</param>
        public void Print(IEnumerable<int> numbers)
        {
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
