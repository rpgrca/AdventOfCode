
namespace Day16.Logic;

public class TheFloorWillBeLava
{
    private class Beam
    {
        private readonly (int X, int Y) _source;
        public int X { get; set; }
        public int Y { get; set; }
        public char Orientation { get; set; }

        public static Beam CreateOriginalBeam() => new();

        public static Beam? SplitBeam(Beam location, List<Beam> beams, int x, int y, char orientation)
        {
            var sameSource = beams.SingleOrDefault(b => b.WasGeneratedAtSameTile(location.X, location.Y));
            if (sameSource is null)
            {
                return new Beam(location.X, location.Y) { X = x, Y = y, Orientation = orientation };
            }

            return null;
        }

        public Beam(int x, int y) => _source = (x, y);

        private Beam()
        {
            _source = (-1, -1);
            X = Y = 0;
            Orientation = 'r';
        }

        public bool WasGeneratedAtSameTile(int x, int y) => _source.X == X && _source.Y == Y;
   }

    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<char[]> _map;
    private readonly List<char[]> _energizedMap;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;

    public int EnergizedTilesCount { get; private set; }

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
        Beam? newBeam = null;
        var beams = new List<Beam> { Beam.CreateOriginalBeam() };
        var beamsToAdd = new List<Beam>();

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
                                    newBeam = Beam.SplitBeam(beam, beams, beam.X + 1, beam.Y, 'r');
                                    if (newBeam != null)
                                    {
                                        beamsToAdd.Add(newBeam);
                                    }
                                    beam.X--;
                                    beam.Orientation = 'l';
                                    break;

                                case 'u':
                                    newBeam = Beam.SplitBeam(beam, beams, beam.X - 1, beam.Y, 'l');
                                    if (newBeam != null)
                                    {
                                        beamsToAdd.Add(newBeam);
                                    }
                                    beam.X++;
                                    beam.Orientation = 'r';
                                    break;
                            }
                            break;

                        case '|':
                            switch (beam.Orientation)
                            {
                                case 'l':
                                    newBeam = Beam.SplitBeam(beam, beams, beam.X, beam.Y + 1, 'd');
                                    if (newBeam != null)
                                    {
                                        beamsToAdd.Add(newBeam);
                                    }
                                    beam.Y--;
                                    beam.Orientation = 'u';
                                    break;

                                case 'r':
                                    newBeam = Beam.SplitBeam(beam, beams, beam.X, beam.Y - 1, 'u');
                                    if (newBeam != null)
                                    {
                                        beamsToAdd.Add(newBeam);
                                    }
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

        var map = GetEnergizedMap();
        EnergizedTilesCount = map.Count(c => c == '#');
    }
}
