﻿using System;
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
        public void DisplayLibraryMainMenu() 
        {
            bool runProgram = true;

            while (runProgram)
            {
                Console.WriteLine("Bibliotek");
                Console.WriteLine("---------");
                Console.WriteLine("Vänligen välj vilken lista du vill visa:");
                Console.WriteLine("\n1. Lägg till ny bok");
                Console.WriteLine("2. Lägg till ny författare");
                Console.WriteLine("3. Uppdatera bokdetaljer");
                Console.WriteLine("4. Uppdatera författardetaljer");
                Console.WriteLine("5. Ta bort bok");
                Console.WriteLine("6. Ta bort författare");
                Console.WriteLine("7. Lista med alla böcker och författare");
                Console.WriteLine("8. Sök och filtrera böcker");
                Console.WriteLine("9. Lägg till betyg på bok");
                Console.WriteLine("10. Avsluta och spara data");

                string chooseMenuOption = InputHelper.GetValidStringInputFromUser("Ange ditt val (1-10): ");

                switch (chooseMenuOption)
                {
                    case "1":
                        Library.BookManager.AddBook();
                        break;
                    case "2":
                        Library.AuthorManager.AddAuthor();
                        break;
                    case "3":
                        Library.BookManager.UpdateBook();
                        break;
                    case "4":
                        Library.AuthorManager.UpdateAuthor();
                        break;
                    case "5":
                        Library.BookManager.RemoveBook();
                        break;
                    case "6":
                        Library.AuthorManager.RemoveAuthor();
                        break;
                    case "7":
                        MenuToChooseShowBookOrAuthor();
                        break;
                    case "8":
                        MenuToSortOrFilter();
                        break;
                    case "9":
                        Library.BookManager.AddReview();
                        break;
                    case "10":
                        Library.Database.SaveData();
                        Console.WriteLine("Avslutar och sparar data...");
                        return;
                    default:
                        Console.WriteLine("Inte ett giltigt alternativ. Välj en siffra mellan 1-10");
                        chooseMenuOption = Console.ReadLine()!;
                        break;
                }
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void MenuToChooseShowBookOrAuthor()
        {
            Console.WriteLine("Vänligen välj vilken lista du vill visa:");
            Console.WriteLine("\n1. Lista med böcker");
            Console.WriteLine("2. Lista med författare");
            Console.WriteLine("3. Återgå till huvudmenyn");

            string chooseShowBookOrAuthor = InputHelper.GetValidStringInputFromUser("Ange ditt val (1-3): ");

            bool validOptionSelected;

            do
            {
                validOptionSelected = true;

                switch (chooseShowBookOrAuthor)
                {
                    case "1":
                        Library.BookManager.ShowListOfAllBooks();
                        break;
                    case "2":
                        Library.AuthorManager.ShowListOfAllAuthors();
                        break;
                    case "3":
                        Console.WriteLine("Återgår till huvudmenyn...");
                        return;
                    default:
                        Console.WriteLine("Inte ett giltigt alternativ. Välj en siffra mellan 1-3");
                        chooseShowBookOrAuthor = Console.ReadLine()!;
                        validOptionSelected = false;
                        break;
                }
            } while (!validOptionSelected);
        }

        private void MenuToSortOrFilter()
        {
            Console.WriteLine("Vänligen välj vad du vill göra:");
            Console.WriteLine("\n1. Filtrera böcker");
            Console.WriteLine("2. Sortera böcker");
            Console.WriteLine("3. Återgå till huvudmenyn");

            string chooseFilterOrSortBook = InputHelper.GetValidStringInputFromUser("Ange ditt val (1-3): ");

            bool validOptionSelected;

            do
            {
                validOptionSelected = true;

                switch (chooseFilterOrSortBook)
                {
                    case "1":
                        Library.FilterBookByUserInput();
                        break;
                    case "2":
                        Library.SortBookByUserInput();
                        break;
                    case "3":
                        Console.WriteLine("Återgår till huvudmenyn...");
                        return;
                    default:
                        Console.WriteLine("Inte ett giltigt alternativ. Välj en siffra mellan 1-3");
                        chooseFilterOrSortBook = Console.ReadLine()!;
                        validOptionSelected = false;
                        break;
                }
            }
            while (!validOptionSelected);
        }
    }
}