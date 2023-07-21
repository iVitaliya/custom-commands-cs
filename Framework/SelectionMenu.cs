using System.Security;

namespace CustomCommands.Framework
{
    internal class SelectionMenu
    {
        Errors errors = new();
        List<string> menuOptions = new List<string>();

        public void SetOptions(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                menuOptions.Add(options[i]);
            }
        }

        private List<string> GetOptions()
        {
            return menuOptions;
        }

        public void InitiateMenu()
        {
            List<string> options = GetOptions();
            int currentSelection = 0;
            bool exit = false;

            int width = Console.LargestWindowWidth / 2;
            int height = Console.LargestWindowHeight / 2;

            while (!exit)
            {
                Console.Clear();
                Console.Title = "Custom Commands v1.0.1";
                Console.WriteLine("Menu:\n");

                // Display the menu options...
                for (int i = 0; i < menuOptions.Count; i++)
                {
                    if (i == currentSelection)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        catch (ArgumentException ae)
                        {
                            errors.HandleArgumentException(ae);
                        }
                        catch (SecurityException se)
                        {
                            errors.HandleSecurityException(se);
                        }
                        catch (IOException ioe)
                        {
                            errors.HandleIOException(ioe);
                        }

                        Console.WriteLine($"[@] {menuOptions[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"[ ] {menuOptions[i]}");
                    }
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                // Handle arrow key input
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentSelection > 0)
                        {
                            currentSelection = (currentSelection - 1 + menuOptions.Count) % menuOptions.Count;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (currentSelection < menuOptions.Count - 1)
                        {
                            currentSelection = (currentSelection + 1) % menuOptions.Count;
                        }
                        break;

                    case ConsoleKey.Enter:
                        Console.WriteLine("\n");
                        HandleSelection(currentSelection);
                        if (currentSelection == menuOptions.Count - 1)
                            exit = true;
                        break;

                    default:
                        break;
                }
            }
        }

        private void HandleSelection(int selection)
        {
            string sel = menuOptions[selection].Split(" ")[0].ToLower();

            switch (sel)
            {
                case "add":
                    //
                    break;

                case "exit":
                    // Exits the program
                    System.Environment.Exit(0);
                    break;
            }
        }
    }
}