using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    internal class Renderer
    {
        private Snake TheSnake { get; set; }
        public int RefreshRate { get; private set; } = 40;
        public char SnakeChar { get; private set; } = '*';
        public char AppleChar { get; private set; } = 'o';
        public int HorizontalLength { get; set; }
        public int VerticalLength { get; set; }
        public char HorizontalChar { get; private set; } = '─';
        public char VerticalChar { get; private set; } = '│';
        public char LeftUpChar { get; private set; } = '┌';
        public char RightUpChar { get; private set; } = '┐';
        public char LeftDownChar { get; private set; } = '└';
        public char RightDownChar { get; private set; } = '┘';
        public int OffSetX { get; private set; } = 1;
        public int OffSetY { get; private set; } = 1;
        public List<int[]> Apples { get; private set; }
        public List<int[]> Snake { get; private set; }
        public Renderer(Snake snake)
        {
            TheSnake = snake;
        }
        public void TheRenderer() 
        {
            HorizontalLength = TheSnake.TheSettings.MapSize[0];
            VerticalLength = TheSnake.TheSettings.MapSize[1];
            Console.Clear();
            Console.CursorVisible = false;
            while (!TheSnake.GameEnded)
            {
                Apples = TheSnake.TheSnakeLogic.Apples;
                Snake = TheSnake.TheSnakeLogic.Snake;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.SetCursorPosition(0, 0);

                List<string> theMap = new List<string>(VerticalLength + 2); // adds map borders
                theMap.Add(LeftUpChar.ToString());
                theMap[0] += (new string(HorizontalChar, HorizontalLength));
                theMap[0] += RightUpChar;
                for (int i = 0; i < VerticalLength; i++)
                {
                    theMap.Add(VerticalChar.ToString());
                    theMap[i + OffSetY] += new string(' ', HorizontalLength);
                    theMap[i + OffSetY] += VerticalChar;
                }
                theMap.Add(LeftDownChar.ToString());
                theMap[theMap.Count - 1] += new string(HorizontalChar, HorizontalLength);
                theMap[theMap.Count - 1] += RightDownChar;

                for (int i = 0; i < Apples.Count; i++) // adds apple blocks
                {
                    char[] temp = theMap[Apples[i][1] + OffSetY].ToCharArray();
                    temp[Apples[i][0] + OffSetX] = AppleChar;
                    theMap[Apples[i][1] + OffSetY] = new string(temp);
                }
                for (int i = 0; i < Snake.Count; i++) // adds snake blocks
                {
                    char[] temp = theMap[Snake[i][1] + OffSetY].ToCharArray();
                    temp[Snake[i][0] + OffSetX] = SnakeChar;
                    theMap[Snake[i][1] + OffSetY] = new string(temp);
                }
                stopwatch.Stop();
                Console.WriteLine(string.Join("\n", theMap.ToArray()));
                Console.WriteLine('\n');
                Console.WriteLine(TheSnake.Score + "o");
                if (RefreshRate >= stopwatch.ElapsedMilliseconds) Thread.Sleep((int)(RefreshRate - stopwatch.ElapsedMilliseconds));
            }

        }
    }
}
