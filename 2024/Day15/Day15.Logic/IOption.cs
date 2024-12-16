namespace Day15.Logic;

internal interface IOption
{
    string Transform(string input);
    bool Wide(); // TODO: remove bool
}
