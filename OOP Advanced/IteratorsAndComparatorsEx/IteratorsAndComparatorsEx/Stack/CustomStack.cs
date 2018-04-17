using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class CustomStack<T>:IEnumerable<T>
{
    private List<T> items;

    public CustomStack()
    {
        this.items = new List<T>();
    }

    public void Push(params T[] items)
    {
        this.items.AddRange(items);
    }

    public void Pop()
    {
        if (items.Count==0)
        {
            throw new InvalidOperationException("No elements");
        }
        items.RemoveAt(items.Count-1);
    }


    public IEnumerator<T> GetEnumerator()
    {
        for (int i = items.Count-1; i >= 0; i--)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

