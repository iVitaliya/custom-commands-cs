using CustomCommands.Framework;

namespace CustomCommands
{
    class Program
    {
        public static void Main()
        {
            SelectionMenu menu = new();

            menu.SetOptions(new string[]
            {
                "Add - create a new command and add it to the command-list",
                "Remove - delete an existing command and remove it from the command-list",
                "Edit - edit a command reply",
                "Exit - exit the current running program instance"
            });

            menu.InitiateMenu();
        }
    }
}