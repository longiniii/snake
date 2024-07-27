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
        public Settings TheSettings { get; private set; }
        public UserInput TheUserInput { get; private set; }
        public Menu TheMenu { get; private set; }
        public GameEnding TheGameEnding { get; private set; }
        public bool GameEnded { get; set; } = false;
        public int Score { get; set; } = 0;

        public Snake(Settings settings, Menu menu)
        {
            TheSettings = settings;
            TheMenu = menu;
            TheSnakeLogic = new SnakeLogic(this);
            TheRenderer = new Renderer(this);
            TheUserInput = new UserInput(this);
            TheGameEnding = new GameEnding(this);
        }
        public void Run()
        {
            // add generating apples
            Task rendering = Task.Run(() => TheRenderer.TheRenderer());
            Task movingSnake = Task.Run(() => TheSnakeLogic.MoveSnake());
            Task TakingInput = Task.Run(() => TheUserInput.TheInput());
            Task.WaitAll(rendering, movingSnake, TakingInput);
        }
    }
}
