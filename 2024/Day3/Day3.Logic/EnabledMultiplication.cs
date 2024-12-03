using System.Text.RegularExpressions;

namespace Day3.Logic;

public class EnabledMultiplication : IMultiplication
{
    public int Calculate(GroupCollection groups) =>
        int.Parse(groups[1].Value) * int.Parse(groups[2].Value);
}
