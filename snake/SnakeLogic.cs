using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    internal class SnakeLogic
    {
        private Snake TheSnake { get; set; }
        public List<int[]> Snake { get; private set; } = new List<int[]>() { new int[] { 5, 6 }, new int[] { 4, 6 }, new int[] { 3, 6 }, new int[] { 2, 6 }, new int[] { 2, 7 }, new int[] { 2, 8 } };
        public List<int[]> Apples { get; private set; } = new List<int[]>() { new int[] { 2, 3 }, new int[] { 0, 0 }, new int[] { 12, 8 } };
        public int MaxApples { get; private set; }

        // setting set public so it takes less time for direction to reach the program
        public string Direction { get; set; } = "right";

        public SnakeLogic(Snake snake)
        {
            TheSnake = snake;
            MaxApples = snake.TheSettings.AmountOfApples;
        }

        public void MoveSnake()
        {
            while (true)
            {
                //Console.BackgroundColor = ConsoleColor.Green;
                if (Direction == "top")
                {
                    Snake.Add(new int[] { Snake[Snake.Count - 1][0], Snake[Snake.Count - 1][1] - 1 });
                } 
                else if (Direction == "right")
                {
                    Snake.Add(new int[] { Snake[Snake.Count - 1][0] + 1, Snake[Snake.Count - 1][1] });
                }
                else if (Direction == "bottom")
                {
                    Snake.Add(new int[] { Snake[Snake.Count - 1][0], Snake[Snake.Count - 1][1] + 1 });
                }
                else if (Direction == "left")
                {
                    Snake.Add(new int[] { Snake[Snake.Count - 1][0] - 1, Snake[Snake.Count - 1][1] });
                }
                if (!EatApples())
                {
                    Snake.RemoveAt(0);
                }
                Thread.Sleep(TheSnake.TheSettings.Speed);
                // Task.Delay(200); task delay wont work for some reason i dont care enough to check why
            }
        }
        public bool EatApples()
        {
            // checks if the snakes first item is on the same block as any item of the apples list
            bool ateApples = false;
            for (int i = 0; i < Apples.Count; i++)
            {
                if (Snake[Snake.Count - 1][0] == Apples[i][0] && Snake[Snake.Count - 1][1] == Apples[i][1])
                {
                    Apples.RemoveAt(i);
                    GenerateApples();
                    ateApples = true;
                    // call generate apples
                } 
            }
            return ateApples;
        }
        public void GenerateApples()
        {
            while (Apples.Count < MaxApples && true)
            {

            }
        }

        public bool CanMoveThatDirection(string nextDirection)
        {
            // an easy way to check if the directions are opposite
            // instead of writing too much code
            // will break if direction names change tho haha
            if (nextDirection.Length + Direction.Length == 9) return false;
            else return true;
        }
    }
}
