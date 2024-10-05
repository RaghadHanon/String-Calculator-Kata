namespace StringCalculatorKata;
public class NegativeNumbersNotAllowedException : Exception
{
    public NegativeNumbersNotAllowedException(IEnumerable<int> negativeNumbers)
        : base($"Negatives not allowed: {string.Join(", ", negativeNumbers)}")
    {
    }
}
