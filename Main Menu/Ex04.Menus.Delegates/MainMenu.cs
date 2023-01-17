using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        internal event Action<int> LevelUpdated;

        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private string m_Title;
        private int m_Index = 0;
        private int m_Level;

        public MainMenu(string i_Title)
        {
            //// Defaul state of menu --> level is 1 and 0 is exit
            m_Title = i_Title;
            m_Level = 1;
            AddMenuItem("Exit", exit_Clicked);
        }

        private int Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        private int Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }

        internal string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        private List<MenuItem> MenuItems
        {
            get { return r_MenuItems; }
        }

        public void AddMenuItem(string i_MenuItemTitle, Action i_FunctionToAdd)
        {
            //// Add new item to the next index in the menu and what to do when clicked 
            MenuItems.Add(new MenuItem(Index++, i_MenuItemTitle, i_FunctionToAdd));
        }

        public void AddSubMenuItem(MainMenu io_SubMenu)
        {
            //// Get new SubMenu to add to the menu.
            //// Change SubMenu option 0 from "Exit" to "Back".
            //// Update "IsSubMenu" to be as submenu.
            io_SubMenu.MenuItems[0].Title = "Back";
            io_SubMenu.MenuItems[0].IsSubMenu = true;
            io_SubMenu.MenuItems[0].Clicked -= io_SubMenu.exit_Clicked;
            io_SubMenu.MenuItems[0].Clicked += Show;

            AddMenuItem(io_SubMenu.Title, io_SubMenu.Show);
            MenuItems[MenuItems.Count() - 1].IsSubMenu = true;
            io_SubMenu.UpdateLevel(Level + 1);
            LevelUpdated += io_SubMenu.UpdateLevel;
        }

        private void UpdateLevel(int io_NewLevel)
        {
            Level = io_NewLevel;

            if (LevelUpdated != null)
            {
                LevelUpdated.Invoke(io_NewLevel + 1);
            }
        }

        private void getInput(out int io_Input)
        {
            io_Input = -1;

            Console.WriteLine("Please choose one of these options or press 0 to Quit/Back:");

            while (!int.TryParse(Console.ReadLine(), out io_Input) || io_Input < 0 || io_Input >= MenuItems.Count())
            {
                Console.WriteLine("Invalid Input! Please try again.");
            }
        }

        public void Show()
        {
            bool quit = false;

            displayMenu();

            while (!quit)
            {
                getInput(out int choice);
                ////Console.Clear();
                MenuItems[choice].Click();

                if (MenuItems[choice].IsSubMenu)
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    displayMenu();
                }
            }
        }

        private void displayMenu()
        {
            ////Console.Clear();
            Console.WriteLine("**{0}**{1}----------------------", Title, Environment.NewLine);

            foreach (MenuItem currMenuItem in MenuItems.Skip(1))
            {
                ////function show in MenuItem activation
                currMenuItem.Show();
            }

            MenuItems[0].Show();
        }

        private void exit_Clicked()
        {
            Environment.Exit(-1);
        }
    }
}
