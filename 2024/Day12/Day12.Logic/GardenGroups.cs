using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Day12.Logic;

public record Plot(char Plant, List<(int X, int Y)> Positions, List<(int X, int Y)> Neighbors, int Area, int Perimeter);

public class GardenGroups
{
    private readonly string[] _lines;
    private readonly char[,] _plants;
    private readonly char[,] _zoomedInPlants;
    private readonly int _zoomLevel;
    private readonly bool _withZoom;
    private bool[,] _visited;
    private bool[,] _zoomedInVisited;

    public int Size => _lines.Length;
    public int ZoomedInSize => Size * _zoomLevel;
    public List<Plot> Plots { get; private set; }
    public List<Plot> ZoomedInPlots { get; private set; }
    public int PriceOfFencing { get; private set; }
    public int PriceWithBulkDiscount { get; private set; }

    public GardenGroups(string input, int? zoomLevel = null)
    {
        _lines = input.Split('\n');
        if (zoomLevel.HasValue)
        {
            _zoomLevel = zoomLevel.Value;
            _withZoom = true;
        }
        else
        {
            _zoomLevel = 1;
            _withZoom = false;
        }
        _plants = new char[Size, Size];
        _zoomedInPlants = new char[ZoomedInSize, ZoomedInSize];

        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                _plants[y, x] = _lines[y][x];

                for (var dy = 0; dy < zoomLevel; dy++)
                {
                    for (var dx = 0; dx < zoomLevel; dx++)
                    {
                        _zoomedInPlants[(y * _zoomLevel) + dy, (x * _zoomLevel) + dx] = _lines[y][x];
                    }
                }
            }
        }

        _visited = new bool[Size, Size];
        _zoomedInVisited = new bool[ZoomedInSize, ZoomedInSize];
        Plots = new();
        ZoomedInPlots = new();

        if (!_withZoom)
        {
            Parse();
            CalculatePriceOfFencing();
        }
        else
        {
            Parse2();
            //Plot(_zoomedInPlants);
            CalculateBulkDiscount();
        }
    }

    private void CalculatePriceOfFencing()
    {
        PriceOfFencing = 0;
        foreach (var plot in Plots)
        {
            PriceOfFencing += plot.Perimeter * plot.Area;
        }
    }

    private void CalculateBulkDiscount()
    {
        PriceWithBulkDiscount = 0;
        foreach (var zoomedInPlot in ZoomedInPlots)
        {
            var eastCount = 0;
            var count = 0;
            var neighbors = zoomedInPlot.Neighbors.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            var visited = new List<(int X, int Y)>();
            var direction = 'e';
            var current = neighbors.First();
            var outskirts = true;

            current = (current.X - 1, current.Y);
            while (neighbors.Any())
            {
                switch (direction)
                {
                    case 'e':
                        if (neighbors.Contains((current.X + 1, current.Y)))
                        {
                            eastCount++;
                            current = (current.X + 1, current.Y);
                            neighbors.Remove(current);
                        }
                        else
                        {
                            direction = 'E';
                            if (eastCount > 1)
                            {
                                count += 1;
                            }
                            eastCount = 0;
                        }
                        break;

                    case 'E':
                        if (outskirts)
                        {
                            if (neighbors.Contains((current.X + 1, current.Y + 1)))
                            {
                                direction = 's';
                                current = (current.X + 1, current.Y);
                            }
                            else if (neighbors.Contains((current.X, current.Y + 1)))
                            {
                                direction = 's';
                            }
                            else if (neighbors.Contains((current.X + 1, current.Y - 1)))
                            {
                                direction = 'n';
                                current = (current.X + 1, current.Y);
                            }
                            else if (neighbors.Contains((current.X, current.Y - 1)))
                            {
                                direction = 'n';
                            }
                            else
                            {
                                eastCount = 0;
                                outskirts = false;
                                direction = 'e';
                                neighbors = neighbors.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                                current = neighbors.First();
                                current = (current.X - 1, current.Y);
                            }
                        }
                        else
                        {
                            if (neighbors.Contains((current.X, current.Y + 1)))
                            {
                                direction = 's';
                            }
                            else if (neighbors.Contains((current.X, current.Y - 1)))
                            {
                                direction = 'n';
                            }
                            else
                            {
                                eastCount = 0;
                                outskirts = false;
                                direction = 'e';
                                neighbors = neighbors.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                                current = neighbors.First();
                                current = (current.X - 1, current.Y);
                            }

                        }
                        break;

                    case 's':
                        if (neighbors.Contains((current.X, current.Y + 1)))
                        {
                            current = (current.X, current.Y + 1);
                            neighbors.Remove(current);
                        }
                        else
                        {
                            direction = 'S';
                            count += 1;
                        }
                        break;

                    case 'S':
                        if (outskirts)
                        {
                           if (neighbors.Contains((current.X - 1, current.Y + 1)))
                           {
                               direction = 'w';
                               current = (current.X, current.Y + 1);
                           }
                           else if (neighbors.Contains((current.X - 1, current.Y)))
                           {
                               direction = 'w';
                           }
                           else if (neighbors.Contains((current.X + 1, current.Y + 1)))
                           {
                               direction = 'e';
                               current = (current.X, current.Y + 1);
                               eastCount = 0;
                           }
                           else if (neighbors.Contains((current.X + 1, current.Y)))
                           {
                               direction = 'e';
                               eastCount = 0;
                           }
                           else
                           {
                               outskirts = false;
                               direction = 'e';
                               eastCount = 0;
                               neighbors = neighbors.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                               current = neighbors.First();
                               current = (current.X - 1, current.Y);
                           }
                        }
                        else
                        {
                           if (neighbors.Contains((current.X - 1, current.Y)))
                           {
                               direction = 'w';
                           }
                           else if (neighbors.Contains((current.X + 1, current.Y)))
                           {
                               direction = 'e';
                               eastCount = 0;
                           }
                           else
                           {
                               outskirts = false;
                               direction = 'e';
                               eastCount = 0;
                               neighbors = neighbors.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                               current = neighbors.First();
                               current = (current.X - 1, current.Y);
                           }
                        }
                        break;

                    case 'w':
                        if (neighbors.Contains((current.X - 1, current.Y)))
                        {
                            current = (current.X - 1, current.Y);
                            neighbors.Remove(current);
                        }
                        else
                        {
                            direction = 'W';
                            count += 1;
                        }
                        break;

                    case 'W':
                        if (outskirts)
                        {
                            if (neighbors.Contains((current.X - 1, current.Y + 1)))
                            {
                                direction = 's';
                                current = (current.X - 1, current.Y);
                            }
                            else if (neighbors.Contains((current.X, current.Y + 1)))
                            {
                                direction = 's';
                            }
                            else if (neighbors.Contains((current.X - 1, current.Y - 1)))
                            {
                                direction = 'n';
                                current = (current.X - 1, current.Y);
                            }
                            else if (neighbors.Contains((current.X, current.Y - 1)))
                            {
                                direction = 'n';
                            }
                            else
                            {
                                outskirts = false;
                                eastCount = 0;
                                direction = 'e';
                                neighbors = neighbors.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                                current = neighbors.First();
                                current = (current.X - 1, current.Y);
                            }
                        }
                        else
                        {
                            if (neighbors.Contains((current.X, current.Y + 1)))
                            {
                                direction = 's';
                            }
                            else if (neighbors.Contains((current.X, current.Y - 1)))
                            {
                                direction = 'n';
                            }
                            else
                            {
                                outskirts = false;
                                eastCount = 0;
                                direction = 'e';
                                neighbors = neighbors.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                                current = neighbors.First();
                                current = (current.X - 1, current.Y);
                            }
                        }
                        break;

                    case 'n':
                        if (neighbors.Contains((current.X, current.Y - 1)))
                        {
                            current = (current.X, current.Y - 1);
                            neighbors.Remove(current);
                        }
                        else
                        {
                            direction = 'N';
                            count += 1;
                        }
                        break;

                    case 'N':
                        if (outskirts)
                        {
                            if (neighbors.Contains((current.X - 1, current.Y - 1)))
                            {
                                direction = 'w';
                                current = (current.X, current.Y - 1);
                            }
                            else if (neighbors.Contains((current.X - 1, current.Y)))
                            {
                                direction = 'w';
                            }
                            else if (neighbors.Contains((current.X + 1, current.Y - 1)))
                            {
                                direction = 'e';
                                eastCount = 0;
                                current = (current.X, current.Y - 1);
                            }
                            else if (neighbors.Contains((current.X + 1, current.Y)))
                            {
                                direction = 'e';
                                eastCount = 0;
                            }
                            else
                            {
                                outskirts = false;
                                eastCount = 0;
                                direction = 'e';
                                neighbors = neighbors.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                                current = neighbors.First();
                                current = (current.X - 1, current.Y);
                            }
                        }
                        else
                        {
                            if (neighbors.Contains((current.X - 1, current.Y)))
                            {
                                direction = 'w';
                            }
                            if (neighbors.Contains((current.X + 1, current.Y)))
                            {
                                eastCount = 0;
                                direction = 'e';
                            }
                            else
                            {
                                outskirts = false;
                                eastCount = 0;
                                direction = 'e';
                                neighbors = neighbors.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                                current = neighbors.First();
                                current = (current.X - 1, current.Y);
                            }
                        }
                        break;
                }
            }

            count++;
            PriceWithBulkDiscount += count * (zoomedInPlot.Area / (_zoomLevel * _zoomLevel));
        }
    }

    private string Plotter(char[,] map)
    {
        var sb = new StringBuilder();
        for (var y = 0; y < ZoomedInSize; y++)
        {
            for (var x = 0; x < ZoomedInSize; x++)
            {
                if (map[y, x] != '\0')
                {
                    sb.Append(map[y, x]);
                }
                else
                {
                    sb.Append(' ');
                }
            }

            sb.Append('\n');
        }

        return sb.ToString();
    }

    private void Parse()
    {
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (! _visited[y, x])
                {
                    var plants = new List<(int X, int Y)>();
                    var neighbors = new List<(int X, int Y)>();

                    Visit(x, y, _plants[y, x], plants, neighbors);
                    var perimeter = neighbors.Count;
                    var area = CalculateArea(plants);
                    Plots.Add(new(_plants[y, x], plants, neighbors, area, perimeter));
                }
            }
        }
    }

    private void Parse2()
    {
        for (var y = 0; y < ZoomedInSize; y++)
        {
            for (var x = 0; x < ZoomedInSize; x++)
            {
                if (! _zoomedInVisited[y, x])
                {
                    var plants = new List<(int X, int Y)>();
                    var neighbors = new List<(int X, int Y)>();

                    ZoomedInVisit(x, y, _zoomedInPlants[y, x], plants, neighbors);
                    var perimeter = neighbors.Count;
                    var area = CalculateZoomedInArea(plants);
                    ZoomedInPlots.Add(new(_zoomedInPlants[y, x], plants, neighbors, area, perimeter));
                }
            }
        }
    }

    private void Visit(int x, int y, char plant, List<(int X, int Y)> plants, List<(int X, int Y)> neighbors)
    {
        if (x < 0 || x >= Size || y < 0 || y >= Size || _plants[y, x] != plant)
        {
            var neighbor = (x, y);
            neighbors.Add(neighbor);

            return;
        }

        if (_visited[y, x])
        {
            return;
        }

        var current = (x, y);
        if (plants.Contains(current)) // TODO: Always false?
        {
            return;
        }

        _visited[y, x] = true;
        plants.Add(current);

        Visit(x - 1, y, plant, plants, neighbors);
        Visit(x + 1, y, plant, plants, neighbors);
        Visit(x, y - 1, plant, plants, neighbors);
        Visit(x, y + 1, plant, plants, neighbors);
    }

    private void ZoomedInVisit(int x, int y, char plant, List<(int X, int Y)> plants, List<(int X, int Y)> neighbors)
    {
        if (x == 1 && y == 0)
        {
            Debug.Print("Now");
        }
        if (x < 0 || x >= ZoomedInSize || y < 0 || y >= ZoomedInSize || _zoomedInPlants[y, x] != plant)
        {
            var neighbor = (x, y);
            if (!neighbors.Contains(neighbor))
            {
                neighbors.Add(neighbor);
            }
            return;
        }

        if (_zoomedInVisited[y, x])
        {
            return;
        }

        var current = (x, y);
        if (plants.Contains(current)) // TODO: Always false?
        {
            return;
        }

        _zoomedInVisited[y, x] = true;
        plants.Add(current);

        ZoomedInVisit(x - 1, y, plant, plants, neighbors);
        ZoomedInVisit(x + 1, y, plant, plants, neighbors);
        ZoomedInVisit(x, y - 1, plant, plants, neighbors);
        ZoomedInVisit(x, y + 1, plant, plants, neighbors);
    }

    private static int CalculateArea(List<(int X, int Y)> plants) => plants.Count;

    private static int CalculateZoomedInArea(List<(int X, int Y)> plants) => plants.Count;
 }