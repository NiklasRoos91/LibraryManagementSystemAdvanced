using System;
using System.Collections.Generic;
using System.Linq;
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
                    authorManager.AddAuthor();
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
    }
}
