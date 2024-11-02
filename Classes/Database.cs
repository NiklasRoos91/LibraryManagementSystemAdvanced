using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibraryManagementSystemAdvanced.Classes
{
    public class Database
    {
        [JsonPropertyName("books")]

        public List<Book> AllBooksFromJSON { get; set; } = new List<Book>();

        [JsonPropertyName("authors")]

        public List<Author> AllAuthorsFromJSON { get; set; } = new List<Author>();

        public string filePathJSON = "LibraryData.json";


        // Ladda data från JSON-fil
        public void LoadDataFromFile()
        {
            if (File.Exists(filePathJSON)) // Kontrollera om filen finns
            {            
                 string allJSONData = File.ReadAllText(filePathJSON);
                 var loadedDataFromJSON = JsonSerializer.Deserialize<Database>(allJSONData);

                 if (loadedDataFromJSON != null)
                 {
                    AllBooksFromJSON = loadedDataFromJSON.AllBooksFromJSON ?? new List<Book>();
                    AllAuthorsFromJSON = loadedDataFromJSON.AllAuthorsFromJSON ?? new List<Author>();
                 }
            }
        }


        // Spara data till JSON-fil
        public void SaveData()
        {

        }


    }
}
