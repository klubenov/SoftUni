using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P3IteratorTest
{
    public class ListIterator
    {
        private List<string> items;

        private int Index { get; set; }

        private bool HasNextItem => this.Index <= items.Count - 2;

        public ListIterator(ICollection<string> items)
        {
            if (items==null)
            {
                throw new ArgumentNullException();
            }
            this.items = items.ToList();
            this.Index = 0;
        }

        public bool Move()
        {
            if (HasNextItem)
            {
                this.Index++;
                return true;
            }
            return HasNextItem;
        }

        public bool HasNext()
        {
            return HasNextItem;
        }

        public string Print()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            return items[Index];
        }

        //public IEnumerator<string> GetEnumerator()
        //{
        //    for (int i = 0; i < this.items.Count; i++)
        //    {
        //        yield return this.items.ToArray()[i];
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
