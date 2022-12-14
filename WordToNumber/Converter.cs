using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordToNumber
{
    public static class Converter
    {
        public static string Translate(string input) =>
            ConvertToNumbers(input).Aggregate(string.Empty, (current, word) => current + (word + " ")).TrimEnd();

        private static IEnumerable<string> ConvertToNumbers(string words)
        {
            if (string.IsNullOrEmpty(words))
            {
                return new List<string>();
            }

            var matches = Regex.Matches(words, @"\w+").ToList();
            var lowerCases = matches.Select(m => m.Value.ToLowerInvariant()).ToList();
            // TODO: convert number words to digit by using Numbers
            return lowerCases;
        }

        private static readonly Dictionary<string, long> Numbers = new()
        {
            {"zero", 0},
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
            {"ten", 10},
            {"eleven", 11},
            {"twelve", 12},
            {"thirteen", 13},
            {"fourteen", 14},
            {"fifteen", 15},
            {"sixteen", 16},
            {"seventeen", 17},
            {"eighteen", 18},
            {"nineteen", 19},
            {"twenty", 20},
            {"thirty", 30},
            {"forty", 40},
            {"fifty", 50},
            {"sixty", 60},
            {"seventy", 70},
            {"eighty", 80},
            {"ninety", 90},
            {"hundred", 100},
            {"thousand", 1000},
            {"million", 1000000},
            {"billion", 1000000000},
            {"trillion", 1000000000000},
            {"quadrillion", 1000000000000000},
            {"quintillion", 1000000000000000000}
        };
    }
}