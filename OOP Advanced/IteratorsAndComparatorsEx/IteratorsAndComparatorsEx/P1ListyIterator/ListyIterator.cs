﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ListyIterator<T>:IEnumerable<T>
{
    private IReadOnlyCollection<T> items;

    private int Index { get; set; }

    private bool HasNextItem => this.Index <= items.Count-2;

    public ListyIterator(params T[] items)
    {
        this.items = items;
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
        if (items.Count==0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        return items.ToArray()[Index].ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            yield return this.items.ToArray()[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

