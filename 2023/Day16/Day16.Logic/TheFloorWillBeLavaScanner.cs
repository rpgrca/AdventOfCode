namespace Day16.Logic;

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

    public void TestConfigurations(int cycles = 50)
    {

        for (var y = 0; y < _length; y++)
        {
            var sut = new TheFloorWillBeLava(_input, 0, y, 'r');
            sut.Energize(cycles);
            if (BestEnergizedTilesCount < sut.EnergizedTilesCount)
            {
                BestEnergizedTilesCount = sut.EnergizedTilesCount;
            }
        }

        for (var y = 0; y < _length; y++)
        {
            var sut = new TheFloorWillBeLava(_input, _length - 1, y, 'l');
            sut.Energize(cycles);
            if (BestEnergizedTilesCount < sut.EnergizedTilesCount)
            {
                BestEnergizedTilesCount = sut.EnergizedTilesCount;
            }
        }

        for (var x = 0; x < _length; x++)
        {
            var sut = new TheFloorWillBeLava(_input, x, _length - 1, 'u');
            sut.Energize(cycles);
            if (BestEnergizedTilesCount < sut.EnergizedTilesCount)
            {
                BestEnergizedTilesCount = sut.EnergizedTilesCount;
            }
        }

        for (var x = 0; x < _length; x++)
        {
            var sut = new TheFloorWillBeLava(_input, x, 0, 'd');
            sut.Energize(cycles);
            if (BestEnergizedTilesCount < sut.EnergizedTilesCount)
            {
                BestEnergizedTilesCount = sut.EnergizedTilesCount;
            }
        }
    }
}