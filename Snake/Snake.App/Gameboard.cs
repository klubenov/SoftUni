using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.App
{
    public class Gameboard
    {
        private const int tableWidth = 30;
        private const int tableheight = 30;

        public bool isGameOver => this.Snake.CurrentPosition.Peek()[0] >= tableWidth
                                  || this.Snake.CurrentPosition.Peek()[0] <= 0
                                  || this.Snake.CurrentPosition.Peek()[1] >= tableheight
                                  || this.Snake.CurrentPosition.Peek()[1] <= 0;

        public bool[,] Table { get; set; }

        public int[] FoodBlock { get; set; }

        public Random FoodBlockRandomGenerator { get; set; }

        public Snake Snake { get; set; }

        public Gameboard()
        {
            this.Table = new bool[tableWidth,tableheight];
            this.FoodBlockRandomGenerator = new Random();
            this.Snake = this.InitializeSnake(tableWidth, tableheight);
            this.FoodBlock = this.GenerateFoodBlock();
        }

        private Snake InitializeSnake(int initialWidth, int initialHeight)
        {
            var initialSnakePosition = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                initialSnakePosition[i] = new[] {initialWidth, initialHeight + i};
            }

            var snake = new Snake(initialSnakePosition);

            return snake;
        }

        private int[] GenerateFoodBlock()
        {
            int[][] currentSnakePositions = this.Snake.CurrentPosition.ToArray();

            int newWidth = this.FoodBlockRandomGenerator.Next(0, tableWidth);
            int newHeight = this.FoodBlockRandomGenerator.Next(0, tableheight);

            bool overlap = false;

            foreach (var snakeBlock in currentSnakePositions)
            {
                if (snakeBlock[0] == newWidth && snakeBlock[1] == newHeight)
                {
                    overlap = true;
                    break;
                }
            }

            if (overlap)
            {
                return this.GenerateFoodBlock();
            }
            else
            {
                return new[] {newWidth, newHeight};
            }
        }

        public void Move()
        {
            var snakeLenght = Snake.CurrentPosition.Count;

            switch (Snake.Direction)
            {
                case 'u':
                    var checkBlock = Snake.CurrentPosition.Peek();
                    if (checkBlock[0]==FoodBlock[0] && checkBlock[1]==FoodBlock[1])
                    {
                        
                    }

                    for (int i = 0; i < snakeLenght; i++)
                    {
                        var currentBlock = Snake.CurrentPosition.Dequeue();
                        currentBlock[1]--;
                        Snake.NewPosition.Enqueue(currentBlock);
                    }
                    break;
                case 'd':
                    for (int i = 0; i < snakeLenght; i++)
                    {
                        var currentBlock = Snake.CurrentPosition.Dequeue();
                        currentBlock[1]++;
                        Snake.NewPosition.Enqueue(currentBlock);
                    }
                    break;
                case 'l':
                    for (int i = 0; i < snakeLenght; i++)
                    {
                        var currentBlock = Snake.CurrentPosition.Dequeue();
                        currentBlock[0]--;
                        Snake.NewPosition.Enqueue(currentBlock);
                    }
                    break;
                case 'r':
                    for (int i = 0; i < snakeLenght; i++)
                    {
                        var currentBlock = Snake.CurrentPosition.Dequeue();
                        currentBlock[0]++;
                        Snake.NewPosition.Enqueue(currentBlock);
                    }
                    break;
            }

            Snake.CurrentPosition = new Queue<int[]>(Snake.NewPosition);
            Snake.NewPosition.Clear();
        }
    }
}
