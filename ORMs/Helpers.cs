using System;
using System.Collections.Generic;
using System.Text;

namespace ORMs
{
    public static class Helpers
    {
        public static void DisplaySectionTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException("Section title cannot be empty");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(title);
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void DisplaySectionEnd()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"------------------------");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
