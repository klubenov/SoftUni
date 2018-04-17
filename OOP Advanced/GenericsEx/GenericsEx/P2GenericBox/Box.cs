using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Box<T> where T : IComparable<T>
{
    public T Item { get; }

    public Box(T item)
    {
        this.Item = item;
    }

    public int CompareTo(Box<T> other)
    {
        return other.Item.CompareTo(this.Item);
    }

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {Item}";
    }

    //public static ICollection<Box<T>> GenericSwap<T>(ICollection<Box<T>> boxes, int[] indices)
    //{
    //    var boxArray = boxes.ToArray();
    //    var firstIndex = indices[0];
    //    var secondIndex = indices[1];

    //    var elementAtFirstIndex = boxArray[firstIndex];
    //    boxArray[firstIndex] = boxArray[secondIndex];
    //    boxArray[secondIndex] = elementAtFirstIndex;

    //    return boxArray;
    //}
}

