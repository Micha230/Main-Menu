namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu MainMenuInterface = Menus.CreateMainMenuInterfaces();
            MainMenuInterface.Show();

            Delegates.MainMenu MainMenuDelegate = Menus.CreateMainMenuDelegate();
            MainMenuDelegate.Show();
        } 
    }
}
