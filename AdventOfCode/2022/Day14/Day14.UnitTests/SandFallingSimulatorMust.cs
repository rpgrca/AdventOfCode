using Day14.Logic;
using static Day14.UnitTests.Constants;

namespace Day14.UnitTests;

public class SandFallingSimulatorMust
{
    [Fact]
    public void LoadSampleMapCorrectly()
    {
        var sut = new SandFallingSimulator(SAMPLE_INPUT);
        Assert.Equal(@"..........
..........
..........
..........
....#...##
....#...#.
..###...#.
........#.
........#.
#########.", sut.GetVisualMap());
    }

    [Fact]
    public void LoadPuzzleMapCorrectly()
    {
        var sut = new SandFallingSimulator(PUZZLE_INPUT);
        Assert.Equal(@".............................................................
.............................................................
.............................................................
.............................................................
.............................................................
.............................................................
.............................................................
.............................................................
.............................................................
.............................................................
.............................................................
.............................................................
.............................................................
...............................................######........
.............................................................
............................................######.######....
.............................................................
.........................................######.######.######
.............................................................
.............................................................
......................................#####..................
.............................................................
.............................................................
...................................#####.#####...............
.............................................................
.............................................................
................................#####.#####.#####............
.............................................................
.............................................................
.............................#####.#####.#####.#####.........
.............................................................
.............................................................
................................#............................
...........................######............................
.............................................................
.............................................................
........................#...#................................
........................#...#................................
..................#######...#####............................
..................#.............#............................
..................#.............#............................
..................###############............................
.............................................................
.............................................................
.............................................................
.................................#...........................
.................................#...........................
...............................#.#...........................
...............................#.#...........................
...............................#.#...........................
...............................#.#...........................
...............................#.#...........................
...............................#.#.#.........................
...............................#.#.#.........................
...............................#####.........................
.............................................................
.............................................................
.............................................................
.............................................................
...........................#.................................
...........................###################...............
.............................................................
.............................................................
...........................................######............
.............................................................
........................................######.######........
.............................................................
.....................................######.######.######....
.............................................................
..................................######.######.######.######
.............................................................
.............................................................
.............................................................
........................#...........#........................
........................#############........................
.............................................................
.............................................................
....................######...................................
.............................................................
.................######.######...............................
.............................................................
..............######.######.######...........................
.............................................................
.............................................................
............#...#............................................
............#...#............................................
............#...#............................................
.....########...####.........................................
.....#.............#.........................................
.....#.............#.........................................
.....#.............#.........................................
.....###############.........................................
.............................................................
.............................................................
.............................................................
.............................................................
.............................................................
...#.........................................................
...#.........................................................
...#.........................................................
...#.#.......................................................
...#.#.......................................................
...#.#.......................................................
.#.#.#.......................................................
.#####.......................................................
.............................................................
.............................................................
....#....#...................................................
....#....#...................................................
....#....#...................................................
#####....#########...........................................
#................#...........................................
#................#...........................................
#................#...........................................
##################...........................................
.............................................................
.............................................................
...............#.....#.......................................
...............#.....#.......................................
...............#.....#.......................................
..............##.....######..................................
..............#...........#..................................
..............#...........#..................................
..............#############..................................
.............................................................
.............................................................
.............................................................
.............................................................
.......................#.....................................
.......................#.....................................
.....................#.#.....................................
.....................#.#.....................................
.....................#.#.#.....#.............................
.....................#.#.#.#.#.#.............................
.....................#.#.#.#.#.#.............................
.....................#.#.#.#.#.#.............................
.....................###########.............................
.............................................................
.............................................................
.............................................................
...........................############......................
.............................................................
.............................................................
.......................................#.....................
.......................................#.....................
...................................#...#.....................
...................................#...#.....................
...................................#...#.....................
...................................#...#.#...................
...................................#...#.#...................
...................................#...#.#...................
...................................#...#.#...................
...................................#.#.#.#...................
...................................#######...................", sut.GetVisualMap());
    }

    [Fact]
    public void DropSandDownCorrectly()
    {
        var sut = new SandFallingSimulator(SAMPLE_INPUT);
        sut.DropUnitOfSands(1);
        Assert.Equal(@"..........
..........
..........
..........
....#...##
....#...#.
..###...#.
........#.
......o.#.
#########.", sut.GetVisualMap());
    }

    [Fact]
    public void DropSandDownLeftCorrectly()
    {
        var sut = new SandFallingSimulator(SAMPLE_INPUT);
        sut.DropUnitOfSands(2);
        Assert.Equal(@"..........
..........
..........
..........
....#...##
....#...#.
..###...#.
........#.
.....oo.#.
#########.", sut.GetVisualMap());
    }
}