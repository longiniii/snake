using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Snake
    {
        public Renderer TheRenderer { get; private set; }
        public SnakeLogic TheSnakeLogic { get; private set; }
        public Settings TheSettings { get; private set; } = new Settings();
        public UserInput TheUserInput { get; private set; }

        public Snake()
        {
            TheSnakeLogic = new SnakeLogic(this);
            TheRenderer = new Renderer(this);
            TheUserInput = new UserInput(this);
        }
        public void Run()
        {
            Task rendering = Task.Run(() => TheRenderer.TheRenderer());
            Task movingSnake = Task.Run(() => TheSnakeLogic.MoveSnake());
            Task TakingInput = Task.Run(() => TheUserInput.TheInput());
            Task.WaitAll(rendering, movingSnake);
        }
    }
}
