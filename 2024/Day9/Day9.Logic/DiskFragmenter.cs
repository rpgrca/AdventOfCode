
namespace Day9.Logic;

public record ContiguousSpace(int Id, int Length);

public class DiskFragmenter
{
    private readonly string _input;

    public int Length => _input.Length;
    public List<ContiguousSpace> Map { get; set; }

    public DiskFragmenter(string input)
    {
        _input = input;
        Map = new();

        Parse();
    }

    private void Parse()
    {
        var isFile = true;
        var id = 0;
        foreach (var space in _input.Select(p => p - '0'))
        {
            if (isFile)
            {
                Map.Add(new(id++, space));
            }
            else
            {
                if (space > 0)
                {
                    Map.Add(new(-1, space));
                }
            }

            isFile = !isFile;
        }
    }
}