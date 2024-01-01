using System.Data;
namespace Day18.Logic;

public class LavaductLagoon3
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly int _initialX;
    private readonly int _initialY;

    public long TrenchArea { get; private set; }
    public List<(int Length, char Direction)> RealInstructions { get; }

    public LavaductLagoon3(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _initialX = 0;
        _initialY = 0;
        RealInstructions = new List<(int, char)>();

        foreach (var line in _lines)
        {
            var command = line.Split(" ");
            RealInstructions.Add((int.Parse(command[1]), command[0][0]));
        }
    }

    public void Decode()
    {
        RealInstructions.Clear();
        foreach (var line in _lines)
        {
            var command = line.Split(" ");
            var hex = command[2][1..^1];
            var direction = hex[^1] switch {
                '0' => 'R',
                '1' => 'D',
                '2' => 'L',
                _ => 'U'
            };
            var length = Convert.ToInt32(hex[1..^1], 16);

            RealInstructions.Add((length, direction));
        }
    }

    public class Square
    {
        public (int X, int Y) TopLeft { get; }
        public (int X, int Y) BottomRight { get; }

        public Square((int X, int Y) topLeft, (int X, int Y) bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }
    }

    public void CalculateArea2()
    {
        var currentX = _initialX;
        var currentY = _initialY;
        var vertices = new CircularList();
        vertices.AddLast((_initialX, _initialY));

        foreach (var instruction in RealInstructions)
        {
            switch (instruction.Direction)
            {
                case 'R':
                    currentX += instruction.Length;
                    break;

                case 'D':
                    currentY += instruction.Length;
                    break;

                case 'L':
                    currentX -= instruction.Length;
                    break;

                case 'U':
                    currentY -= instruction.Length;
                    break;
            }

            if ((currentX, currentY) != (0, 0))
            {
                vertices.AddLast((currentX, currentY));
            }
        }

        var columns = vertices.Select(p => p.Value.Y).Distinct().OrderBy(p => p).ToArray();
        var rows = vertices.Select(p => p.Value.X).Distinct().OrderBy(p => p).ToArray();

        TrenchArea = 0;
        while (vertices.Count > 0)
        {
            CircularList.CircularListNode? topLeftNode = null;
            var currentNode = vertices.Head;
            var minimum = int.MaxValue;

            while (currentNode != vertices.Tail)
            {
                if (minimum > currentNode.Value.Y)
                {
                    minimum = currentNode.Value.Y;
                    topLeftNode = currentNode;
                }

                currentNode = currentNode.Next;
            }

            if (topLeftNode  != null)
            {
                var bottomLeftNode = topLeftNode.Previous;
                var topRightNode = topLeftNode.Next;
                var bottomRightNode = topRightNode.Next;

                if (bottomLeftNode.Value.Y == bottomRightNode.Value.Y)
                {
                    var y = FindInternalRoute(vertices, topLeftNode.Value.X, topLeftNode.Value.Y, bottomRightNode.Value.X, bottomRightNode.Value.Y);
                    if (y == -1)
                    {
                        if (bottomRightNode.Next == bottomLeftNode)
                        {
                            // final square
                            vertices.Clear();
                        }
                        else
                        if (bottomRightNode.Next.Value.X < bottomRightNode.Value.X)
                        {
                            vertices.Relink(bottomLeftNode.Previous, bottomRightNode.Next);
                        }
                        else
                        {
                            if (bottomLeftNode.Previous.Value.X > bottomLeftNode.Value.X)
                            {
                            }
                            else
                            {
                                vertices.Relink(bottomLeftNode.Previous, bottomRightNode);
                            }
                        }
                        TrenchArea += (topRightNode.Value.X - topLeftNode.Value.X + 1) * (bottomLeftNode.Value.Y - topLeftNode.Value.Y + 1);
                    }
                    else
                    {
                        TrenchArea += (topRightNode.Value.X - topLeftNode.Value.X) * (y - topLeftNode.Value.Y);
                    }

                }
                else if (bottomLeftNode.Value.Y < bottomRightNode.Value.Y)
                {
                    var y = FindInternalRoute(vertices, topLeftNode.Value.X, topLeftNode.Value.Y, topRightNode.Value.X, bottomLeftNode.Value.Y);
                    if (y == -1)
                    {
                        var newNode = new CircularList.CircularListNode((topRightNode.Value.X, bottomLeftNode.Value.Y));
                        vertices.Relink(newNode, bottomLeftNode.Previous, bottomRightNode);
                        TrenchArea += (topRightNode.Value.X - topLeftNode.Value.X + 1) * (bottomLeftNode.Value.Y - topLeftNode.Value.Y + 1) - (topRightNode.Value.X - topLeftNode.Value.X - 1);
                    }
                    else
                    {
                        TrenchArea += (topRightNode.Value.X - topLeftNode.Value.X) * (y - topLeftNode.Value.Y);
                    }
                }
                else
                {
                    var y = FindInternalRoute(vertices, topLeftNode.Value.X, topLeftNode.Value.Y, bottomRightNode.Value.X, bottomRightNode.Value.Y);
                    if (y == -1)
                    {
                        var newNode = new CircularList.CircularListNode((topLeftNode.Value.X, bottomRightNode.Value.Y));
                        vertices.Relink(newNode, bottomLeftNode, bottomRightNode.Next);
                        TrenchArea += (topRightNode.Value.X - topLeftNode.Value.X) * (bottomRightNode.Value.Y - topLeftNode.Value.Y) - (topRightNode.Value.X - topLeftNode.Value.X - 1);
                    }
                    else
                    {
                        TrenchArea += (topRightNode.Value.X - topLeftNode.Value.X) * (y - topLeftNode.Value.Y);
                    }
                }
            }
        }
    }

    private int FindInternalRoute(CircularList vertices, int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
    {
        var internalVertices = vertices
            .Where(p => topLeftX < p.Value.X && p.Value.X < bottomRightX && topLeftY < p.Value.Y && p.Value.Y < bottomRightY)
            .OrderBy(p => p.Value.Y)
            .FirstOrDefault();

        if (internalVertices != default)
        {
            return internalVertices.Value.Y;
        }

        return -1;
    }
}