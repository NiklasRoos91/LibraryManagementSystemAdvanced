using LibraryManagementSystemAdvanced.Classes;

namespace LibraryManagementSystemAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleInterface consoleInterface = new ConsoleInterface();

            consoleInterface.DisplayLibraryMainMenu();
        }
    }
}
