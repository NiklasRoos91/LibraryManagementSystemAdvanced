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
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public int ISBN { get; set; }
        public List<int> Reviews { get; set; }

        public Book(int id, string title, string genre, int publicationYear, int iSBN, Author author, List<int> reviews)
        {
            Id = id;
            Title = title;
            Genre = genre;
            PublicationYear = publicationYear;
            ISBN = iSBN;
            Author = author;
            Reviews = reviews;
        }

        public double AverageRating()
        {
            if (Reviews.Count == 0)
            {
                return 0;
            }

            double total = Reviews.Sum();
            return total / Reviews.Count;
        }
    }
}
