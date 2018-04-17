using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Lake:IEnumerable<int>
{
    private int[] stones;

    public Lake(int[] stones)
    {
        this.stones = stones;
    }


    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < stones.Length; i+=2)
        {
            yield return stones[i];
        }
        for (int i = stones.Length-1; i >= 1; i--)
        {
            if (i%2==1)
            {
                yield return stones[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

