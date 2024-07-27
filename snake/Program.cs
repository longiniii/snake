using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Settings TheSettings = new Settings();
            Menu TheMenu = new Menu(TheSettings);
            TheMenu.MainMenu();
        }
    }
}
