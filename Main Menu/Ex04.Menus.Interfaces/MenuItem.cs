using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public interface IClicked
    {
        void Execute();
    }

    internal class MenuItem
    {
        private readonly int r_Index;
        private string m_Title;
        private IClicked m_WhenClicked;
        private bool m_IsSubMenu; // Is it contains a sub menue

        internal MenuItem(int i_Index, string i_Title, IClicked i_WhenClicked)
        {
            r_Index = i_Index;
            m_Title = i_Title;
            m_WhenClicked = i_WhenClicked;
        }

        public int Index
        {
            get { return r_Index; }
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public IClicked WhenClicked
        {
            get { return m_WhenClicked; }
            set { m_WhenClicked = value; }
        }

        public bool IsSubMenu
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
            WhenClicked.Execute();
        }
    }
}
