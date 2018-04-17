using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CustomList<T> where T : IComparable<T> , IEnumerable
{
    private const int DEFAULT_LENGTH = 4;

    private T[] Contents { get; set; }

    public int Count { get; private set; }

    public CustomList()
    {
        this.Contents = new T[DEFAULT_LENGTH];
        this.Count = 0;
    }

    public CustomList(ICollection<T> initialCollection)
    {
        this.Contents = initialCollection.ToArray();
        this.Count = this.Contents.Length;
    }
    
    public void Add(T element)
    {
        if (this.Count==this.Contents.Length)
        {
            var newInternalArray = new T[this.Contents.Length * 2];

            for (int i = 0; i < this.Contents.Length; i++)
            {
                newInternalArray[i] = this.Contents[i];
            }

            this.Contents = newInternalArray;
        }

        this.Contents[Count] = element;
        this.Count++;
    }

    public T Remove(int index)
    {
        var element = this.Contents[index];

        for (int i = index; i < this.Count-1; i++)
        {
            this.Contents[i] = this.Contents[i + 1];
        }

        this.Contents[Count-1] = default(T);
        Count--;

        return element;
    }

    public bool Contains(T element)
    {
        return this.Contents.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        var elementAtIndex1 = this.Contents[index1];
        this.Contents[index1] = this.Contents[index2];
        this.Contents[index2] = elementAtIndex1;
    }

    public int CountGreaterThan(T element)
    {
        int numberOfGreaterElements = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if (this.Contents[i].CompareTo(element)>0)
            {
                numberOfGreaterElements++;
            }
        }

        return numberOfGreaterElements;
    }

    public T Max()
    {
        return this.Contents.Max();
    }

    public T Min()
    {
        return this.Contents.Min();
    }

    public IEnumerator GetEnumerator()
    {
        return this.Contents.GetEnumerator();
    }

    public override string ToString()
    {
        var toStringSb = new StringBuilder();
        //for (int i = 0; i < Count; i++)
        //{
        //    toStringSb.AppendLine(this.Contents[i].ToString());
        //}
        foreach (var item in Contents.Where(i => i!=null))
        {
            toStringSb.AppendLine(item.ToString());
        }
        return toStringSb.ToString().Trim();
    }
}

