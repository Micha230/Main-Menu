namespace Ex04.Menus.Test
{
    internal class Menus
    {
        public static Interfaces.MainMenu CreateMainMenuInterfaces()
        {
            Interfaces.MainMenu interfaceMainMenu = new Interfaces.MainMenu("Main Menu Interfaces");
            Interfaces.MainMenu subMenu1 = new Interfaces.MainMenu("Version and Uppercase");
            Interfaces.MainMenu subMenu2 = new Interfaces.MainMenu("Show Date/Time");

            subMenu1.AddMenuItem("Show Version", new ShowVersionInterface());
            subMenu1.AddMenuItem("Count Uppercase", new CountUppercaseInterface());
            subMenu2.AddMenuItem("Show Date", new ShowDateInterface());
            subMenu2.AddMenuItem("Show Time", new ShowTimeInterface());
            interfaceMainMenu.AddSubMenuItem(subMenu1);
            interfaceMainMenu.AddSubMenuItem(subMenu2);

            return interfaceMainMenu;
        }

        public static Delegates.MainMenu CreateMainMenuDelegate()
        {
            Delegates.MainMenu delegateMainMenu = new Delegates.MainMenu("Main Menu Delegates");
            Delegates.MainMenu subMenu1 = new Delegates.MainMenu("Version and Uppercase");
            Delegates.MainMenu subMenu2 = new Delegates.MainMenu("Show Date/Time");

            subMenu1.AddMenuItem("Show Version", MethodsImplementation.ShowVersion);
            subMenu1.AddMenuItem("Count Uppercase", MethodsImplementation.CountUppercase);
            subMenu2.AddMenuItem("Show Date", MethodsImplementation.ShowDate);
            subMenu2.AddMenuItem("Show Time", MethodsImplementation.ShowTime);
            delegateMainMenu.AddSubMenuItem(subMenu1);
            delegateMainMenu.AddSubMenuItem(subMenu2);

            return delegateMainMenu;
        }
    }
}
