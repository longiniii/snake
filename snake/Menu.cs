using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Menu
    {
        public Settings TheSettings { get; set; }
        public Menu(Settings settings) 
        {
            TheSettings = settings;
        }
        public void MainMenu()
        {
            Console.WriteLine("1 - play");
            Console.WriteLine("2 - change settings");
            Console.WriteLine("3 - exit");
            int chosenItemNum = -1; // had to assign a value beforehand cause of an error, it will change anyway
            int[] itemMargins = new int[2] { 1, 3 }; // these are the minimum and the maxium numbers that an user can choose
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
            if (chosenItemNum == 1)
            {
                Snake TheSnake = new Snake(TheSettings, this);
                TheSnake.Run();
            }
            if (chosenItemNum == 2)
            {
                TheSettings.SettingsMenu();
                this.MainMenu();
            } else if (chosenItemNum == 3)
            {
                Environment.Exit(0);
            }
        }
    }
}
