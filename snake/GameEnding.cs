using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class GameEnding
    {
        public Snake TheSnake { get; set; }
        public GameEnding(Snake snake) 
        {
            TheSnake = snake;
        }
        public void WonTheGame()
        {
            TheSnake.GameEnded = true;
            Console.Clear();
            Console.WriteLine("Congratulations! you won!");
            TheSnake.TheMenu.MainMenu();
        }
        public void LostTheGame()
        {
            TheSnake.GameEnded = true;
            Console.Clear();
            Console.WriteLine("You lost");
            TheSnake.TheMenu.MainMenu();
        }
    }
}
