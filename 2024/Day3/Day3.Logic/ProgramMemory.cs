using System.Text.RegularExpressions;

namespace Day3.Logic;

public class ProgramMemory
{
    private string _input;

    public ProgramMemory(string input)
    {
        _input = input.Replace("\n", "");

        ParseMultiplications();
    }

    private void ParseMultiplications()
    {
        var matches = Regex.Matches(_input, @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)");
        var enabled = true;
        foreach (Match match in matches)
        {
            if (match.Value.StartsWith("mul"))
            {
                var result = int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
                SumOfMultiplications += result;
                if (enabled)
                {
                    SumOfEnabledMultiplications += result;
                }
            }
            else if (match.Value == "don't()")
            {
                enabled = false;
            }
            else
            {
                enabled = true;
            }
        }
    }

    public int Length => _input.Length;

    public int SumOfMultiplications { get; private set; }
    public int SumOfEnabledMultiplications { get; private set; }
}
