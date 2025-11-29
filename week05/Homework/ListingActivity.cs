

using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _rand = new Random();

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine("List Prompt:");
        Console.WriteLine(prompt);
        Console.WriteLine();

        Console.WriteLine("You will have a few seconds to think. Prepare...");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each item. (Stop happens automatically when time is up.)");
        Console.WriteLine();

        List<string> entries = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < end)
        {
            // If the user types quickly, new lines are captured until time is up.
            // We use a small ReadLine timeout by checking DateTime before reading.
            if (Console.KeyAvailable)
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    entries.Add(input.Trim());
                }
            }
            else
            {
                
                Thread.Sleep(200);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {entries.Count} items. Good job!");
        PauseWithSpinner(3);

        DisplayEndingMessage();
        LogSession();
    }
}
