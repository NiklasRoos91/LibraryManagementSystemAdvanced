using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemAdvanced.Classes
{
    public class Library
    {
        public Database Database { get; set; }
        public List<Book> bookList { get; set; } = new List<Book>();
        public List<Author> authorList { get; set; } = new List<Author>();
        public BookManager BookManager { get; private set; }
        public AuthorManager AuthorManager { get; private set; }

        public Library()
        {
            Database = new Database();
            Database.LoadDataFromFile();

            bookList = Database.AllBooksFromJSON;
            authorList = Database.AllAuthorsFromJSON;

            BookManager = new BookManager(bookList, authorList);
            AuthorManager = new AuthorManager(authorList);
        }

        public void FilterBookByUserInput()
        {
            Console.Clear();

            Console.WriteLine("Vänligen välj vad du vill filtrera enligt:");
            Console.WriteLine("\n1. Genre");
            Console.WriteLine("2. Författare");
            Console.WriteLine("3. Publiceringsår");
            Console.WriteLine("4. Återgå till huvudmenyn");
            Console.Write("Ange ditt val (1-4): ");

            string chooseFilteringOption = Console.ReadLine()!;

            List<Book> filteredBookList;

            switch (chooseFilteringOption)
            {
                case "1":
                    string filteringInputByUser = InputHelper.GetValidStringInputFromUser("Skriv in genren du vill se: ");
                
                    filteredBookList = bookList.Where(book => book.Genre.Equals(filteringInputByUser, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case "2":
                    filteringInputByUser = InputHelper.GetValidStringInputFromUser("Skriv in författarens namn du vill se: ");

                    filteredBookList = bookList.Where(book => book.Author.Name.Equals(filteringInputByUser, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case "3":
                    filteringInputByUser = InputHelper.GetValidStringInputFromUser("Skriv in publiceringsåret du vill se: ");

                    if (int.TryParse(filteringInputByUser, out int publicationYear))
                    {
                        filteredBookList = bookList.Where(book => book.PublicationYear == publicationYear).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Ogiltigt år. Vänligen ange ett giltigt heltal.");
                        return;
                    }
                    break;
                case "4":
                    Console.WriteLine("Återgår till huvudmenyn...");
                    return;
                default:
                    Console.WriteLine("Ogiltigt val. Återgår till huvudmenyn...");
                    return;
            }
            if (filteredBookList.Count == 0)
            {
                Console.WriteLine("Inga böcker hittades för den angivna sökningen.");
            }
            else
            {
                Console.WriteLine("Filtrerad lista:");

                foreach (Book book in filteredBookList)
                {
                    Console.WriteLine($"Boktitel: {book.Title}, Författare: {book.Author.Name}, Publicerings år: {book.PublicationYear}");
                }
            }
        }

        public void SortBookByUserInput()
        {
            Console.Clear();
            Console.WriteLine("Vänligen välj vad du vill sorteradina böcker efter:");
            Console.WriteLine("\n1. Titel");
            Console.WriteLine("2. Författarens namn");
            Console.WriteLine("3. Publiceringsår");
            Console.WriteLine("4. Återgå till huvudmenyn");
            Console.Write("Ange ditt val (1-4): ");

            string chooseSortOption = Console.ReadLine()!;

            List<Book> sortedBookList;

            switch (chooseSortOption)
            {
                case "1":
                    sortedBookList = bookList.OrderBy(book => book.Title).ToList();
                    break;
                case "2":
                    sortedBookList = bookList.OrderBy(book => book.Author.Name).ToList();
                    break;
                case "3":
                    sortedBookList = bookList.OrderBy(book => book.PublicationYear).ToList();
                    break;
                case "4":
                    Console.WriteLine("Återgår till huvudmenyn...");
                    return;
                default:
                    Console.WriteLine("Ogiltigt val. Återgår till huvudmenyn...");
                    return;
            }

            Console.WriteLine("Sorterad lista:");

            foreach (Book book in sortedBookList)
            {
                Console.WriteLine($"Boktitel: {book.Title}, Författare: {book.Author.Name}, Publicerings år: {book.PublicationYear}");
            }
        }
    }
}