using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class UserInput
    {
        private Snake TheSnake { get; set; }
        public UserInput(Snake snake) 
        {
            TheSnake = snake;
        }
        public void TheInput()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                if ((key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W) && TheSnake.TheSnakeLogic.CanMoveThatDirection("top"))
                {
                    TheSnake.TheSnakeLogic.Direction = "top";
                }
                else if ((key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S) && TheSnake.TheSnakeLogic.CanMoveThatDirection("bottom"))
                {
                    TheSnake.TheSnakeLogic.Direction = "bottom";
                }
                else if ((key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) && TheSnake.TheSnakeLogic.CanMoveThatDirection("left"))
                {
                    TheSnake.TheSnakeLogic.Direction = "left";
                }
                else if ((key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) && TheSnake.TheSnakeLogic.CanMoveThatDirection("right"))
                {
                    TheSnake.TheSnakeLogic.Direction = "right";
                }
            }
        }
    }
}
