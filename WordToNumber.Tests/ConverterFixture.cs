using NUnit.Framework;

namespace WordToNumber.Tests
{
    public class ConverterFixture
    {
        [TestCase("one hundred twenty-three thousand four hundred thirty-five", ExpectedResult = "123435")]
        [TestCase("There are many books.", ExpectedResult = "There are many books")]
        [TestCase(
            "I have one trillion two hundred thirty-four billion three hundred fifty-six million seven hundred eighty-nine thousand one hundred twenty-three things to do.",
            ExpectedResult = "I have 1234356789123 things to do")]
        public string Should_Translate_Correctly(string input)
        {
            return Converter.Translate(input);
        }
    }
}