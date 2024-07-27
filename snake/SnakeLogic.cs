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
        public List<int[]> Snake { get; private set; }
        public List<int[]> Apples { get; private set; }
        public int MaxApples { get; private set; }

        // setting set public so it takes less time for direction to reach the program
        public string Direction { get; set; } = "right";

        public SnakeLogic(Snake snake)
        {
            TheSnake = snake;
            Snake = new List<int[]>() { new int[] { 0, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2)}, new int[] { 1, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) }, new int[] { 2, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) } };
            if (TheSnake.TheSettings.AmountOfApples == 1)
            {
                Apples = new List<int[]>() { new int[] { 9, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) }};
            }
            else if (TheSnake.TheSettings.AmountOfApples == 3)
            {
                Apples = new List<int[]>() { new int[] { 9, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) }, new int[] { 8, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) + 1}, new int[] { 8, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) - 1} };
            }
            else if (TheSnake.TheSettings.AmountOfApples == 5)
            {
                Apples = new List<int[]>() { new int[] { 9, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) }, new int[] { 8, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) + 1 }, new int[] { 8, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) - 1 }, new int[] { 10, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) + 1 }, new int[] { 10, (int)Math.Floor((double)TheSnake.TheSettings.MapSize[1] / 2) - 1 } };

            }
            MaxApples = snake.TheSettings.AmountOfApples;
        }

        public void MoveSnake()
        {
            while (!TheSnake.GameEnded)
            {
                //Console.BackgroundColor = ConsoleColor.Green;
                if (Direction == "top")
                {
                    if (WillCollideThatMove(0, -1)) TheSnake.TheGameEnding.LostTheGame();
                    else
                    {
                        Snake.Add(new int[] { Snake[Snake.Count - 1][0], Snake[Snake.Count - 1][1] - 1 });
                    }
                }
                else if (Direction == "right")
                {
                    if (WillCollideThatMove(1, 0)) TheSnake.TheGameEnding.LostTheGame();
                    else
                    {
                        Snake.Add(new int[] { Snake[Snake.Count - 1][0] + 1, Snake[Snake.Count - 1][1] });
                    }
                }
                else if (Direction == "bottom")
                {
                    if (WillCollideThatMove(0, +1)) TheSnake.TheGameEnding.LostTheGame();
                    else
                    {
                        Snake.Add(new int[] { Snake[Snake.Count - 1][0], Snake[Snake.Count - 1][1] + 1 });
                    }
                }
                else if (Direction == "left")
                {
                    if (WillCollideThatMove(-1, 0)) TheSnake.TheGameEnding.LostTheGame();
                    else
                    { 
                        Snake.Add(new int[] { Snake[Snake.Count - 1][0] - 1, Snake[Snake.Count - 1][1] });
                    }

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
                    TheSnake.Score++;
                    GenerateApples();
                } 
            }
            return ateApples;
        }
        public void GenerateApples()
        {
            // could make this much faster but  dont want to yet
            while (Apples.Count < MaxApples && true)
            {
                Random random = new Random();
                int xCor;
                int yCor;
                while (true)
                {
                    startOver:
                    xCor = random.Next(0, TheSnake.TheSettings.MapSize[0]);
                    yCor = random.Next(0, TheSnake.TheSettings.MapSize[1]);
                    foreach (var item in Snake)
                    {
                        if (item[0] == xCor && item[1] == yCor)
                        {
                            goto startOver;
                        }
                    }
                    foreach (var item in Apples)
                    {
                        if (item[0] == xCor && item[1] == yCor)
                        {
                            goto startOver;
                        }
                    }
                    break;
                }
                Apples.Add(new int[2] { xCor, yCor });
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
        public bool WillCollideThatMove(int xOperation, int yOperation)
        {
            int xCoordinate = Snake[Snake.Count - 1][0] + xOperation;
            int yCoordinate = Snake[Snake.Count - 1][1] + yOperation;
            foreach (var item in Snake)
            {
                if (item[0] == xCoordinate && item[1] == yCoordinate)
                {
                    return true;
                }
            }
            if (xCoordinate == -1 || yCoordinate == -1 || xCoordinate == TheSnake.TheSettings.MapSize[0] || yCoordinate == TheSnake.TheSettings.MapSize[1]) return true;
            return false;

            //if (new int[] { Snake[Snake.Count - 1][0] + xOperation, Snake[Snake.Count - 1][1] + yOperation })
            //{

            //}
        }
    }
}
