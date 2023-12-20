using System.Diagnostics;

namespace Day19.Logic;

[DebuggerDisplay("{Name} ({Nodes.Count})")]
public class Node
{
    public string Name { get; }
    public IFilter Filter { get; }
    public List<Node> Nodes { get; }

    public Node(string name)
    {
        Name = name;
        Filter = null;
        Nodes = new List<Node>();
    }

    public Node(string name, IFilter filter)
    {
        Name = name;
        Filter = filter;
        Nodes = new List<Node>();
    }
}