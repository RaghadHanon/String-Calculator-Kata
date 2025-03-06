using AutoFixture;
using FluentAssertions;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;
        private Fixture _fixture;
        public StringCalculatorTests()
        {
            _fixture = new Fixture();
            _stringCalculator = _fixture.Create<StringCalculator>();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("1,2,3", 6)]
        [InlineData("1,2\n3", 6)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//\n\n1\n2", 3)]
        [InlineData("1,1001", 1)]
        public void Add_ShouldReturnExpectedResult_WhenInputIsInValidFormat(string numbers, int expectedResult)
        {
            var result = _stringCalculator.Add(numbers);
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("1,\n")]
        [InlineData("1,\n2")]
        public void Add_ShouldThrowFormatException_WhenInputIsInvalidFormat(string numbers)
        {
            _stringCalculator
                .Invoking(sc => sc.Add(numbers))
                .Should().Throw<FormatException>()
                .WithMessage($"{ErrorMessages.InvalidNumberFormat}: *");
        }

        [Theory]
        [InlineData("-1,1,-2")]
        public void Add_ShouldThrowNegativesNotAllowedException_WhenInputIsNegative(string numbers)
        {
            _stringCalculator
                .Invoking(sc => sc.Add(numbers))
                .Should().Throw<NegativeNumbersNotAllowedException>()
                .WithMessage($"{ErrorMessages.NegativesNotAllowed}: -1, -2");
        }
    }
}