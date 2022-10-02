using System;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly IExecute r_Execute = null;
        private string m_ItemName = string.Empty;

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

        public MenuItem(string i_ItemName, IExecute i_Execute)
        {
            m_ItemName = i_ItemName;
            r_Execute = i_Execute;
        }

        private static void menuPause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void SelectedItem()
        {
            r_Execute.Execute();
            menuPause();
        }
    }
}