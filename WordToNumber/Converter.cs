using System;
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

            int signatureFlag;
            var matches = Regex.Matches(words, @"\w+").ToList();
            var lowerCases = matches.Select(m => m.Value.ToLowerInvariant()).ToList();
            var isConvertable = lowerCases.Select(l => Numbers.ContainsKey(l)).ToList();
            var list = new List<string>();
            var sentence = new List<string>();
            for (var index = 0; index < isConvertable.Count; index++)
            {
                var token = isConvertable[index];
                if (token)
                {
                    list.Add(lowerCases[index]);
                }
                else
                {
                    if (list.Any())
                    {
                        signatureFlag = list.FirstOrDefault()!.Equals("minus") ? -1 : 1;
                        sentence.Add(GetDigits(list.Select(n => Numbers[n]), signatureFlag).ToString());
                        list = new List<string>();
                    }

                    sentence.Add(matches[index].Value);
                }
            }

            if (!list.Any() || sentence.Any())
            {
                return sentence;
            }

            signatureFlag = list.FirstOrDefault()!.Equals("minus") ? -1 : 1;
            sentence.Add(GetDigits(list.Select(n => Numbers[n]), signatureFlag).ToString());

            return sentence;
        }

        private static long GetDigits(IEnumerable<long> numbers, int signatureFlag = 1)
        {
            var percentile = 0L;
            var result = 0L;
            foreach (var number in numbers)
            {
                switch (number)
                {
                    case >= 1000:
                        result += percentile * number;
                        percentile = 0;
                        break;
                    case >= 100:
                        percentile *= number;
                        break;
                    default:
                        percentile += number;
                        break;
                }
            }

            return (result + percentile) * signatureFlag;
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