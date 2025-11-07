using System;
using System.Collections.Generic;
using System.Xml.Serialization;
class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        Random rand = new Random();

        List<string> prompts = new List<string>()
        {
        "What was your favourate part of the day . ",
        "What is one lesson you learnt from this experience? ",
        "If you had the opportunity to change what happened today what would you do differently?",
       "Commit youself to do these thing, you can do this by using statements like i must, i will .... .",
        "What was the srtongest emotion you felt today ?",
        "How did you see the hand of God in your Life today ?"
        };


        bool running = true;
        while (running)
        {
            
       Console.WriteLine("Please Select one of the Choices : ");
        Console.WriteLine("1. Write"); 
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");

        Console.Write("What will You Do?:");
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                string prompt = prompts[rand.Next(prompts.Count)];
                Console.WriteLine($"{prompt}");
                Console.Write("Your responses: ");
                string response = Console.ReadLine();

                string dateText = DateTime.Now.ToShortDateString();
                Entry newEntery = new Entry(dateText, prompt, response);
                myJournal.AddEntry(newEntery);

                Console.WriteLine("Entery recorded!");
            }
            else if (answer == "2")
            {
                myJournal.Display();
            }
            else if (answer == "3")
            {
                Console.Write("Enter filename to Load");
                string loadFile = Console.ReadLine();
                myJournal.LoadFromFile(loadFile);
            }
            else if (answer == "4")
            {
                Console.Write("Enter filename to save ");
                string saveFile = Console.ReadLine();
                myJournal.SaveToFile(saveFile);
            }
            else if (answer == "5")
                {
                    running = false;
                    Console.WriteLine("Goodbye! Keep journaling and reflecting daily. ");
                }
            else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
    }
}