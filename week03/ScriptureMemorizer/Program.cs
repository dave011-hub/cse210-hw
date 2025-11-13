using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Scripture file in the same folder as the executable
        string defaultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "doctrine4.txt");

        if (!File.Exists(defaultFile))
        {
            Console.WriteLine($"File '{defaultFile}' not found.");
            Console.WriteLine("Please create doctrine4.txt in the same folder as the program and try again.");
            return;
        }

        string[] lines = File.ReadAllLines(defaultFile);

        if (lines.Length < 2)
        {
            Console.WriteLine("Scripture file format incorrect.");
            return;
        }

        // Parse reference line
        string refLine = lines[0].Trim();
        string[] refParts = refLine.Split(";");

        Reference reference = null;

        try
        {
            if (refParts.Length == 2)
            {
                string book = refParts[0];
                int chapter = int.Parse(refParts[1]);
                reference = new Reference(book, chapter);
            }
            else if (refParts.Length == 3)
            {
                string book = refParts[0];
                int chapter = int.Parse(refParts[1]);
                int verse = int.Parse(refParts[2]);
                reference = new Reference(book, chapter, verse);
            }
            else if (refParts.Length == 4)
            {
                string book = refParts[0];
                int chapter = int.Parse(refParts[1]);
                int startVerse = int.Parse(refParts[2]);
                int endVerse = int.Parse(refParts[3]);
                reference = new Reference(book, chapter, startVerse, endVerse);
            }
            else
            {
                Console.WriteLine("Error parsing reference line. Ensure chapter and verse values are integers.");
                return;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading reference: {ex.Message}");
            return;
        }

        // Combine scripture text from remaining lines
        string scriptureText = string.Join(" ", lines, 1, lines.Length - 1);

        Scripture scripture = new Scripture(reference, scriptureText);

        bool running = true;
        const int hideCountPerEnter = 3;

        while (running)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press Enter to hide a few words, or type 'quit'.");

            string input = Console.ReadLine().Trim();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                running = false;
                Console.WriteLine("Exiting. Keep practicing your memorization!");
                break;
            }

            scripture.HideRandomWords(hideCountPerEnter);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }
        }
    }
}
