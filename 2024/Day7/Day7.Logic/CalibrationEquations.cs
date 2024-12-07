
namespace Day7.Logic;

public class CalibrationEquations
{
    private readonly string _input;
    private readonly Func<long, long, long>[] _operations;
    private readonly string[] _equations;

    public int Count => _equations.Length;

    public long TotalCalibration { get; private set; }

    public static CalibrationEquations WithConcatenation(string input) =>
        new(input, new Func<long, long, long>[]
            {
                (t, i) => t * i,
                (t, i) => t + i,
                (t, i) => t * (i >= 100? 1000 : (i >= 10? 100 : 10)) + i
            });

    public static CalibrationEquations WithoutConcatenation(string input) =>
        new(input, new Func<long, long, long>[]
            {
                (t, i) => t * i,
                (t, i) => t + i
            });

    private CalibrationEquations(string input, Func<long, long, long>[] operations)
    {
        _input = input;
        _operations = operations;
        _equations = _input.Split('\n');

        Parse2();
    }

/*
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
    }*/

    private void Parse2()
    {
        foreach (var equation in _equations)
        {
            var members = equation.Split(':', StringSplitOptions.TrimEntries);
            var result = long.Parse(members[0]);
            var factors = members[1]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            if (HasSolution(result, factors, 1, factors[0]))
            {
                TotalCalibration += result;
            }
        }
    }

    private bool HasSolution(long result, long[] factors, int index, long currentResult)
    {
        if (index >= factors.Length)
        {
            return result == currentResult;
        }

        var factor = factors[index];
        foreach (var operation in _operations)
        {
            if (HasSolution(result, factors, index + 1, operation.Invoke(currentResult, factor)))
            {
                return true;
            }
        }

        return false;
    }

/*
    private bool CanSolveEquation(long result, long[] factors, List<string> combinations)
    {
        foreach (var combination in combinations)
        {
            var solution = factors[0];
            for (var index = 0; index < factors.Length - 1 && solution <= result; index++)
            {
                var operand = factors[index + 1];
                solution = combination[index] switch {
                    '*' => solution * operand,
                    '+' => solution + operand,
                    _ => solution * (operand >= 100? 1000 : (operand >= 10? 100 : 10)) + operand
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

        if (_concatenationAvailable)
        {
            Combine(combinations, count - 1, equation + "|");
        }

        Combine(combinations, count - 1, equation + "*");
        Combine(combinations, count - 1, equation + "+");
    }
*/
}
