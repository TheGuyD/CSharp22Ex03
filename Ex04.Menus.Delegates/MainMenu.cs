using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private string m_MenuTitle = string.Empty;
        private readonly List<MenuItem> r_Items = null;
        private readonly List<MainMenu> r_SubMenu = null;

        public MainMenu(string i_MenuTitle)
        {
            MenuTitle = i_MenuTitle;
            r_Items = new List<MenuItem>();
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
            Console.WriteLine(MenuTitle);
            Console.WriteLine("---------------------------------");

            if(r_Items.Count > 0)
            {
                for (int i = 0; i < r_Items.Count; i++)
                {
                    Console.WriteLine("{0} -> {1}",i+1, r_Items[i].ItemName);
                }
            }
            else
            {
                for (int i = 0; i < r_SubMenu.Count; i++)
                {
                    Console.WriteLine("{0} -> {1}",i+1, r_SubMenu[i].MenuTitle);
                }
            }

            Console.WriteLine("0 -> {0}", r_SubMenu.Count == 0? "Back":"Exit");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Enter your request: (from {0} to {1} or press '0' to {2}).", 1, r_Items.Count, r_SubMenu.Count == 0 ? "Back" : "Exit");
        }

        private bool isValidInput(string i_UserInput)
        {
            bool isSucceedIntParse = false;

            if (int.TryParse(i_UserInput, out int result))
            {
                if(r_SubMenu.Count > 0)
                {
                    isSucceedIntParse = (result >= 0 && result <= r_SubMenu.Count);
                }
                else
                {
                    isSucceedIntParse = (result >= 0 && result <= r_Items.Count);
                }
            }          

            return isSucceedIntParse;
        }

        public void ExecuteMenu()
        {
             const bool v_IsProgramRunning = true;

            do
            {
                string userSelectionInput = string.Empty;

                this.show();
                
                userSelectionInput = Console.ReadLine();
                
                userInputValidationLoop(ref userSelectionInput);               
           
                int intParseInput = int.Parse(userSelectionInput);

                if(intParseInput == 0)
                {
                    break;
                }

                if(r_SubMenu.Count > 0)
                {
                    r_SubMenu[intParseInput - 1].ExecuteMenu();
                }
                else
                {
                    r_Items[intParseInput - 1].OnPressedEnter();
                }
            }
            while (v_IsProgramRunning);
        }

        private void userInputValidationLoop(ref string io_userSelectionInput)
        {
            // $G$ CSS-026 (-3) Bad code indentation.
           while (!isValidInput(io_userSelectionInput))
                    {
                        printUserInvalidInputMessage();
                        io_userSelectionInput = Console.ReadLine();
                    }
        }

        private void printUserInvalidInputMessage()
        {
           Console.WriteLine("Wrong selection, Please try again!");
        }


        public void AddItem(MenuItem i_MenuItem)
        {
            r_Items.Add(i_MenuItem);
        }

        public void AddItem(MainMenu i_SubMenu)
        {
            r_SubMenu.Add(i_SubMenu);
        }
    }
}
