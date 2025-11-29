

using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        // We'll alternate inhale/exhale; each step will have a short countdown
        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");
            // show a 4-second inhale by counting down 
            int inhale = 4;
            for (int i = inhale; i >= 1 && DateTime.Now < endTime; i--)
            {
                Console.Write(i);
                Thread.Sleep(4000);
                Console.Write("\b \b");
            }

            Console.WriteLine();

            if (DateTime.Now >= endTime) break;

            Console.Write("Breathe out... ");
            int exhale = 6; // longer exhale
            for (int i = exhale; i >= 1 && DateTime.Now < endTime; i--)
            {
                Console.Write(i);
                Thread.Sleep(4000);
                Console.Write("\b \b");
            }

            Console.WriteLine();
        }

        DisplayEndingMessage();
        LogSession();
    }
}
