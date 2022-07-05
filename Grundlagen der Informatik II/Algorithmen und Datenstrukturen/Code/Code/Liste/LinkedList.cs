using System;

namespace Code.Liste
{
    internal class LinkedList
    {
        private ListElement _head = null;
        private ListElement _tail = null;

        public int Count { get; private set; } = 0;

        public void PushFront(int i)
        {
            var element = new ListElement
            {
                Value = i
            };
            if (_head == null)
            {
                _head = element;
                _tail = element;
            }
            else
            {
                element.Next = _head;
                _head = element;
            }

            Count++;
        }

        public void PushBack(int i)
        {
            var element = new ListElement
            {
                Value = i
            };

            if (_tail == null)
            {
                _head = element;
                _tail = element;
            }
            else
            {
                _tail.Next = element;
                _tail = element;
            }

            Count++;
        }

        public void FillWithRandomNumbers(int count, int maxValue)
        {
            var rnd = new Random();

            for (var i = 0; i < count; i++)
            {
                PushFront(rnd.Next(maxValue));
            }
        }

        public bool ContainsLinear(int value)
        {
            var aktuell = _head;

            while (aktuell != null)
            {
                if (aktuell.Value == value) return true;
                aktuell = aktuell.Next;
            }

            return false;
        }

        public bool ContainsLinearOptimized(int value)
        {
            var aktuell = _head;

            while (aktuell != null)
            {
                if (aktuell.Value == value)
                {
                    Swap(aktuell, _head);
                    return true;
                }
                aktuell = aktuell.Next;
            }

            return false;
        }


        public void Print()
        {
            var aktuell = _head;

            while (aktuell != null)
            {
                Console.WriteLine(aktuell.Value);
                aktuell = aktuell.Next;
            }
        }

        private void Swap(ListElement le1, ListElement le2)
        {
            var tmp = le1.Value;
            le1.Value = le2.Value;
            le2.Value = tmp;
            // (le1.Value, le2.Value) = (le2.Value, le1.Value);
        }
    }
}
