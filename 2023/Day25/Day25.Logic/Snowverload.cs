using System.Numerics;
using System.Security.Cryptography;

namespace Day25.Logic;

public class Snowverload
{
    private readonly string _input;
    private readonly string[] _lines;
    public int InputLength => _lines.Length;

    public Dictionary<string, List<string>> Components { get; }
    public List<(string Left, string Right)> WeakLinks { get; private set; }
    public int SizeMultiplication { get; private set; }

    public Snowverload(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        Components = new Dictionary<string, List<string>>();
        foreach (var line in _lines)
        {
            var values = line.Split(": ");
            var components = values[1].Split(" ");
            foreach (var component in components)
            {
                if (! Components.ContainsKey(component))
                {
                    Components.Add(component, new List<string>());
                }

                Components[component].Add(values[0]);
            }

            if (! Components.ContainsKey(values[0]))
            {
                Components.Add(values[0], new List<string>());
            }

            Components[values[0]].AddRange(components);
        }

        CalculateWeakLinks();

/*

rhnfrs, 4] (distance 4)
[frsrhn, 4] (distance 4)
[xhkfrs, 4] (distance 4)
[frsxhk, 4] (distance 4)
[frsntq, 4] (distance 4)
[ntqfrs, 4]
*/

/*
        if (Components.ContainsKey("tmr"))
        {
            var paths = FindShortestPath("tmr", "vnj", 10);

            WeakLinks = new List<(string Left, string Right)>();
            foreach (var path in paths)
            {
                for (var index = 0; index < path.Count - 1; index++)
                {
                    if (!WeakLinks.Contains((path[index], path[index+1])) && !WeakLinks.Contains((path[index+1], path[index])))
                    {
                        WeakLinks.Add((path[index], path[index+1]));
                    }
                }
            }
        }
        else
        {
            var paths = FindShortestPath("rhn", "frs", 4);

            WeakLinks = new List<(string Left, string Right)>();
            foreach (var path in paths)
            {
                for (var index = 0; index < path.Count - 1; index++)
                {
                    if (!WeakLinks.Contains((path[index], path[index+1])) && !WeakLinks.Contains((path[index+1], path[index])))
                    {
                        WeakLinks.Add((path[index], path[index+1]));
                    }
                }
            }

        }
*/

        //var dictionary = new Dictionary<string, (string Source, string Target, int Distance)>();
        var distances = new Dictionary<string, int>();
/*
        var keys = Components.Keys.Select(p => p).ToList();
        var toVisit = new List<string>();

        foreach (var (key, values) in Components)
        {
            foreach (var value in values)
            {
                distances.Add(key + value, 1);
            }
        }

        var excluded = new List<string>();
        foreach (var (key, values) in Components)
        {
            foreach (var value in values)
            {
                excluded.Add(key);
                CalculateDistances(key, distances, Components[value].Except(excluded), excluded, 2);
                Console.WriteLine($"Distances {distances.Count}, larger {distances.Max(p => p.Value)}");
                excluded.Remove(key);
            }
        }

        var max = distances.Max(p => p.Value);
        foreach (var x in distances.Where(p => p.Value >= max - 2))
        {
            Console.WriteLine($"{x} (distance {max})");
        }
*/

        foreach (var (key, values) in Components)
        {
            foreach (var child in values.Where(p => p != key))
            {
                foreach (var grandchild in Components[child].Where(p => p != child && p != key))
                {
                    if (! distances.ContainsKey(key + grandchild))
                    {
                        distances.Add(key + grandchild, 2);
                    }
                }
            }
        }

        foreach (var (key, values) in Components)
        {
            foreach (var child in values.Where(p => p != key))
            {
                foreach (var grandchild in Components[child].Where(p => p != child && p != key))
                {
                    foreach (var grandgrandchild in Components[grandchild].Where(p => p != key && p != child && p != grandchild))
                    {
                        if (! distances.ContainsKey(key + grandgrandchild))
                        {
                            distances.Add(key + grandgrandchild, 3);
                        }
                    }
                }
            }
        }

        foreach (var (key, values) in Components)
        {
            foreach (var child in values.Where(p => p != key))
            {
                foreach (var grandchild in Components[child].Where(p => p != child && p != key))
                {
                    foreach (var grandgrandchild in Components[grandchild].Where(p => p != key && p != child && p != grandchild))
                    {
                        foreach (var gggchild in Components[grandgrandchild].Where(p => p != key && p != child && p != grandchild && p != grandgrandchild))
                        {
                            if (! distances.ContainsKey(key + gggchild))
                            {
                                distances.Add(key + gggchild, 4);
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine(distances.Count);
        foreach (var (key, values) in Components)
        {
            foreach (var child in values.Where(p => p != key))
            {
                foreach (var grandchild in Components[child].Where(p => p != child && p != key))
                {
                    foreach (var grandgrandchild in Components[grandchild].Where(p => p != key && p != child && p != grandchild))
                    {
                        foreach (var gggchild in Components[grandgrandchild].Where(p => p != key && p != child && p != grandchild && p != grandgrandchild))
                        {
                            foreach (var ggggchild in Components[gggchild].Where(p => p != key && p != child && p != grandchild && p != grandgrandchild && p != gggchild))
                            {
                                if (! distances.ContainsKey(key + ggggchild))
                                {
                                    distances.Add(key + ggggchild, 5);
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine(distances.Count);
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    if (! distances.ContainsKey(key + g5))
                                    {
                                        distances.Add(key + g5, 6);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);

        var oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        if (! distances.ContainsKey(key + g6))
                                        {
                                            distances.Add(key + g6, 7);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            if (! distances.ContainsKey(key + g7))
                                            {
                                                distances.Add(key + g7, 8);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                if (! distances.ContainsKey(key + g8))
                                                {
                                                    distances.Add(key + g8, 9);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    if (! distances.ContainsKey(key + g9))
                                                    {
                                                        distances.Add(key + g9, 10);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        if (! distances.ContainsKey(key + g10))
                                                        {
                                                            distances.Add(key + g10, 11);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            if (! distances.ContainsKey(key + g11))
                                                            {
                                                                distances.Add(key + g11, 12);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                if (! distances.ContainsKey(key + g12))
                                                                {
                                                                    distances.Add(key + g12, 13);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                foreach (var g13 in Components[g12].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12))
                                                                {
                                                                    if (! distances.ContainsKey(key + g13))
                                                                    {
                                                                        distances.Add(key + g13, 14);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                foreach (var g13 in Components[g12].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12))
                                                                {
                                                                    foreach (var g14 in Components[g13].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13))
                                                                    {
                                                                        if (! distances.ContainsKey(key + g14))
                                                                        {
                                                                            distances.Add(key + g14, 15);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                foreach (var g13 in Components[g12].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12))
                                                                {
                                                                    foreach (var g14 in Components[g13].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13))
                                                                    {
                                                                        foreach (var g15 in Components[g14].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14))
                                                                        {
                                                                            if (! distances.ContainsKey(key + g15))
                                                                            {
                                                                                distances.Add(key + g15, 16);
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                foreach (var g13 in Components[g12].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12))
                                                                {
                                                                    foreach (var g14 in Components[g13].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13))
                                                                    {
                                                                        foreach (var g15 in Components[g14].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14))
                                                                        {
                                                                            foreach (var g16 in Components[g15].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15))
                                                                            {
                                                                                if (! distances.ContainsKey(key + g16))
                                                                                {
                                                                                    distances.Add(key + g16, 17);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                foreach (var g13 in Components[g12].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12))
                                                                {
                                                                    foreach (var g14 in Components[g13].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13))
                                                                    {
                                                                        foreach (var g15 in Components[g14].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14))
                                                                        {
                                                                            foreach (var g16 in Components[g15].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15))
                                                                            {
                                                                                foreach (var g17 in Components[g16].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15 && p != g16))
                                                                                {
                                                                                    if (! distances.ContainsKey(key + g17))
                                                                                    {
                                                                                        distances.Add(key + g17, 18);
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                foreach (var g13 in Components[g12].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12))
                                                                {
                                                                    foreach (var g14 in Components[g13].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13))
                                                                    {
                                                                        foreach (var g15 in Components[g14].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14))
                                                                        {
                                                                            foreach (var g16 in Components[g15].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15))
                                                                            {
                                                                                if (! distances.ContainsKey(key + g16))
                                                                                {
                                                                                    distances.Add(key + g16, 17);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                foreach (var g13 in Components[g12].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12))
                                                                {
                                                                    foreach (var g14 in Components[g13].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13))
                                                                    {
                                                                        foreach (var g15 in Components[g14].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14))
                                                                        {
                                                                            foreach (var g16 in Components[g15].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15))
                                                                            {
                                                                                foreach (var g17 in Components[g16].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15 && p != g16))
                                                                                {
                                                                                    if (! distances.ContainsKey(key + g17))
                                                                                    {
                                                                                        distances.Add(key + g17, 18);
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (distances.Count != oldDistance)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                foreach (var g13 in Components[g12].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12))
                                                                {
                                                                    foreach (var g14 in Components[g13].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13))
                                                                    {
                                                                        foreach (var g15 in Components[g14].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14))
                                                                        {
                                                                            foreach (var g16 in Components[g15].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15))
                                                                            {
                                                                                foreach (var g17 in Components[g16].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15 && p != g16))
                                                                                {
                                                                                    foreach (var g18 in Components[g17].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15 && p != g16 && p != g17))
                                                                                    {
                                                                                        if (! distances.ContainsKey(key + g18))
                                                                                        {
                                                                                            distances.Add(key + g18, 19);
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        if (oldDistance != distances.Count)
        {
            oldDistance = distances.Count;
        foreach (var (key, values) in Components)
        {
            foreach (var c in values.Where(p => p != key))
            {
                foreach (var g1 in Components[c].Where(p => p != c && p != key))
                {
                    foreach (var g2 in Components[g1].Where(p => p != key && p != c && p != g1))
                    {
                        foreach (var g3 in Components[g2].Where(p => p != key && p != c && p != g1 && p != g2))
                        {
                            foreach (var g4 in Components[g3].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3))
                            {
                                foreach (var g5 in Components[g4].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4))
                                {
                                    foreach (var g6 in Components[g5].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5))
                                    {
                                        foreach (var g7 in Components[g6].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6))
                                        {
                                            foreach (var g8 in Components[g7].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7))
                                            {
                                                foreach (var g9 in Components[g8].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8))
                                                {
                                                    foreach (var g10 in Components[g9].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9))
                                                    {
                                                        foreach (var g11 in Components[g10].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10))
                                                        {
                                                            foreach (var g12 in Components[g11].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11))
                                                            {
                                                                foreach (var g13 in Components[g12].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12))
                                                                {
                                                                    foreach (var g14 in Components[g13].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13))
                                                                    {
                                                                        foreach (var g15 in Components[g14].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14))
                                                                        {
                                                                            foreach (var g16 in Components[g15].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15))
                                                                            {
                                                                                foreach (var g17 in Components[g16].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15 && p != g16))
                                                                                {
                                                                                    foreach (var g18 in Components[g17].Where(p => p != key && p != c && p != g1 && p != g2 && p != g3 && p != g4 && p != g5 && p != g6 && p != g7 && p != g8 && p != g9 && p != g10 && p != g11 && p != g12 && p != g13 && p != g14 && p != g15 && p != g16 && p != g17))
                                                                                    {
                                                                                        if (! distances.ContainsKey(key + g18))
                                                                                        {
                                                                                            distances.Add(key + g18, 19);
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(distances.Count);
        }

        var max = distances.Max(p => p.Value);
        foreach (var x in distances.Where(p => p.Value >= max - 1))
        {
            Console.WriteLine($"{x} (distance {max})");
        }

    }

    private List<List<string>> FindShortestPath(string source, string target, int maxSteps)
    {
        var result = new List<List<string>>();
        foreach (var c in Components[source])
        {
            var path = new List<string> { source };
            if (FindShortestPath(c, target, maxSteps - 1, path))
            {
                result.Add(path);
            }
        }

        return result;
    }

    private bool FindShortestPath(string source, string target, int maxSteps, List<string> path)
    {
        foreach (var c in Components[source].Except(path))
        {
            path.Add(c);
            if (c == target)
            {
                return true;
            }

            if (maxSteps > 1)
            {
                var result = FindShortestPath(c, target, maxSteps - 1, path);
                if (result)
                {
                    return true;
                }
            }

            path.Remove(c);
        }

        return false;
    }

    private void CalculateDistances(string key, Dictionary<string, int> distances, IEnumerable<string> components, List<string> excluded, int depth)
    {
        var process = new List<string>();
        foreach (var g in components)
        {
            if (! distances.ContainsKey(key + g) || ! distances.ContainsKey(g + key))
            {
                distances.Add(key + g, depth);
                distances.Add(g + key, depth);
                process.Add(g);
            }
            else
            {
                if (distances[key + g] > depth)
                {
                    distances[key + g] = depth;
                    distances[g + key] = depth;
                    process.Add(g);
                }
            }
        }

        foreach (var g in process)
        {
            excluded.Add(g);
            CalculateDistances(key, distances, Components[g].Except(excluded), excluded, depth + 1);
            excluded.Remove(g);
        }
    }

    private void CalculateWeakLinks()
    {
        WeakLinks = new List<(string Left, string Right)>();

        foreach (var (source, targets) in Components)
        {
           foreach (var target in targets.Where(p => p != source))
            {
                var bypass = false;
                var grandchildren = Components[target];
                foreach (var grandchild in grandchildren.Where(p => p != target && p != source))
                {
                    bypass = ExistsBypassFrom(source, grandchild, target);
                    if (bypass)
                    {
                        break;
                    }
                }

                if (! bypass)
                {
                    if (!WeakLinks.Contains((source, target)) && !WeakLinks.Contains((target, source)))
                    {
                        WeakLinks.Add((source, target));
                    }
                }
            }
        }
    }

    public void CalculateGroups()
    {
        SizeMultiplication = 1;
        for (var first = 0; first < WeakLinks.Count - 2; first++)
        {
            var transition1 = WeakLinks[first];
            Components[transition1.Left].Remove(transition1.Right);
            Components[transition1.Right].Remove(transition1.Left);

            for (var second = first + 1; second < WeakLinks.Count - 1; second++)
            {
                var transition2 = WeakLinks[second];
                Components[transition2.Left].Remove(transition2.Right);
                Components[transition2.Right].Remove(transition2.Left);

                //Console.WriteLine($"{DateTime.Now} Testing nodes {WeakLinks[first]}-{WeakLinks[second]}");
                for (var third = second + 1; third < WeakLinks.Count; third++)
                {
                    var transition3 = WeakLinks[third];

                    Components[transition3.Left].Remove(transition3.Right);
                    Components[transition3.Right].Remove(transition3.Left);

                    var groups = SplitInGroups();
                    if (groups.Item1 * groups.Item2 != 0)
                    {
                        SizeMultiplication = groups.Item1 * groups.Item2;
                        Console.WriteLine($"Found possible solution: {SizeMultiplication}");
                    }

                    Components[transition3.Left].Add(transition3.Right);
                    Components[transition3.Right].Add(transition3.Left);
                }

                Components[transition2.Left].Add(transition2.Right);
                Components[transition2.Right].Add(transition2.Left);
            }

            Components[transition1.Left].Add(transition1.Right);
            Components[transition1.Right].Add(transition1.Left);
        }

    }

    private bool ExistsBypassFrom(string source, string target, string skipping)
    {
        var level1s = Components[source];
        if (level1s.Contains(target))
        {
            return true;
        }

        foreach (var level2 in level1s.Where(p => p != skipping))
        {
            if (level2 == target)
            {
                return true;
            }

            foreach (var level3 in Components[level2].Where(p => p != skipping))
            {
                if (level3 == target)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private (int, int) SplitInGroups()
    {
        var node = Components.ElementAt(0).Key;
        var visited = new HashSet<string>() { node };

        CountNodes(node, visited);

        if (visited.Count == Components.Count)
        {
            return (0, 0);
        }
        else
        {
            var visited2 = new HashSet<string>();
            node = Components.Keys.First(p => !visited.Contains(p));
            CountNodes(node, visited2);
            if (visited.Count + visited2.Count == Components.Count)
            {
                return (visited.Count, visited2.Count);
            }
            else
            {
                return (0, 0);
            }
        }
    }

    private void CountNodes1(string root, HashSet<string> visited)
    {
        foreach (var node in Components[root].Except(visited))
        {
            if (! visited.Contains(node))
            {
                visited.Add(node);
                CountNodes1(node, visited);
            }
        }
    }

    private void CountNodes(string root, HashSet<string> visited)
    {
        var left = new List<string>();
        left.AddRange(Components[root]);
        var index = 0;

        while (index < left.Count)
        {
            var node = left[index];
            if (! visited.Contains(node))
            {
                visited.Add(node);
                left.AddRange(Components[node]);
            }

            index++;
        }
    }
}
