using AutoFixture;
using FluentAssertions;

namespace StringCalculatorKata.Tests
{
    public class AddShould
    {
        private StringCalculator _stringCalculator;
        private Fixture _fixture;
        public AddShould()
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
        public void Add_ValidFormatInput_ShouldReturnTheSum(string numbers, int expectedResult)
        {
            var result = _stringCalculator.Add(numbers);
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("1,\n")]
        [InlineData("1,\n2")]
        public void Add_InvalidFormatInput_ShouldThrowFormatException(string numbers)
        {
            _stringCalculator
                .Invoking(sc => sc.Add(numbers))
                .Should().Throw<FormatException>()
                .WithMessage($"Invalid number format: *");
        }

        [Theory]
        [InlineData("-1,1,-2")]
        public void Add_NegativeInput_ShouldThrowNegativesNotAllowedException(string numbers)
        {
            _stringCalculator
                .Invoking(sc => sc.Add(numbers))
                .Should().Throw<NegativeNumbersNotAllowedException>()
                .WithMessage("Negatives not allowed: -1, -2");
        }
    }
}