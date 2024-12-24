
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

    public string CalculateLargestNetworkParty() =>
        string.Join(',', FindLargestClique().OrderByDescending(c => c.Count).First().Order());

    public List<List<string>> FindLargestClique()
    {
        var computers = _connections.Keys.ToList();
        var allCliques = new List<List<string>>();
        ApplyBronKerboschAlgorithm(new List<string>(), computers, new List<string>(), _connections, allCliques);
        return allCliques;
    }

    private void ApplyBronKerboschAlgorithm(List<string> R, List<string> P, List<string> X, Dictionary<string, List<string>> graph, List<List<string>> allCliques)
    {
        if (! (P.Any() || X.Any()))
        {
            allCliques.Add(new List<string>(R));
            return;
        }

        var pivot = P.Concat(X).First();
        var nonNeighbors = P.Except(graph[pivot]).ToList();

        foreach (var node in nonNeighbors)
        {
            R.Add(node);
            ApplyBronKerboschAlgorithm(R, P.Intersect(graph[node]).ToList(), X.Intersect(graph[node]).ToList(), graph, allCliques);
            R.Remove(node);
            P.Remove(node);
            X.Add(node);
        }
    }
}
