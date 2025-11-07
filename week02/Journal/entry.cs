

using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    // Constructor - runs when you create a new Entry
    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    // This method shows the entry on the screen
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine(); // adds a blank line between entries
    }
}
