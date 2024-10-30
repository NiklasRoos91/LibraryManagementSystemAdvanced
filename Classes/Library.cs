﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemAdvanced.Classes
{
    public class Library
    {
        //// Bibliotek: En central klass som hanterar en samling av böcker och författare. Ska inkludera metoder för:
        ////Att lägga till en ny bok och författare.
        //Att uppdatera befintliga bok- och författardetaljer.
        //Att ta bort en bok eller författare.
        //Att lista alla böcker och författare.

        public List<Book> bookList { get; set; } = new List<Book>();
        public List<Author> authorList { get; set; } = new List<Author>();

        public Library()
        {
            // Lägg till några författare
            var author1 = new Author(1, "Astrid Lindgren", "Sverige");
            var author2 = new Author(2, "J.K. Rowling", "Storbritannien");
            var author3 = new Author(3, "George R.R. Martin", "USA");

            authorList.Add(author1);
            authorList.Add(author2);
            authorList.Add(author3);

            // Lägg till några böcker
            bookList.Add(new Book(1, "Pippi Långstrump", "Barnbok", 1945, 1, author1));
            bookList.Add(new Book(2, "Harry Potter och de vises sten", "Fantasy", 1997, 2, author2));
            bookList.Add(new Book(3, "A Game of Thrones", "Fantasy", 1996, 3, author3));
            bookList.Add(new Book(4, "Bröderna Lejonhjärta", "Barnbok", 1973, 4, author1));
            bookList.Add(new Book(5, "Harry Potter och Hemligheternas kammare", "Fantasy", 1998, 5, author2));

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

        }

        public void UpdateAuthor()
        {

        }

        public void RemoveBook()
        {

        }

        public void RemoveAuthor()
        {

        }

        public void ShowListOfAllBooks()
        {
            if (bookList.Count > 0)
            {
                foreach (Book book in bookList)
                {
                    Console.WriteLine($"Boktitel: {book.Title}, Publicerings år: {book.PublicationYear}, Genre: {book.Genre}");
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
                Console.WriteLine("Det finns inga författare att visa."

);
                return;
            }
        }
    }
}