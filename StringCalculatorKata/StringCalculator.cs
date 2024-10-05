namespace StringCalculatorKata;
public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        var numbersList = ExtractNumbers(numbers);
        return numbersList.Sum();
    }

    private List<int> ExtractNumbers(string numbers)
    {
        return numbers
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x =>
            {
                if (int.TryParse(x, out int parsedNumber))
                    return parsedNumber;
                throw new FormatException($"Invalid number format: '{x}'");
            })
            .ToList();
    }
}
