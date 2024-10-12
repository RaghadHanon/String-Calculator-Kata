namespace StringCalculatorKata;
public class NegativeNumbersNotAllowedException : Exception
{
    public NegativeNumbersNotAllowedException(IEnumerable<int> negativeNumbers)
        : base($"{ErrorMessages.NegativesNotAllowed}: {string.Join(", ", negativeNumbers)}")
    {
    }
}
