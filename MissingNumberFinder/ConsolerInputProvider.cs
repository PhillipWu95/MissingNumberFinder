using MissingNumberFinder.Contracts;
using System.Text.RegularExpressions;

namespace MissingNumberFinder
{
    public class ConsolerInputProvider : INumberInputProvider
    {
        /// <summary>
        /// Handles a string of console input in the format of [a, b, c...,n], with or without the enclosing brackets. 
        /// Not impacted by white spaces.
        /// </summary>
        /// <returns>An array of int parsed from the input string</returns>
        /// <exception cref="FormatException">Thrown when input doesn't match the format.</exception>
        /// /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        public int[] GetNumberFromInput()
        {
            var input = Console.ReadLine() ?? throw new ArgumentNullException();
            string inputPatter = @"^\s*\[?(?:\s*[0-9]+\s*\,)*(?:\s*[[0-9]+\s*)\]?\s*$";
            if (!Regex.IsMatch(input, inputPatter)) throw new FormatException();
            char[] charsToTrim = ['[', ']']; // Remove the leading and trailing brackets
            char[] separator = [','];
            return [.. input.Trim(charsToTrim).Split(separator).Select(s => int.Parse(s))];
        }
    }
}
