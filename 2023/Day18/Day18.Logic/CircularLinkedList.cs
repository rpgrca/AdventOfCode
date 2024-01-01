namespace Day18.Logic;

using System.Collections;
using System.Diagnostics;

public class CircularList : IEnumerable<CircularList.CircularListNode>
{
    [DebuggerDisplay("{Value}")]
    public class CircularListNode
    {
        private CircularListNode _next;
        private CircularListNode _previous;

        public (int X, int Y) Value { get; }

        public CircularListNode Next
        {
            get => _next;
            set { _next = value; }
        }

        public CircularListNode Previous
        {
            get => _previous;
            set { _previous = value; }
        }

        public CircularListNode((int X, int Y) value)
        {
            Value = value;
            _previous = this;
            _next = this;
        }
    }

    public class CircularListEnumerator : IEnumerator<CircularListNode>
    {
        private readonly CircularList _list;
        private CircularListNode? _current;
        private int _currentIndex;

        public CircularListEnumerator(CircularList list)
        {
            _list = list;
            _current = _list.Head;
            _currentIndex = -1;
        }

        public CircularListNode Current => _current;

        object IEnumerator.Current => _current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_currentIndex < 0)
            {
                _current = _list.Head;
            }
            else
            {
                _current = _current.Next;
            }

            _currentIndex++;
            return _currentIndex < _list._count;
        }

        public void Reset()
        {
            _current = null;
            _currentIndex = -1;
        }
    }

    private CircularListNode? _head;
    private CircularListNode? _tail;
    public CircularListNode? Head => _head;
    public CircularListNode? Tail => _tail;
    private int _count;

    public int Count => _count;

    public CircularList()
    {
        _count = 0;
        _head = null;
        _tail = null;
    }

    public void AddLast((int X, int Y) value)
    {
        if (_tail is null || _head is null)
        {
            var newNode = new CircularListNode(value);
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            var newNode = new CircularListNode(value);
            _tail.Next = newNode;
            newNode.Previous = _tail;

            _tail = newNode;
            newNode.Next = _head;
            _head.Previous = newNode;
        }

        _count++;
    }

    public IEnumerator<CircularListNode> GetEnumerator()
    {
        return new CircularListEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Relink(CircularListNode newNode, CircularListNode previous, CircularListNode next)
    {
        for (var node = previous.Next; node != next.Previous; node = node.Next)
        {
            if (node == Head)
            {
                _head = newNode;
                _tail = previous;
            }

            if (node == Tail)
            {
                _tail = newNode;
                _head = next;
            }

            _count--;
        }

        newNode.Previous = previous;
        newNode.Next = next;
        newNode.Next.Previous = newNode;
        newNode.Previous.Next = newNode;
    }

    public void Relink(CircularListNode previous, CircularListNode next)
    {
        for (var node = previous.Next; node != next.Previous; node = node.Next)
        {
            if (node == Head)
            {
                _head = next;
                _tail = previous;
            }

            if (node == Tail)
            {
                _tail = next;
                _head = next.Next;
            }

            _count--;
        }

        previous.Next = next;
        next.Previous = previous;
    }

    internal void Clear()
    {
        _count = 0;
        _head = null;
        _tail = null;
    }
}
