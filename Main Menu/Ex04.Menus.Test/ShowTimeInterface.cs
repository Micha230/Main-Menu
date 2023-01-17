using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowTimeInterface : IClicked
    {
        public void Execute()
        {
            MethodsImplementation.ShowTime();
        }
    }
}
