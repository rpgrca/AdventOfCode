
namespace Day7.Logic;

public class CalibrationEquations
{
    private readonly string _input;
    private readonly string[] _equations;

    public int Count => _equations.Length;

    public long TotalCalibration { get; private set; }

    public CalibrationEquations(string input)
    {
        _input = input;
        _equations = _input.Split('\n');

        Parse();
    }

    private void Parse()
    {
        foreach (var equation in _equations)
        {
            var members = equation.Split(':', StringSplitOptions.TrimEntries);
            var result = long.Parse(members[0]);
            var factors = members[1]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            var combinations = new List<string>();
            Combine(combinations, factors.Length - 1, "");

            if (CanSolveEquation(result, factors, combinations))
            {
                TotalCalibration += result;
            }
        }
    }

    private bool CanSolveEquation(long result, long[] factors, List<string> combinations)
    {
        foreach (var combination in combinations)
        {
            var solution = factors[0];
            for (var index = 0; index < factors.Length - 1; index++)
            {
                solution = combination[index] switch {
                    '*' => solution * factors[index + 1],
                    '+' => solution + factors[index + 1]
                };
            }

            if (solution == result)
            {
                return true;
            }
        }

        return false;
    }

    private void Combine(List<string> combinations, int count, string equation)
    {
        if (count == 0)
        {
            combinations.Add(equation);
            return;
        }

        Combine(combinations, count - 1, equation + "+");
        Combine(combinations, count - 1, equation + "*");
    }
}