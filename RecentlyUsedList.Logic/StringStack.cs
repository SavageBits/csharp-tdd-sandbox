using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecentlyUsedList.Logic
{
    public class StringStack
    {
        private readonly List<string> _strings;

        public int Count => _strings.Count;

        private int _capacity;

        public StringStack()
        {
            _strings = new List<string>();
        }

        public StringStack(int capacity) : this()
        {
            _capacity = capacity;
        }
        
        public StringStack(string[] strings) : this()
        {
            foreach (string s in strings)
            {
                Push(s);
            }
        }

        public void Push(string aString)
        {
            if (aString.Length > 0)
            {
                if (_strings.Contains(aString))
                    _strings.Remove(aString);

                if (_capacity > 0 && _capacity == Count)
                    _strings.RemoveAt(_capacity - 1);

                _strings.Insert(0, aString);
            }            
        }

        public string this[int index]
        {
            get { return _strings[index]; }
            // no requirement for inserting at position
            //set { _strings[index] = value; }
        }

        public string Peek()
        {
            return this[0];
        }
    }
}
