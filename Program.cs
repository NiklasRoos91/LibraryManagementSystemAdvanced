using LibraryManagementSystemAdvanced.Classes;

namespace LibraryManagementSystemAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {

            static void Main(string[] args)
            {
                Library library = new Library();

                // Visa böcker och författare för att kontrollera
                library.ShowListOfAllBooks();
                library.ShowListOfAllAuthors();
            }
            ConsoleInterface consoleInterface = new ConsoleInterface();

            consoleInterface.DisplayMainMenu();
        }
    }
}
