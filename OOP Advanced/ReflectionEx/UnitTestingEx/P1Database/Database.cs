using System;
using System.Collections.Generic;
using System.Text;

namespace P1Database
{
    public class Database
    {
        private const int DEFAULT_CAPACITY = 16;

        private int[] numbers;

        private int currentIndex;

        private Database()
        {
            this.numbers = new int[DEFAULT_CAPACITY];
            this.currentIndex = 0;
        }

        public Database(params int[] inputValues)
            :this()
        {
            if (inputValues.Length>DEFAULT_CAPACITY)
            {
                throw new InvalidOperationException($"Database cannot hold more than {DEFAULT_CAPACITY} elements!");
            }
            Array.Copy(inputValues,this.numbers,inputValues.Length);
            this.currentIndex = inputValues.Length;
        }

        public void Add(int value)
        {
            if (this.currentIndex==DEFAULT_CAPACITY)
            {
                throw new InvalidOperationException($"Database is already full, cannot add {value}!");
            }
            numbers[this.currentIndex] = value;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex==0)
            {
                throw new InvalidOperationException("Database is empty, there is no item to remove!");
            }
            this.currentIndex--;
            this.numbers[this.currentIndex] = default(int);
        }

        public int[] Fetch()
        {
            var newArray = new int[this.currentIndex];
            for (int i = 0; i < this.currentIndex; i++)
            {
                newArray[i] = numbers[i];
            }

            return newArray;
        }
    }
}
