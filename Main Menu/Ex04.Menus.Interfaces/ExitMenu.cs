using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal class ExitMenu : IClicked
    {
        public void Execute()
        {
            Environment.Exit(-1);
        }
    }
}
