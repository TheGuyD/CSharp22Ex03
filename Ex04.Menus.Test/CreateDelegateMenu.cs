

namespace Ex04.Menus.Test
{
    internal class CreateDelegateMenu
    {
        public static void Run()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu("Delegates Main Menu");
            Delegates.MainMenu subMenuVersionAndCapital = new Delegates.MainMenu("Version and Capitals");
            Delegates.MainMenu subMenuDateAndTime = new Delegates.MainMenu("Date and Time");

            mainMenu.AddItem(subMenuVersionAndCapital);
            mainMenu.AddItem(subMenuDateAndTime);

            subMenuVersionAndCapital.AddItem(new Delegates.MenuItem("Count Capitals", new CountCapitals().Execute));
            subMenuVersionAndCapital.AddItem(new Delegates.MenuItem("Show Version", new ShowVersion().Execute));

            subMenuDateAndTime.AddItem(new Delegates.MenuItem("Show Date", new ShowDate().Execute));
            subMenuDateAndTime.AddItem(new Delegates.MenuItem("Show Time", new ShowTime().Execute));

            mainMenu.ExecuteMenu();
        }
    }
}