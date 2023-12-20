namespace Day19.Logic;

public class Aplenty
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly Dictionary<string, Rule> _rules;
    private readonly List<Part> _parts;
    public int PartCount => _parts.Count;
    public int RuleCount => _rules.Count;
    public int SumOfAcceptedParts { get; private set; }
    public ulong AcceptedCombinations { get; private set; }

    public Aplenty(string input, bool buildGraph = false)
    {
        _input = input;
        _lines = _input.Split("\n");
        _rules = new Dictionary<string, Rule>();
        _parts = new List<Part>();

        var inRules = true;
        foreach (var line in _lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                inRules = false;
            }
            else
            {
                if (inRules)
                {
                    var rule = new Rule(line);
                    _rules.Add(rule.Name, rule);
                }
                else
                {
                    _parts.Add(new Part(line));
                }
            }
        }

        if (buildGraph)
        {
            var root = BuildGraph();
            var filters = new List<IFilter>();
            FindCombinations(root, filters);
        }
    }

    private Node BuildGraph()
    {
        var dictionary = new Dictionary<string, Node>();
        var root = new Node("start", new Filter("in"));
        dictionary.Add("start", root);

        _rules.Add("start", new Rule("start{in}"));
        BuildGraph(dictionary, "start");

        return dictionary["in"];
    }

    private void FindCombinations(Node root, List<IFilter> filters)
    {
        if (root.Name.StartsWith("R"))
        {
            return;
        }
        else if (root.Name.StartsWith("A"))
        {
            var xSet = false;
            var minimumX = 0UL;
            var maximumX = 0UL;
            var mSet = false;
            var minimumM = 0UL;
            var maximumM = 0UL;
            var aSet = false;
            var minimumA = 0UL;
            var maximumA = 0UL;
            var sSet = false;
            var minimumS = 0UL;
            var maximumS = 0UL;

            foreach (var filter in filters)
            {
                switch (filter.Variable)
                {
                    case 'x':
                        if (! xSet)
                        {
                            minimumX = filter.MinimumAcceptedValue;
                            maximumX = filter.MaximumAcceptedValue;
                            xSet = true;
                        }
                        else
                        {
                            maximumX = Math.Min(maximumX, filter.MaximumAcceptedValue);
                            minimumX = Math.Max(minimumX, filter.MinimumAcceptedValue);
                        }
                        break;

                    case 'm':
                        if (! mSet)
                        {
                            maximumM = filter.MaximumAcceptedValue;
                            minimumM = filter.MinimumAcceptedValue;
                            mSet = true;
                        }
                        else
                        {
                            maximumM = Math.Min(maximumM, filter.MaximumAcceptedValue);
                            minimumM = Math.Max(minimumM, filter.MinimumAcceptedValue);
                        }

                        break;

                    case 'a':
                        if (! aSet)
                        {
                            maximumA = filter.MaximumAcceptedValue;
                            minimumA = filter.MinimumAcceptedValue;
                            aSet = true;
                        }
                        else
                        {
                            maximumA = Math.Min(maximumA, filter.MaximumAcceptedValue);
                            minimumA = Math.Max(minimumA, filter.MinimumAcceptedValue);
                        }

                        break;

                    case 's':
                        if (! sSet)
                        {
                            maximumS = filter.MaximumAcceptedValue;
                            minimumS = filter.MinimumAcceptedValue;
                            sSet = true;
                        }
                        else
                        {
                            maximumS = Math.Min(maximumS, filter.MaximumAcceptedValue);
                            minimumS = Math.Max(minimumS, filter.MinimumAcceptedValue);
                        }
                        break;
                }
            }

            AcceptedCombinations += (xSet? (maximumX - minimumX - (minimumX != 1 && maximumX != 4000? 1UL : 0UL)) : 4000) *
                (mSet? (maximumM - minimumM - (minimumM != 1 && maximumM != 4000? 1UL : 0UL)) : 4000) *
                (aSet? (maximumA - minimumA - (minimumA != 1 && maximumA != 4000? 1UL : 0UL)) : 4000) *
                (sSet? (maximumS - minimumS - (minimumS != 1 && maximumS != 4000? 1UL : 0UL)) : 4000);
        }

        // Not taking into account "in" filters still
        for (var index = 0; index < root.Nodes.Count; index++)
        {
            var nextFilters = filters.Select(p => p).ToList();

            for (var subIndex = 0; subIndex < index; subIndex++)
            {
                nextFilters.Add(root.Nodes[subIndex].Filter.Negation);
            }

            var node = root.Nodes[index];
            nextFilters.Add(node.Filter);
            FindCombinations(node, nextFilters);
        }

        return;
    }

    private void BuildGraph(Dictionary<string, Node> dictionary, string name)
    {
        Rule rule;
        if (_rules.ContainsKey(name))
        {
            rule = _rules[name];
        }
        else
        {
            // A or R
            return;
        }

        foreach (var filter in rule.Filters)
        {
            Node nextNode;
            if (dictionary.ContainsKey(filter.Result))
            {
                nextNode = dictionary[filter.Result];
            }
            else
            {
                nextNode = new Node(filter.Result, filter);
                dictionary.Add(filter.Result, nextNode);
            }

            var currentNode = dictionary[name];
            currentNode.Nodes.Add(nextNode);
            BuildGraph(dictionary, nextNode.Name);
        }
    }

    public void Execute()
    {
        foreach (var part in _parts)
        {
            var nextRule = "in";
            while (!nextRule.StartsWith("A") && !nextRule.StartsWith("R"))
            {
                nextRule = _rules[nextRule].Apply(part);
            }

            if (nextRule.StartsWith("A"))
            {
                SumOfAcceptedParts += part.X + part.M + part.A + part.S;
            }
        }
    }
}