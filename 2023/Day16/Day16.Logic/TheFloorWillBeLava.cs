namespace Day16.Logic;

public class TheFloorWillBeLava
{
    private class Beam
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Orientation { get; set; }
    }

    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<char[]> _map;
    private readonly List<char[]> _energizedMap;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;

    public string GetEnergizedMap()
    {
        return string.Join("\n", _energizedMap.Select(p => new string(p)));
    }

    public TheFloorWillBeLava(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        _map = new List<char[]>();
        foreach (var line in _lines)
        {
            _map.Add(line.Select(c => c).ToArray());
        }

        _energizedMap = new List<char[]>();
        for (var index = 0; index < Height; index++)
        {
            _energizedMap.Add(Enumerable.Range(1, Width).Select(p => '.').ToArray());
        }
    }

    public void Energize(int cycles = 50)
    {
        var beams = new List<Beam> { new() { Orientation = 'r' } };
        var beamsToAdd = new List<Beam>();
        var processed = false;

        for (var cycle = 0; cycle < cycles; cycle++)
        {
            for (var index = 0; index < beams.Count; index++)
            {
                var beam = beams[index];
                if (beam.X >= 0 && beam.X < Width && beam.Y >= 0 && beam.Y < Height)
                {
                    _energizedMap[beam.Y][beam.X] = '#';
                    switch (_map[beam.Y][beam.X])
                    {
                        case '.':
                            switch (beam.Orientation)
                            {
                                case 'l':
                                    beam.X--;
                                    break;

                                case 'r':
                                    beam.X++;
                                    break;

                                case 'd':
                                    beam.Y++;
                                    break;

                                case 'u':
                                    beam.Y--;
                                    break;
                            }
                            break;

                        case '/':
                            switch (beam.Orientation)
                            {
                                case 'l':
                                    beam.Y++;
                                    beam.Orientation = 'd';
                                    break;

                                case 'r':
                                    beam.Y--;
                                    beam.Orientation = 'u';
                                    break;

                                case 'd':
                                    beam.X--;
                                    beam.Orientation = 'l';
                                    break;

                                case 'u':
                                    beam.X++;
                                    beam.Orientation = 'r';
                                    break;
                            }
                            break;

                        case '\\':
                            switch (beam.Orientation)
                            {
                                case 'l':
                                    beam.Y--;
                                    beam.Orientation = 'u';
                                    break;

                                case 'r':
                                    beam.Y++;
                                    beam.Orientation = 'd';
                                    break;

                                case 'd':
                                    beam.X++;
                                    beam.Orientation = 'r';
                                    break;

                                case 'u':
                                    beam.X--;
                                    beam.Orientation = 'l';
                                    break;
                            }
                            break;

                        case '-':
                            switch (beam.Orientation)
                            {
                                case 'l':
                                    beam.X--;
                                    break;

                                case 'r':
                                    beam.X++;
                                    break;

                                case 'd':
                                    beamsToAdd.Add(new Beam() { X = beam.X + 1, Y = beam.Y, Orientation = 'r' });
                                    beam.X--;
                                    beam.Orientation = 'l';
                                    break;

                                case 'u':
                                    beamsToAdd.Add(new Beam() { X = beam.X - 1, Y = beam.Y, Orientation = 'l' });
                                    beam.X++;
                                    beam.Orientation = 'r';
                                    break;
                            }
                            break;

                        case '|':
                            switch (beam.Orientation)
                            {
                                case 'l':
                                    beamsToAdd.Add(new Beam() { X = beam.X, Y = beam.Y + 1, Orientation = 'd' });
                                    beam.Y--;
                                    beam.Orientation = 'u';
                                    break;

                                case 'r':
                                    beamsToAdd.Add(new Beam() { X = beam.X, Y = beam.Y - 1, Orientation = 'u' });
                                    beam.Y++;
                                    beam.Orientation = 'd';
                                    break;

                                case 'd':
                                    beam.Y++;
                                    break;

                                case 'u':
                                    beam.Y--;
                                    break;
                            }
                            break;
                    }
                }
            }

            beams.AddRange(beamsToAdd);
            beamsToAdd.Clear();
        }
    }
}
