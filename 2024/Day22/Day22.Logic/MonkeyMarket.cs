using System.Collections.Generic;

namespace Day22.Logic;

public class MonkeyMarket
{
    private string _input;
    private readonly List<int> _list;

    public int Count => _list.Count;

    public MonkeyMarket(string input)
    {
        _input = input;
        _list = _input.Split('\n').Select(int.Parse).ToList();
    }
}
