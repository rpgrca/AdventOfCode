namespace Day7.Logic;

public class CalibrationEquations
{
    private readonly Func<long, long, long>[] _operations;
    private readonly string[] _equations;

    public int Count => _equations.Length;

    public long TotalCalibration { get; private set; }

    public static CalibrationEquations WithoutConcatenation(string input) =>
        new(input, new Func<long, long, long>[]
            {
                (t, i) => t * i,
                (t, i) => t + i
            });

    public static CalibrationEquations WithConcatenation(string input) =>
        new(input, new Func<long, long, long>[]
            {
                (t, i) => t * i,
                (t, i) => t + i,
                (t, i) => t * (i >= 100? 1000 : (i >= 10? 100 : 10)) + i
            });

    private CalibrationEquations(string input, Func<long, long, long>[] operations)
    {
        _operations = operations;
        _equations = input.Split('\n');

        ParseEquations();
    }

    private void ParseEquations()
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
        if (result < currentResult)
        {
            return false;
        }

        if (index >= factors.Length)
        {
            return result == currentResult;
        }

        foreach (var operation in _operations)
        {
            if (HasSolution(result, factors, index + 1, operation.Invoke(currentResult, factors[index])))
            {
                return true;
            }
        }

        return false;
    }
}