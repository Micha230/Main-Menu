using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class CountUppercaseInterface : IClicked
    {
        public void Execute()
        {
            MethodsImplementation.CountUppercase();
        }
    }
}
