using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemAdvanced.Classes
{
    public class AuthorManager
    {
        public List<Author> authorList;

        public AuthorManager(List<Author> authors)
        {
            authorList = authors;
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
        public void UpdateAuthor()
        {
            Console.Write("Ange namnet på författare du vill uppdatera: ");
            string authorToUpdate = Console.ReadLine()!;

            bool authorFound = false;

            foreach (Author author in authorList)
            {
                if (author.Name.Equals(authorToUpdate, StringComparison.OrdinalIgnoreCase))
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
            if (!authorFound)
            {
                Console.WriteLine($"Författaren '{authorToUpdate}' finns inte i listan.");
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
    }
}
