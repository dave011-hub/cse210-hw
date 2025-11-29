

using System;
using System.IO;
using System.Threading;

public abstract class Activity
{
    
    private string _name;
    private string _description;
    private int _durationSeconds;

    
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    // Public getters
    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetDuration() => _durationSeconds;

    // Ask user for duration 
    public void PromptDuration()
    {
        Console.Write("Enter duration in seconds: ");
        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                _durationSeconds = seconds;
                break;
            }
            Console.Write("Invalid input. Enter a positive integer for seconds: ");
        }
    }

    //  starting message
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {GetName()} ---");
        Console.WriteLine();
        Console.WriteLine(GetDescription());
        Console.WriteLine();
        PromptDuration();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        PauseWithSpinner(3); // small prepare pause 
    }

    //  ending message
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        PauseWithSpinner(2);
        Console.WriteLine($"You have completed the {GetName()} for {GetDuration()} seconds.");
        PauseWithSpinner(3);
    }

    // Helper: spinner animation for given seconds 
    protected void PauseWithSpinner(int seconds)
    {
        char[] spinner = new[] { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int idx = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[idx]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            idx = (idx + 1) % spinner.Length;
        }
    }

    // Helper: numeric countdown from n down to 1 
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Helper: log session 
    protected void LogSession()
    {
        try
        {
            string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {GetName()} | {GetDuration()}s";
            File.AppendAllText("activity_log.txt", logLine + Environment.NewLine);
        }
        catch
        {
            // ignore logging errors so they don't crash app
        }
    }

    // The main activity behavior 
    public abstract void Run();
}
