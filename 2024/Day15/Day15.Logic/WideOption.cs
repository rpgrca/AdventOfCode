namespace Day15.Logic;

internal class WideOption : IOption
{
    public string Transform(string input) =>
        input.Replace("#", "##")
            .Replace("O", "[]")
            .Replace(".", "..")
            .Replace("@", "@.");

    public bool Wide() => true;
}
