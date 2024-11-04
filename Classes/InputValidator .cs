using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemAdvanced.Classes
{
    public static class InputHelper
    {
        public static int GetValidIntegerInputFromUser(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()!;
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Vänligen ange ett heltal.");
                }
            }
        }

        public static string GetValidStringInputFromUser(string prompt)
        {

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.WriteLine("Inmatningen får inte vara tom. Vänligen ange ett giltigt värde.");
            }
        }
    }
}
