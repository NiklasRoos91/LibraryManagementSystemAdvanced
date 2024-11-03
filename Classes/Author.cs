using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemAdvanced.Classes
{
    public class Author
    {
        // Författare: Ska inkludera egenskaper som Id, Namn, Land och en lista över skrivna Böcker.
        public int Id { get; set; } 
        public string Name { get; set; }        
        public string Country { get; set; }

        public Author(int id, string name, string country)
        {
            Id = id;
            Name = name;
            Country = country;
        }
    }
}