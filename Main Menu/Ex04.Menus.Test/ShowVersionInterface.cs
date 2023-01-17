using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowVersionInterface : IClicked
    {
        public void Execute()
        {
            MethodsImplementation.ShowVersion();
        }
    }
}
