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
        private Database database;

        public List<Book> bookList { get; set; } = new List<Book>();
        public List<Author> authorList { get; set; } = new List<Author>();

        public Library()
        {
            database = new Database();
            database.LoadDataFromFile();

            // Koppla inlästa böcker och författare till listorna i Library
            bookList = database.AllBooksFromJSON;
            authorList = database.AllAuthorsFromJSON;
        }

        public void AddBook()
        {
            Console.Write("Ange boktitel: ");
            string newTitle = Console.ReadLine()!;

            Console.Write("Ange genre: ");
            string newGenre = Console.ReadLine()!;

            Console.Write("Ange id: ");
            int newID = int.Parse(Console.ReadLine()!);

            Console.Write("Ange publiceringsår: ");
            int newPublicationYear = int.Parse(Console.ReadLine()!);

            Console.Write("Ange ISBN: ");
            int newISBN = int.Parse(Console.ReadLine()!);

            Console.Write("Ange författarens namn: ");
            string authorName = Console.ReadLine()!;

            // Hitta författaren i authorList
            Author author = authorList.FirstOrDefault(author => author.Name.Equals(authorName, StringComparison.OrdinalIgnoreCase));

            if (author == null)
            {
                // om författaren inte finns fråga användaren om den vill lägga till författaren,
                // annars meddela att den inte finns och att det inte går att lägga till en bok
                Console.WriteLine($"Författaren '{authorName}' finns inte i systemet. För att lägga till boken behöver du lägga till författaren först.");
                Console.Write("Vill du lägga till författaren? (ja/nej): ");
                string response = Console.ReadLine()!;

                if (response == "ja")
                {
                    AddAuthor();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Författaren med det angivna namnet hittades inte. Boken läggs inte till.");
                    return;
                }
            }

            bookList.Add(new Book(newID, newTitle, newGenre, newPublicationYear, newISBN, author));

            Console.WriteLine($"Boken '{newTitle}' har lagts till i systemet.");
        }

        public void AddAuthor()
        {
            Console.Write("Ange författarens namn: ");
            string newName = Console.ReadLine()!;

            Console.Write("Ange författarens land: ");
            string newCountry = Console.ReadLine()!;

            Console.Write("Ange id: ");
            int newID = int.Parse(Console.ReadLine()!);

            authorList.Add(new Author(newID, newName, newCountry));

            Console.WriteLine($"Författaren '{newName}' har lagts till i systemet.");
        }

        public void UpdateBook()
        {
            Console.Write("Ange titeln på bok du vill uppdatera: ");
            string bookToUpdate = Console.ReadLine()!;

            bool bookFound = false;

            foreach (Book book in bookList)
            {
                if (book.Title.Equals(bookToUpdate, StringComparison.OrdinalIgnoreCase))
                {
                    bookFound = true;

                    // Visa alternativ för vad som ska uppdateras
                    Console.WriteLine("Vad vill du uppdatera?");
                    Console.WriteLine("1. Titel");
                    Console.WriteLine("2. Genre");
                    Console.WriteLine("3. Publiceringsår");
                    Console.WriteLine("4. ISBN");
                    Console.WriteLine("5. Återgå till huvudmenyn");
                    Console.Write("Ange ditt val (1-5): ");


                    string option = Console.ReadLine()!;

                    switch (option)
                    {
                        case "1":
                            Console.Write("Ange ny titel: ");
                            book.Title = Console.ReadLine()!;
                            Console.WriteLine("Boken har uppdaterats.");
                            break;
                        case "2":
                            Console.Write("Ange ny genre: ");
                            book.Genre = Console.ReadLine()!;
                            Console.WriteLine("Boken har uppdaterats.");
                            break;
                        case "3":
                            Console.Write("Ange nytt publiceringsår: ");
                            if (int.TryParse(Console.ReadLine(), out int newYear))
                            {
                                book.PublicationYear = newYear;
                                Console.WriteLine("Boken har uppdaterats.");
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt år. Uppdatering misslyckades.");
                            }
                            break;
                        case "4":
                            Console.Write("Ange nytt ISBN: ");
                            if (int.TryParse(Console.ReadLine(), out int newISBN))
                            {
                                book.ISBN = newISBN;
                                Console.WriteLine("Boken har uppdaterats.");
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt ISBN. Uppdatering misslyckades.");
                            }
                            break;
                            case "5":
                            Console.WriteLine("Återgår till huvudmenyn...");
                            return;
                        default:
                            Console.WriteLine("Ogiltigt val.");
                            break;
                    }
                    break;
                }
            }
            if (!bookFound)
            {
                Console.WriteLine($"Boken '{bookToUpdate}' finns inte i listan.");
            }
        }

        public void UpdateAuthor()
        {
            Console.Write("Ange namnet på författare du vill uppdatera: ");
            string authorToUpdate = Console.ReadLine()!;
            
            bool authorFound = false;

            foreach (Author author in authorList)
            {
                if ( author.Name.Equals(authorToUpdate, StringComparison.OrdinalIgnoreCase))
                {
                    authorFound = true;

                    // Visa alternativ för vad som ska uppdateras
                    Console.WriteLine("Vad vill du uppdatera?");
                    Console.WriteLine("1. Namn");
                    Console.WriteLine("2. Land");
                    Console.WriteLine("3. Återgå till huvudmenyn");
                    Console.Write("Ange ditt val (1-3): ");

                    string option = Console.ReadLine()!;

                    switch (option)
                    {
                        case "1":
                            Console.Write("Ange nytt namn: ");
                            author.Name = Console.ReadLine()!;
                            Console.WriteLine("Författaren har uppdaterats.");
                            break;
                        case "2":
                            Console.Write("Ange nytt land: ");
                            author.Country = Console.ReadLine()!;
                            Console.WriteLine("Författaren har uppdaterats.");
                            break;
                        case "3":
                            Console.WriteLine("Återgår till huvudmenyn...");
                            return;
                        default:
                            Console.WriteLine("Ogiltigt val.");
                            break;
                    }
                    break;
                }
            }
            if(!authorFound)
            {
                Console.WriteLine($"Författaren '{authorToUpdate}' finns inte i listan.");
            }
        }

        public void RemoveBook()
        {
            Console.Write("Skriv vilken bok du vill ta bort: ");
            string bookToRemove = Console.ReadLine()!;

            // Skapa en lista för böcker som ska tas bort
            List<Book> booksToRemove = new List<Book>();

            foreach (Book book in bookList)
            {
                if (book.Title.Equals(bookToRemove, StringComparison.OrdinalIgnoreCase))
                {
                    booksToRemove.Add(book);
                }
            }

            foreach (Book book in booksToRemove)
            {
                bookList.Remove(book);
                Console.WriteLine($"{bookToRemove} är bortagen från listan.");                
            }

            if (booksToRemove.Count == 0)
            {
                Console.WriteLine($"{bookToRemove} finns inte i listan.");
            }
        }

        public void RemoveAuthor()
        {
            Console.Write("Skriv vilken författare du vill ta bort: ");
            string authorToRemove = Console.ReadLine()!;

            // Skapa en lista för böcker som ska tas bort
            List<Author> authorsToRemove = new List<Author>();

            foreach (Author author in authorList)
            {
                if (author.Name.Equals(authorToRemove, StringComparison.OrdinalIgnoreCase))
                {
                    authorsToRemove.Add(author);
                }
            }

            foreach (Author author in authorsToRemove)
            {
                authorList.Remove(author);
                Console.WriteLine($"{authorToRemove} är bortagen från listan.");
            }

            if (authorsToRemove.Count == 0)
            {
                Console.WriteLine($"{authorToRemove} finns inte i listan.");
            }
        }
        public void ShowListOfAllBooks()
        {
            if (bookList.Count > 0)
            {
                foreach (Book book in bookList)
                {
                    Console.WriteLine($"Boktitel: {book.Title}, Författare: {book.Author.Name}, Publicerings år: {book.PublicationYear}, Genre: {book.Genre}");
                }
            }
            else
            {
                Console.WriteLine("Det finns inga böcker att visa.");
            }
        }

        public void ShowListOfAllAuthors()
        {
            if (authorList.Count > 0)
            {
                foreach (Author author in authorList)
                {
                    Console.WriteLine($"Författare: {author.Name}, Land: {author.Country}");
                }
            }
            else
            {
                Console.WriteLine("Det finns inga författare att visa.");
                return;
            }
        }
        //Sök och filtrera böcker

        public void FilterBookByAuthor()
        {
            //Book bookToSearchAfter = AllBooks.Where(book => book.Title == ”Pippi Låbgstrump”).FirstOrDeafult()!;


        }

        public void SortBookByUserInput()
        {
            Console.WriteLine("Vänligen välj vilken lista du vill visa:");
            Console.WriteLine("\n1. Sortera böcker efter titel");
            Console.WriteLine("2. Sortera böcker efter författarens namn");
            Console.WriteLine("3. Sortera böcker efter publiceringsår");
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
