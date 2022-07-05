using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code.Liste
{
    internal class ArrayList
    {
        private readonly int[] _data;

        public ArrayList(int[] data)
        {
            _data = data;
        }

        public ArrayList(int count)
        {
            _data = new int[count];
        }

        public void FillWithRandomNumbers(int maxValue)
        {
            var rnd = new Random();
            for (var i = 0; i < _data.Length; i++)
                _data[i] = rnd.Next(maxValue);
        }

        public bool ContainsLinear(int value)
        {
            foreach (var z in _data)
            {
                if (z == value)
                    return true;
            }

            return false;
        }

        public bool ContainsLinearOptimized(int value)
        {
            for (var i = 0; i < _data.Length; i++)
            {
                if (_data[i] != value) continue;
                Swap(0, i);
                return true;
            }

            return false;
        }

        public bool ContainsBinary(int value)
        {
            return ContainsBinary(value, 0, _data.Length - 1);
        }

        public void Print()
        {
            for (var i = 0; i < _data.Length; i++)
                Console.WriteLine($"Index: {i} | Value: {_data[i]}");
        }


        private void Swap(int pos1, int pos2)
        {
            var tmp = _data[pos1];
            _data[pos1] = _data[pos2];
            _data[pos2] = tmp;
            // (_data[pos1], _data[pos2]) = (_data[pos2], _data[pos1]);
        }

        private bool ContainsBinary(int value, int von, int bis)
        {
            Console.WriteLine($"{von} -- {bis}");

            if (von > bis)
                return false;

            var mitte = (von + bis) / 2;

            if (_data[mitte] == value)
                return true;

            if (value > _data[mitte])
                return ContainsBinary(value, mitte + 1, bis);
            else
                return ContainsBinary(value, von, mitte - 1);
        }
    }
}
