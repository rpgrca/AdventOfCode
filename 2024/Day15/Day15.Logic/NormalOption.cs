namespace Day15.Logic;

internal class NormalOption : IOption
{
    public string Transform(string input) => input;

    public bool Wide() => false;
}
