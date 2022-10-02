using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private string m_MenuTitle = string.Empty;
        private readonly List<MenuItem> r_MenuItems = null;
        private readonly List<MainMenu> r_SubMenu = null;

        public MainMenu(string i_MenuTitle)
        {
            m_MenuTitle = i_MenuTitle;
            r_MenuItems = new List<MenuItem>();
            r_SubMenu = new List<MainMenu>();
        }

        public string MenuTitle
        {
            get
            {
                return m_MenuTitle;
            }
            set
            {
                m_MenuTitle = value;
            }
        }

        private void show()
        {
            Console.WriteLine("{0}", m_MenuTitle);
            Console.WriteLine("---------------------------------");

            if (r_MenuItems.Count > 0)
            {
                for (int i = 0; i < r_MenuItems.Count; i++)
                {
                    Console.WriteLine("{0} -> {1}", i + 1, r_MenuItems[i].ItemName);
                }
            }
            else
            {
                for (int i = 0; i < r_SubMenu.Count; i++)
                {
                    Console.WriteLine("{0} -> {1}", i + 1, r_SubMenu[i].m_MenuTitle);
                }
            }

            Console.WriteLine("0 -> {0}", r_SubMenu.Count == 0 ? "Back" : "Exit");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Enter your request: (from {0} to {1} or press '0' to {2}).", 1, r_MenuItems.Count, r_SubMenu.Count == 0 ? "Back" : "Exit");
        }

        private bool isValidInput(string i_UserInput)
        {
            bool isSucceedIntParse = false;

            if (int.TryParse(i_UserInput, out int result))
            {
                if (r_SubMenu.Count > 0)
                {
                    isSucceedIntParse = (result >= 0 && result <= r_SubMenu.Count);
                }
                else
                {
                    isSucceedIntParse = (result >= 0 && result <= r_MenuItems.Count);
                }
            }

            return isSucceedIntParse;
        }

        public void ExecuteMenu()
        {
            const bool v_IsProgramRunning = true;

            do
            {
                this.show();

                string userSelectionInput = string.Empty;
                bool isValid = false;

                do
                {
                    userSelectionInput = Console.ReadLine();
                    isValid = isValidInput(userSelectionInput);

                    if (!isValid)
                    {
                        Console.WriteLine("Wrong selection, Please try again!");
                    }
                }
                while (!isValid);

                int intParseInput = int.Parse(userSelectionInput);

                if (intParseInput == 0)
                {
                    break;
                }

                if (r_SubMenu.Count > 0)
                {
                    r_SubMenu[intParseInput - 1].ExecuteMenu();
                }
                else
                {
                    r_MenuItems[intParseInput - 1].SelectedItem();
                }
            }
            while (v_IsProgramRunning);
        }

        public void AddItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem);
        }

        public void AddItem(MainMenu i_SubMenu)
        {
            r_SubMenu.Add(i_SubMenu);
        }
    }
}
