using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal interface ISubMenu
    {
        void UpdateLevel(int i_NewLevel);
    }

    public class MainMenu : IClicked, ISubMenu
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private readonly List<ISubMenu> r_SubMenus = new List<ISubMenu>();
        private int m_Level;
        private int m_Index = 0;
        private string m_Title;

        public MainMenu(string i_Title)
        {
            //// Defaul state of menu --> level is 1 and 0 is exit
            m_Title = i_Title;
            m_Level = 1;
            AddMenuItem("Exit", new ExitMenu());
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

        private string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        private List<MenuItem> MenuItems
        {
            get { return r_MenuItems; }
        }

        private List<ISubMenu> SubMenus
        {
            get { return r_SubMenus; }
        }

        public void AddMenuItem(string i_Title, IClicked i_Click)
        {
            //// Add new item to the next index in the menu and what to do when clicked 
            MenuItems.Add(new MenuItem(Index++, i_Title, i_Click));
        }

        public void AddSubMenuItem(MainMenu io_SubMenu)
        {
            //// Get new SubMenu to add to the menu.
            //// Change SubMenu option 0 from "Exit" to "Back".
            //// Update "IsSubMenu" to be as submenu.
            io_SubMenu.MenuItems[0].Title = "Back";
            io_SubMenu.MenuItems[0].WhenClicked = this;
            io_SubMenu.MenuItems[0].IsSubMenu = true;

            AddMenuItem(io_SubMenu.Title, io_SubMenu as IClicked);
            MenuItems[MenuItems.Count() - 1].IsSubMenu = true;

            io_SubMenu.UpdateLevel(Level + 1);
            SubMenus.Add(io_SubMenu); // was before r_SubMenus
        }

        public void UpdateLevel(int i_NewLevel)
        {
            Level = i_NewLevel;

            if (SubMenus != null)
            {
                foreach (ISubMenu currentSubMenu in SubMenus)
                {
                    currentSubMenu.UpdateLevel(Level + 1);
                }
            }
        }

        private void getUserInput(out int io_UserInput)
        {
            //// restarting user input to -1 (non of the menu choices)
            io_UserInput = -1;

            Console.WriteLine("Enter your request:");
            while (!int.TryParse(Console.ReadLine(), out io_UserInput) || io_UserInput < 0 || io_UserInput >= MenuItems.Count())
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
                getUserInput(out int choice);

                if (choice == 0 && Level == 1)
                {
                    quit = true;
                }
                else
                {
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

        void IClicked.Execute()
        {
            this.Show();
        }
    }
}
