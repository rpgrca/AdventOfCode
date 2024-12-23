
using System.Net.Sockets;

namespace Day23.Logic;

public class LanParty
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly Dictionary<string, List<string>> _connections;

    public int Count => _lines.Length;

    public LanParty(string input)
    {
        _input = input;
        _lines = _input.Split('\n');

        _connections = new();
        foreach (var line in _lines)
        {
            var computers = line.Split('-');
            _connections.TryAdd(computers[0], new());
            _connections.TryAdd(computers[1], new());
            _connections[computers[0]].Add(computers[1]);
            _connections[computers[1]].Add(computers[0]);
        }
    }

    public List<string> FindPartiesOf(int size)
    {
        var result = new List<string>();
        foreach (var computer in _connections)
        {
            if (computer.Value.Count >= size)
            {
                foreach (var other in computer.Value)
                {
                    var othersConnectionsToOriginal = _connections[other].Where(p => _connections[p].Contains(computer.Key)).ToList();
                    foreach (var otherConnectionToOriginal in othersConnectionsToOriginal)
                    {
                        var network = string.Join(',', new List<string> { computer.Key, other, otherConnectionToOriginal }.Order());
                        result.Add(network);
                    }
                }
            }
        }

        return result.Distinct().Order().ToList();
    }

    public int FindNetworksWithComputerStartingWith(int size, char initialLetter)
    {
        var result = new List<string>();
        foreach (var computer in _connections.Where(p => p.Key[0] == initialLetter))
        {
            if (computer.Value.Count >= size)
            {
                foreach (var other in computer.Value)
                {
                    var othersConnectionsToOriginal = _connections[other].Where(p => _connections[p].Contains(computer.Key)).ToList();
                    foreach (var otherConnectionToOriginal in othersConnectionsToOriginal)
                    {
                        var network = string.Join(',', new List<string> { computer.Key, other, otherConnectionToOriginal }.Order());
                        result.Add(network);
                    }
                }
            }
        }

        return result.Distinct().Count();
    }
}
