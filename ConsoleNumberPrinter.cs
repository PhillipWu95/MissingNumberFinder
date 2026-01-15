using MissingNumberFinder.Contracts;

namespace MissingNumberFinder
{
    public class ConsoleNumberPrinter : INumberOutputPrinter
    {
        /// <summary>
        /// Print a number to the console.
        /// </summary>
        /// <param name="number">The number to be printed.</param>
        public void Print(int number)
        {
            Console.WriteLine(number);
        }
    }
}
