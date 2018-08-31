using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.App
{
    public class Snake
    {
        private const char defaultDirection = 'u';

        public Queue<int[]> CurrentPosition { get; set; }

        public Queue<int[]> NewPosition { get; set; }

        public char Direction { get; set; }

        public Snake(int[][] initialPosition)
        {
            this.CurrentPosition = new Queue<int[]>(initialPosition);
            this.NewPosition = new Queue<int[]>();
            this.Direction = defaultDirection;
        }

        public void Move()
        {
            var snakeLenght = CurrentPosition.Count;

            switch (this.Direction)
            {
                case 'u':
                    for (int i = 0; i < snakeLenght; i++)
                    {
                        var currentBlock = this.CurrentPosition.Dequeue();
                        currentBlock[1]--;
                        this.NewPosition.Enqueue(currentBlock);
                    }
                    break;
                case 'd':
                    for (int i = 0; i < snakeLenght; i++)
                    {
                        var currentBlock = this.CurrentPosition.Dequeue();
                        currentBlock[1]++;
                        this.NewPosition.Enqueue(currentBlock);
                    }
                    break;
                case 'l':
                    for (int i = 0; i < snakeLenght; i++)
                    {
                        var currentBlock = this.CurrentPosition.Dequeue();
                        currentBlock[0]--;
                        this.NewPosition.Enqueue(currentBlock);
                    }
                    break;
                case 'r':
                    for (int i = 0; i < snakeLenght; i++)
                    {
                        var currentBlock = this.CurrentPosition.Dequeue();
                        currentBlock[0]++;
                        this.NewPosition.Enqueue(currentBlock);
                    }
                    break;
            }

            this.CurrentPosition = new Queue<int[]>(this.NewPosition);
        }
    }
}
