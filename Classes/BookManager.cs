using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemAdvanced.Classes
{
    public class BookManager
    {
        public List<Book> bookList;
        public List<Author> authorList;
        AuthorManager authorManager;

        public BookManager(List<Book> books, List<Author> authors)
        {
            bookList = books;
            authorList = authors;
        }

        public void AddBook()
        {
            Console.Write("Ange boktitel: ");
            string newTitle = Console.ReadLine()!;

            Console.Write("Ange genre: ");
            string newGenre = Console.ReadLine()!;

            int newID = InputHelper.GetValidIntegerInputFromUser("Ange ID: ");

            int newPublicationYear = InputHelper.GetValidIntegerInputFromUser("Ange publiceringsår: ");

            int newISBN = InputHelper.GetValidIntegerInputFromUser("Ange ISBN: ");

            Console.Write("Ange författarens namn: ");
            string authorName = Console.ReadLine()!;

            Author author = authorList.FirstOrDefault(author => author.Name.Equals(authorName, StringComparison.OrdinalIgnoreCase))!;

            if (author == null)
            {
                Console.WriteLine($"Författaren '{authorName}' finns inte i systemet. För att lägga till boken behöver du lägga till författaren först.");
                Console.Write("Vill du lägga till författaren? (ja/nej): ");
                string response = Console.ReadLine()!;

                if (response == "ja")
                {
                    authorManager.AddAuthor();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Författaren med det angivna namnet hittades inte. Boken läggs inte till.");
                    return;
                }
            }

            bool bookAlreadyExists = false;

            foreach (Book book in bookList)
            {
                if (newTitle == book.Title || newISBN == book.ISBN || newID == book.Id)
                {
                    Console.WriteLine("Den här bokens titel, ISBN-nummer eller ID finns redan i biblioteket och kommer därför inte läggas till.");
                    bookAlreadyExists = true;
                    break;
                }
            }

            if (!bookAlreadyExists)
            {
                List<int> reviews = new List<int>();

                Console.WriteLine("");
                bookList.Add(new Book(newID, newTitle, newGenre, newPublicationYear, newISBN, author, reviews));

                Console.WriteLine($"Boken '{newTitle}' har lagts till i systemet.");
            }
        }

        public void UpdateBook()
        {
            Console.Write("Ange titeln på boken du vill uppdatera: ");
            string bookToUpdate = Console.ReadLine()!;

            bool bookFound = false;

            foreach (Book book in bookList)
            {
                if (book.Title.Equals(bookToUpdate, StringComparison.OrdinalIgnoreCase))
                {
                    bookFound = true;

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
                            book.PublicationYear = InputHelper.GetValidIntegerInputFromUser("Ange nytt publiceringsår: ");
                            Console.WriteLine("Boken har uppdaterats.");
                            break;
                        case "4":
                            book.ISBN = InputHelper.GetValidIntegerInputFromUser("Ange nytt ISBN: ");
                            Console.WriteLine("Boken har uppdaterats.");
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
        public void RemoveBook()
        {
            Console.Write("Skriv vilken bok du vill ta bort: ");
            string bookToRemove = Console.ReadLine()!;

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

        public void ShowListOfAllBooks()
        {
            if (bookList.Count > 0)
            {
                foreach (Book book in bookList)
                {
                    double averageRating = book.AverageRating();
                    Console.WriteLine($"Boktitel: {book.Title}, Författare: {book.Author.Name}, Publicerings år: {book.PublicationYear}, Genre: {book.Genre}, Medelbetyg; {averageRating}");
                }
            }
            else
            {
                Console.WriteLine("Det finns inga böcker att visa.");
            }
        }

        public void AddReview()
        {
            Console.Write("Ange titeln på boken du vill betygsätta: ");
            string bookToReview = Console.ReadLine()!;

            foreach (Book book in bookList)
            {
                if ( book.Title.Equals(bookToReview, StringComparison.OrdinalIgnoreCase) )
                {
                    Console.Write("Skriv ditt betyg: ");
                    int review = Convert.ToInt32(Console.ReadLine()!);

                    book.Reviews.Add(review);
                    Console.WriteLine("Recension tillagd!");
                    return;
                }
            }
        }
    }
}