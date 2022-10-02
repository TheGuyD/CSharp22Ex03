namespace Ex04.Menus.Test
{
    internal class CreateInterfaceMenu
    {
        public static void Run()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Interfaces Main Menu");
            Interfaces.MainMenu subMenuVersionAndCapital = new Interfaces.MainMenu("Version and Capitals");
            Interfaces.MainMenu subMenuDateAndTime = new Interfaces.MainMenu("Date and Time");

            mainMenu.AddItem(subMenuVersionAndCapital);
            mainMenu.AddItem(subMenuDateAndTime);

            subMenuVersionAndCapital.AddItem(new Interfaces.MenuItem("Count Capitals", new CountCapitals()));
            subMenuVersionAndCapital.AddItem(new Interfaces.MenuItem("Show Version", new ShowVersion()));

            subMenuDateAndTime.AddItem(new Interfaces.MenuItem("Show Date", new ShowDate()));
            subMenuDateAndTime.AddItem(new Interfaces.MenuItem("Show Time", new ShowTime()));

            mainMenu.ExecuteMenu();
        }
    }
}