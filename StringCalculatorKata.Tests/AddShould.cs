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
        [InlineData("1", 1)]
        [InlineData("1, 2", 3)]
        [InlineData("1, 2, 3", 6)]
        public void Add_SimpleInput_ShouldReturnTheSum(string numbers, int expectedResult)
        {
            var result = _stringCalculator.Add(numbers);
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("a,1")]
        [InlineData("1,b,3")]
        public void Add_InvalidInput_ShouldThrowFormatException(string numbers)
        {
            _stringCalculator
                .Invoking(sc => sc.Add(numbers))
                .Should().Throw<FormatException>()
                .WithMessage($"Invalid number format: *");
        }
    }
}