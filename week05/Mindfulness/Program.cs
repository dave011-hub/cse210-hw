using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflection Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Quit");
            Console.Write("Choice: ");

            string? choice = Console.ReadLine();
            Activity? activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }

            if (activity != null)
            {
                activity.Run();
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the main menu.");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Thanks for using the Mindfulness Program. Goodbye!");
    }
}
