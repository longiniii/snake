using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Settings
    {
        public int Speed { get; private set; }
        public int[] MapSize { get; private set; } = new int[2]; // the first item is the x coordinate  and the second is the y
        public int AmountOfApples { get; private set; }

        public Settings()
        {
            SetSpeed("normal");
            SetMapSize("medium");
            SetAmountOfApples("one");
        }
        public string AskSpeed()
        {
            return AskSomeSetting("Choose snake's speed", new string[] { "slow", "normal", "fast" });
        }
        public void SetSpeed(string speed)
        {
            if (speed == "slow") Speed = 250;
            else if (speed == "normal") Speed = 150;
            else if (speed == "fast") Speed = 80;
        }


        public string AskMapSize()
        {
            return AskSomeSetting("Choose map's size", new string[] { "small", "medium", "big" });
        }
        public void SetMapSize(string mapSize)
        {
            if (mapSize == "small")
            {
                MapSize[0] = 13;
                MapSize[1] = 6;
            } else if (mapSize == "medium")
            {
                MapSize[0] = 22;
                MapSize[1] = 10;
            } else if (mapSize == "big")
            {
                MapSize[0] = 42;
                MapSize[1] = 19;
            }
        }


        public string AskAmountOfApples() 
        {
            return AskSomeSetting("Choose the amount of apples", new string[] { "one", "a few", "many"});
        }
        public void SetAmountOfApples(string apples)
        {
            if (apples == "one") AmountOfApples = 1;
            else if (apples == "a few") AmountOfApples = 3;
            else if (apples == "many") AmountOfApples = 5;
        }

        public string AskSomeSetting(string message, string[] items)
        {
            Console.WriteLine(message);
            for (int i = 1; i <= items.Length; i++)
            {
                Console.WriteLine($"{i} - {items[i - 1]}");
            }
            int chosenItemNum = -1; // had to assign a value beforehand cause of an error, it will change anyway
            int[] itemMargins = new int[2] { 1, items.Length }; // these are the minimum and the maxium numbers that an user can choose
            while (chosenItemNum < itemMargins[0] || chosenItemNum > itemMargins[1])
            {
                try
                {
                    chosenItemNum = Convert.ToInt32(Console.ReadLine());
                    if (chosenItemNum < itemMargins[0] || chosenItemNum > itemMargins[1]) throw new Exception();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); // fix this later create another exception
                }
            }
            for (int i = 1; i <= items.Length; i++)
            {
                if (chosenItemNum == i) return items[i - 1];
            }
            return items[(int)Math.Ceiling((double) items.Length / 2)]; // because the stupid error wont let me without returning something
        }
    }
}
