using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemAdvanced.Classes
{
    public class ConsoleInterface
    {
        Library Library { get; set; }

        public ConsoleInterface()
        {
            Library = new Library();
        }
        public void DisplayMainMenu() 
        {
            bool runProgram = true;

            while (runProgram)
            {
                Console.WriteLine("Bibliotek");
                Console.WriteLine("---------");
                Console.WriteLine("\n1. Lägg till ny bok");
                Console.WriteLine("2. Lägg till ny författare");
                Console.WriteLine("3. Uppdatera bokdetaljer");
                Console.WriteLine("4. Uppdatera författardetaljer");
                Console.WriteLine("5. Ta bort bok");
                Console.WriteLine("6. Ta bort författare");
                Console.WriteLine("7. Lista alla böcker och författare");
                Console.WriteLine("8. Sök och filtrera böcker");
                Console.WriteLine("9. Avsluta och spara data");
                Console.WriteLine("Välj ett alternativ genom att trycka på en siffra mellan 1-9\r\n");

                string chooseMenuOption = Console.ReadLine()!;

                if (chooseMenuOption == "9")
                {
                    Console.WriteLine("Avslutar och sparar data...");

                    runProgram = false;
                }
                else
                {
                    MenuOptionManager(chooseMenuOption);
                }
            }
        }
        public void MenuOptionManager(string chooseMenuOption)
        {
            bool validOptionSelected;

            do
            {
                validOptionSelected = true;

                switch (chooseMenuOption)
                {
                    case "1":
                        Library.AddBook();
                        break;
                    case "2":
                        Library.AddAuthor();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        MenuToChooseShowBookOrAuthor();
                        break;
                    case "8":
                        break;
                    default:
                        Console.WriteLine("Inte ett giltigt alternativ. Välj en siffra mellan 1-8");
                        chooseMenuOption = Console.ReadLine()!;
                        validOptionSelected = false;
                        break;
                }

            } while (!validOptionSelected);

            Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
            Console.ReadKey();
            Console.Clear();
        }

        public void MenuToChooseShowBookOrAuthor()
        {
            Console.WriteLine("Vilken vill du se?");
            Console.WriteLine("1. Lista med böcker");
            Console.WriteLine("2. Lista med författare");
            string chooseShowBookOrAuthor = Console.ReadLine()!;

            bool validOptionSelected;

            do
            {
                validOptionSelected = true;

                switch (chooseShowBookOrAuthor)
                {
                    case "1":
                        Library.ShowListOfAllBooks();
                        break;
                    case "2":
                        Library.ShowListOfAllAuthors();
                        break;
                    default:
                        Console.WriteLine("Inte ett giltigt alternativ. Välj en siffra mellan 1-2");
                        chooseShowBookOrAuthor = Console.ReadLine()!;
                        validOptionSelected = false;
                        break;
                }
            } while (!validOptionSelected);
        }
    }
}