using System;

class Program
{
    static void Main(string[] args)
    {
        // Scripture data directly in the code
        string book = "Doctrine and Covenants";
        int chapter = 4;
        string scriptureText = "Now behold, a marvelous work is about to come forth among the children of men. " +
            "Therefore, O ye that embark in the service of God, see that ye serve him with all your heart, " +
            "might, mind and strength, that ye may stand blameless before God at the last day; " +
            "remember faith, virtue, knowledge, temperance, patience, brotherly kindness, charity, humility, diligence; " +
            "ask and it shall be given unto you; seek and ye shall find. Amen.";

        Reference reference = new Reference(book, chapter);
        Scripture scripture = new Scripture(reference, scriptureText);

        // Let the user pick a difficulty level
        Console.WriteLine("Choose difficulty level: Easy (1), Medium (2), Hard (3)");
        string difficultyInput = Console.ReadLine().Trim();
        int hideCountPerEnter = difficultyInput switch
        {
            "1" => 1,
            "2" => 3,
            "3" => 5,
            _ => 3 // default to medium
        };

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide a few words, or type 'quit'.");

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
                Console.WriteLine("\nAll words are hidden. Well done!");
                break;
            }
        }
    }
}
