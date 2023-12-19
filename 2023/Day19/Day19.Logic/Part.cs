namespace Day19.Logic;

public class Part
{
    private readonly string _input;

    public int X => Values['x'];
    public int M => Values['m'];
    public int A => Values['a'];
    public int S => Values['s'];
    public Dictionary<char, int> Values { get; }

    public Part(string input)
    {
        _input = input;
        Values = new Dictionary<char, int>();

        var values = input[1..^1].Split(",");
        foreach (var value in values)
        {
            var pair = value.Split("=");
            Values.Add(pair[0][0], int.Parse(pair[1]));
        }
    }
}
