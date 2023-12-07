
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace Day7.Logic;
public class CamelCards
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<(string Hand, int Bid)> _hands;
    private List<(string Hand, int Bid)> _handSortedByKindAndCard;

    public int Hands => _hands.Count;
    public int TotalWinnings { get; private set; }

    public CamelCards(string input)
    {
        _input = input;
        _lines = input.Split("\n");
        _hands = new List<(string, int)>();

        Parse();
        SortHandsByCard();
        CalculateTotalWinnings();
    }

    private void Parse()
    {
        foreach (var line in _lines)
        {
            var splittedLine = line.Split(" ");
            _hands.Add((splittedLine[0].Trim(), int.Parse(splittedLine[1])));
        }
    }

    private void SortHandsByCard()
    {
        var relativeValues = new Dictionary<char, int>
        {
            { 'A', 14 },
            { 'K', 13 },
            { 'Q', 12 },
            { 'J', 11 },
            { 'T', 10 },
            { '9',  9 },
            { '8',  8 },
            { '7',  7 },
            { '6',  6 },
            { '5',  5 },
            { '4',  4 },
            { '3',  3 },
            { '2',  2 }
        };

        var handsSortedByKind = _hands
            .Select(p => new { Original = p, Sorted = SortHand(p, relativeValues) })
            .Select(p => new { p.Original, p.Sorted, Weight = SortHandByWeight(p.Sorted) })
            .OrderBy(h => h.Weight)
            .ToList();

        handsSortedByKind.Sort((x, y) => HandStrengthComparer(relativeValues, x.Original.Hand, x.Weight, y.Original.Hand, y.Weight));

        _handSortedByKindAndCard = handsSortedByKind.Select(p => p.Original).ToList();
    }

    private static int HandStrengthComparer(Dictionary<char, int> relativeValues, string left, int weightLeft, string right, int weightRight)
    {
        if (weightLeft > weightRight)
        {
            return 1;
        }
        else if (weightLeft < weightRight)
        {
            return -1;
        }

        for (var index = 0; index < left.Length; index++)
        {
            if (left[index] == right[index])
            {
                continue;
            }

            if (relativeValues[left[index]] > relativeValues[right[index]])
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        return 0;
    }

    private string SortHand((string Hand, int Bid) hand, Dictionary<char, int> relativeValues)
    {
        return hand.Hand
            .Select(c => (c, relativeValues[c]))
            .OrderBy(h => h.Item2)
            .Aggregate(string.Empty, (t, i) => t = t + i.Item2.ToString("X"));
    }

    private int SortHandByWeight(string hand)
    {
        if (IsFiveOfaKind(hand))
        {
            return 6;
        }
        if (IsFourOfaKind(hand))
        {
            return 5;
        }
        if (IsFullHouse(hand))
        {
            return 4;
        }
        if (IsThreeOfaKind(hand))
        {
            return 3;
        }
        if (IsTwoPair(hand))
        {
            return 2;
        }
        if (IsOnePair(hand))
        {
            return 1;
        }

        return 0;
    }

    private bool IsFiveOfaKind(string hand) =>
        hand[0] == hand[1] && hand[1] == hand[2] && hand[2] == hand[3] && hand[3] == hand[4];

    private bool IsFourOfaKind(string hand) =>
        (hand[0] == hand[1] && hand[1] == hand[2] && hand[2] == hand[3]) ||
        (hand[1] == hand[2] && hand[2] == hand[3] && hand[3] == hand[4]);

    private bool IsFullHouse(string hand) =>
        (hand[0] == hand[1] && hand[1] == hand[2] && hand[3] == hand[4]) ||
        (hand[2] == hand[3] && hand[3] == hand[4] && hand[0] == hand[1]);

    private bool IsThreeOfaKind(string hand) =>
        (hand[0] == hand[1] && hand[1] == hand[2]) ||
        (hand[1] == hand[2] && hand[2] == hand[3]) ||
        (hand[2] == hand[3] && hand[3] == hand[4]);

    private bool IsTwoPair(string hand) =>
        (hand[0] == hand[1] && (hand[2] == hand[3] || hand[3] == hand[4])) ||
        (hand[1] == hand[2] && hand[3] == hand[4]);

    private bool IsOnePair(string hand) =>
        hand[0] == hand[1] || hand[1] == hand[2] || hand[2] == hand[3] || hand[3] == hand[4];

    private void CalculateTotalWinnings()
    {
        for (var index = 0; index < _handSortedByKindAndCard.Count; index++)
        {
            TotalWinnings += _handSortedByKindAndCard[index].Bid * (index + 1);
        }
    }
}
