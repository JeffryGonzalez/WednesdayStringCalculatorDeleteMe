
using Xunit;

// Instructions: https://osherove.com/tdd-kata-1

namespace StringCalculatorUnitTests;

public class StringCalculatorTests
{
    private StringCalculator calculator;

    public StringCalculatorTests()
    {
        calculator= new StringCalculator();
    }
    [Fact]
    public void CalculatorReturnsZeroForEmptyString()
    {
        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("13", 13)]
    [InlineData("19", 19)]
    [InlineData("108", 108)]
    public void SingleDigit(string numbers, int expected)
    {
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
   [InlineData("1,2", 3)]
   [InlineData("10,12", 22)]
   [InlineData("108,2", 110)]
   [InlineData("99,101", 200)]
    public void TwoDigits(string numbers, int expected)
    {
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    [InlineData("1000,10,3", 1013)]
    public void UnknownNumbers(string numbers, int expected)
    {
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
   [InlineData("1\n2",3)]
   [InlineData("10\n10", 20)]
   [InlineData("10\n5,3", 18)]
    public void HasNewLines(string numbers, int expected)
    {
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n1;2;3", 6)]
    [InlineData("//#\n1#2", 3)]
    [InlineData("//*\n1*2,3\n4", 10)]
   
    public void CustomDelimeters(string numbers, int expected)
    {
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,-1")]
    [InlineData("1,2,3,4\n5,-1")]
    public void NegativeNumbersThrows(string numbers)
    {
        Assert.Throws<NoNegativesAllowedException>(() => calculator.Add(numbers));
    }
}
