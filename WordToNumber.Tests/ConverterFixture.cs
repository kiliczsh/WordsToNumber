using NUnit.Framework;

namespace WordToNumber.Tests
{
    public class ConverterFixture
    {
        [TestCase("one hundred twenty-three thousand four hundred thirty-five", ExpectedResult = "123435")]
        public string Should_Translate_Correctly(string input)
        {
            return Converter.Translate(input);
        }
    }
}