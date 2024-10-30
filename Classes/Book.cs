using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemAdvanced.Classes
{
    public class Book
    {
        public Author Author { get; set; }
        //Bok: Ska inkludera egenskaper som Id, Titel, Författare, Genre, Publiceringsår, Isbn och Recensioner (en lista med heltalsbetyg).

        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public int ISBN { get; set; }

        public Book(int id, string title, string genre, int publicationYear, int iSBN, Author author)
        {
            Id = id;
            Title = title;
            Genre = genre;
            PublicationYear = publicationYear;
            ISBN = iSBN;
            Author = author;
        }
    }
}
