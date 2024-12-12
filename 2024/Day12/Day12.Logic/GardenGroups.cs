


namespace Day12.Logic;

public record Position(int X, int Y);
public record Plot(char Plant, List<Position> Positions, int Area, int Perimeter);

public class GardenGroups
{
    private readonly string[] _lines;
    private readonly char[,] _plants;
    private bool[,] _visited;

    public int Size => _lines.Length;
    public List<Plot> Plots { get; private set; }
    public int PriceOfFencing { get; private set; }

    public GardenGroups(string input)
    {
        _lines = input.Split('\n');
        _plants = new char[Size, Size];

        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                _plants[y, x] = _lines[y][x];
            }
        }

        _visited = new bool[Size, Size];
        Plots = new();

        Parse();
        CalculatePriceOfFencing();
    }

    private void CalculatePriceOfFencing()
    {
        PriceOfFencing = 0;
        foreach (var plot in Plots)
        {
            PriceOfFencing += plot.Perimeter * plot.Area;
        }
    }

    private void Parse()
    {
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (! _visited[y, x])
                {
                    var plants = new List<Position>();
                    var neighbors = new List<Position>();

                    Visit(x, y, _plants[y, x], plants, neighbors);
                    var perimeter = neighbors.Count;
                    var area = CalculateArea(plants);
                    Plots.Add(new(_plants[y, x], plants, area, perimeter));
                }
            }
        }
    }

    private void Visit(int x, int y, char plant, List<Position> plants, List<Position> neighbors)
    {
        if (x < 0 || x >= Size || y < 0 || y >= Size || _plants[y, x] != plant)
        {
            var neighbor = new Position(x, y);
            neighbors.Add(neighbor);

            return;
        }

        if (_visited[y, x])
        {
            return;
        }

        var current = new Position(x, y);
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

    private static int CalculateArea(List<Position> plants) => plants.Count;

/*
    public void ZoomIn(int level)
    {
        char[,] zoomedInPlants = new char[Size * level, Size * level];
        _visited = new bool[Size * level, Size * level];
    }*/
}