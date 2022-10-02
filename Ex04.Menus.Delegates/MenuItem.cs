using System;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public event Action Execute = null;
        private string m_ItemName = string.Empty;
  
        public MenuItem(string i_ItemName, Action i_Excecute)
        {
            ItemName = i_ItemName;
            Execute += i_Excecute;
        }

        public string ItemName
        {
            get
            {
                return m_ItemName;
            }
            set
            {
                m_ItemName = value;
            }
        }

        private void menuPause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void OnPressedEnter()
        {
            if(Execute != null)
            {
                Execute.Invoke();
            }

            this.menuPause();
        }
    }
}
