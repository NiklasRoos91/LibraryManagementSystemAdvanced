using LibraryManagementSystemAdvanced.Classes;

namespace LibraryManagementSystemAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Library newLibrary = new Library();

            //while (true)
            //{
            //    newLibrary.FilterBookByAuthor();
            //    Console.ReadKey();
            //    Console.Clear();
            //}

            ConsoleInterface consoleInterface = new ConsoleInterface();

            consoleInterface.DisplayMainMenu();
        }
    }
}
