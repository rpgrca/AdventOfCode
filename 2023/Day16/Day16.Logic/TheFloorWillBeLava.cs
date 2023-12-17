
using System.Diagnostics;

namespace Day16.Logic;

public class TheFloorWillBeLava
{
    [DebuggerDisplay("({X},{Y},{Orientation}) from ({_source.X},{_source.Y})")]
    private class Beam
    {
        private readonly (int X, int Y) _source;
        public int X { get; set; }
        public int Y { get; set; }
        public char Orientation { get; set; }

        public static Beam CreateOriginalBeam(int x, int y, char orientation) => new(x, y, orientation);

        public static Beam? SplitBeam(Beam location, List<Beam> beams, int x, int y, char orientation)
        {
            if (location.X == 80 && location.Y == 70)
            {
                System.Diagnostics.Debugger.Break();
            }

            var otherBeamGeneratedAtSameLocation = beams.SingleOrDefault(b => b.WasGeneratedAtTile(location.X, location.Y));
            if (otherBeamGeneratedAtSameLocation is null)
            {
                return new Beam(location.X, location.Y) { X = x, Y = y, Orientation = orientation };
            }

            return null;
        }

        public Beam(int x, int y) => _source = (x, y);

        private Beam(int x, int y, char orientation)
        {
            _source = (-1, -1);
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public bool WasGeneratedAtTile(int x, int y) => _source.X == x && _source.Y == y;

        public bool HasSameGenerationTileAs(Beam beam) => _source == beam._source;
   }

    private readonly string _input;
    private readonly int _startingX;
    private readonly int _startingY;
    private readonly char _startingOrientation;
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

    public TheFloorWillBeLava(string input, int x = 0, int y = 0, char orientation = 'r')
    {
        _input = input;
        _startingX = x;
        _startingY = y;
        _startingOrientation = orientation;
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
        var beams = new List<Beam> { Beam.CreateOriginalBeam(_startingX, _startingY, _startingOrientation) };
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
                                        if (! beamsToAdd.Any(b => b.HasSameGenerationTileAs(newBeam)))
                                        {
                                            beamsToAdd.Add(newBeam);
                                        }
                                    }
                                    beam.X--;
                                    beam.Orientation = 'l';
                                    break;

                                case 'u':
                                    newBeam = Beam.SplitBeam(beam, beams, beam.X - 1, beam.Y, 'l');
                                    if (newBeam != null)
                                    {
                                        if (! beamsToAdd.Any(b => b.HasSameGenerationTileAs(newBeam)))
                                        {
                                            beamsToAdd.Add(newBeam);
                                        }
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
                                        if (! beamsToAdd.Any(b => b.HasSameGenerationTileAs(newBeam)))
                                        {
                                            beamsToAdd.Add(newBeam);
                                        }
                                    }
                                    beam.Y--;
                                    beam.Orientation = 'u';
                                    break;

                                case 'r':
                                    newBeam = Beam.SplitBeam(beam, beams, beam.X, beam.Y - 1, 'u');
                                    if (newBeam != null)
                                    {
                                        if (! beamsToAdd.Any(b => b.HasSameGenerationTileAs(newBeam)))
                                        {
                                            beamsToAdd.Add(newBeam);
                                        }
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


public class TheFloorWillBeLavaScanner
{
    private readonly string _input;
    private readonly int _length;
    public int BestEnergizedTilesCount { get; private set; }

    public TheFloorWillBeLavaScanner(string input)
    {
        _input = input;
        _length = _input.Count(c => c == '\n') + 1;
    }

    public void TestConfigurations()
    {

        for (var y = 0; y < _length; y++)
        {
            var sut = new TheFloorWillBeLava(_input, 0, y, 'r');
            sut.Energize();
            if (BestEnergizedTilesCount < sut.EnergizedTilesCount)
            {
                BestEnergizedTilesCount = sut.EnergizedTilesCount;
            }
        }

        for (var y = 0; y < _length; y++)
        {
            var sut = new TheFloorWillBeLava(_input, _length - 1, y, 'l');
            sut.Energize();
            if (BestEnergizedTilesCount < sut.EnergizedTilesCount)
            {
                BestEnergizedTilesCount = sut.EnergizedTilesCount;
            }
        }

        for (var x = 0; x < _length; x++)
        {
            var sut = new TheFloorWillBeLava(_input, x, _length - 1, 'u');
            sut.Energize();
            if (BestEnergizedTilesCount < sut.EnergizedTilesCount)
            {
                BestEnergizedTilesCount = sut.EnergizedTilesCount;
            }
        }

        for (var x = 0; x < _length; x++)
        {
            var sut = new TheFloorWillBeLava(_input, x, 0, 'd');
            sut.Energize();
            if (BestEnergizedTilesCount < sut.EnergizedTilesCount)
            {
                BestEnergizedTilesCount = sut.EnergizedTilesCount;
            }
        }
    }
}