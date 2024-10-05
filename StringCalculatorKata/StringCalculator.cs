namespace StringCalculatorKata;
public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        var numbersList = ExtractNumbers(numbers);

        var negatives = numbersList.Where(x => x < 0).ToList();
        if (negatives.Any())
            throw new NegativeNumbersNotAllowedException(negatives);

        return numbersList.Sum();
    }

    private List<int> ExtractNumbers(string numbers)
    {
        HandleInputNumbersString(ref numbers, out string[] delimiters);
        return numbers
            .Split(delimiters, StringSplitOptions.None)
            .Select(x =>
            {
                if (int.TryParse(x, out int parsedNumber))
                    return parsedNumber;
                throw new FormatException($"Invalid number format: '{x}'");
            })
            .ToList();
    }

    private void HandleInputNumbersString(ref string numbers, out string[] delimiters)
    {
        if (numbers.StartsWith("//"))
        {
            var index = numbers.IndexOf("\n", 3);
            delimiters = new[] { numbers.Substring(2, index - 2) };
            numbers = numbers.Substring(index + 1);
        }
        else delimiters = new[] { ",", "\n" };
    }
}
