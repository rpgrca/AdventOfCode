using System.Text.RegularExpressions;

namespace Day3.Logic;

public class ProgramMemory
{
    private readonly string _input;
    private readonly IMultiplication _multiplication;
    private IMultiplication _conditionalMultiplication;

    public int Length => _input.Length;
    public int SumOfMultiplications { get; private set; }
    public int SumOfEnabledMultiplications { get; private set; }

    public ProgramMemory(string input)
    {
        _input = input;
        _multiplication = new EnabledMultiplication();
        _conditionalMultiplication = new EnabledMultiplication();

        CalculateSumOfMultiplications();
    }

    private void CalculateSumOfMultiplications()
    {
        var matches = Regex.Matches(_input, @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)", RegexOptions.Compiled);
        foreach (Match match in matches)
        {
            switch (match.Value)
            {
                case {} when match.Value.StartsWith("do()"):
                    _conditionalMultiplication = new EnabledMultiplication();
                    break;

                case {} when match.Value.StartsWith("don't()"):
                    _conditionalMultiplication = new DisabledMultiplication();
                    break;

                default:
                    SumOfMultiplications += _multiplication.Calculate(match.Groups);
                    SumOfEnabledMultiplications += _conditionalMultiplication.Calculate(match.Groups);
                    break;
            }
        }
    }
}