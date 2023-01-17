using System;

namespace Ex04.Menus.Delegates
{
    internal class MenuItem
    {
        internal event Action Clicked;

        private readonly int r_Index;
        private string m_Title;
        private bool m_IsSubMenu = false;

        internal MenuItem(int i_Index, string i_Title, Action i_Clicked)
        {
            r_Index = i_Index;
            m_Title = i_Title;
            Clicked += i_Clicked;
        }

        public int Index
        {
            get { return r_Index; }
        }

        internal string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        internal bool IsSubMenu
        {
            get { return m_IsSubMenu; }
            set { m_IsSubMenu = value; }
        }

        public void Show()
        {
            Console.WriteLine("{0} -> {1}", Index, Title);
        }

        public void Click()
        {
            Clicked?.Invoke();
        }
    }
}
