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
            string newTitle = InputHelper.GetValidStringInputFromUser("Ange boktitel: ");

            string newGenre = InputHelper.GetValidStringInputFromUser("Ange genre: ");

            int newID = InputHelper.GetValidIntegerInputFromUser("Ange ID: ");

            int newPublicationYear = InputHelper.GetValidIntegerInputFromUser("Ange publiceringsår: ");

            int newISBN = InputHelper.GetValidIntegerInputFromUser("Ange ISBN: ");

            string authorName = InputHelper.GetValidStringInputFromUser("Ange författarens namn: ");

            Author author = authorList.FirstOrDefault(author => author.Name.Equals(authorName, StringComparison.OrdinalIgnoreCase))!;

            if (author == null)
            {
                Console.WriteLine($"Författaren '{authorName}' finns inte i systemet. För att lägga till boken behöver du lägga till författaren först.");
                string response = InputHelper.GetValidStringInputFromUser("Vill du lägga till författaren? (ja/nej): ");

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
            string bookToUpdate = InputHelper.GetValidStringInputFromUser("Ange titeln på boken du vill uppdatera: ");

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

                    string option = InputHelper.GetValidStringInputFromUser("Ange ditt val (1-5): ");

                    switch (option)
                    {
                        case "1":
                            book.Title = InputHelper.GetValidStringInputFromUser("Ange ny titel: ");
                            Console.WriteLine("Boken har uppdaterats.");
                            break;
                        case "2":
                            book.Genre = InputHelper.GetValidStringInputFromUser("Ange ny genre: ");
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
            string bookToRemove = InputHelper.GetValidStringInputFromUser("Skriv vilken bok du vill ta bort: ");

            bool bookFound = false;

            foreach (Book book in bookList.ToList())
            {
                if (book.Title.Equals(bookToRemove, StringComparison.OrdinalIgnoreCase))
                {
                    bookList.Remove(book);
                    Console.WriteLine($"{bookToRemove} har tagits bort från listan.");
                    bookFound = true; 
                    break;
                }
            }
            if (!bookFound)
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
            string bookToReview = InputHelper.GetValidStringInputFromUser("Ange titeln på boken du vill betygsätta: ");

            foreach (Book book in bookList)
            {
                if ( book.Title.Equals(bookToReview, StringComparison.OrdinalIgnoreCase) )
                {
                    int review;
                    while (true)
                    {
                        review = InputHelper.GetValidIntegerInputFromUser("Skriv ditt betyg (mellan 1-5): ");

                        if (review < 1 || review > 5)
                        {
                            Console.WriteLine("Ogiltigt betyg. Var god ange ett betyg mellan 1 och 5.");
                        }
                        else
                        {
                            book.Reviews.Add(review);
                            Console.WriteLine("Recension tillagd!");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine($"Boken '{bookToReview}' finns inte i listan.");
        }
    }
}