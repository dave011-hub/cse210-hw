using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("How to Cook Rice", "Chef Ama", 300);
        v1.AddComment(new Comment("Kwame", "Nice tutorial!"));
        v1.AddComment(new Comment("Sarah", "This helped a lot."));
        v1.AddComment(new Comment("James", "Perfect instructions."));
        videos.Add(v1);

        // Video 2
        Video v2 = new Video("Learning C#", "TechGenius", 600);
        v2.AddComment(new Comment("Michael", "Very clear explanations."));
        v2.AddComment(new Comment("Abena", "Best C# video ever!"));
        v2.AddComment(new Comment("John", "I learned so much."));
        videos.Add(v2);

        // Video 3
        Video v3 = new Video("Travel Vlog: Ghana", "Kofi Adventures", 450);
        v3.AddComment(new Comment("Linda", "Ghana is beautiful!"));
        v3.AddComment(new Comment("Nana", "Love this vlog."));
        v3.AddComment(new Comment("Akosua", "Great editing."));
        videos.Add(v3);

        // Display everything
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumComments()}");

            foreach (Comment c in video.GetComments())
            {
                Console.WriteLine($"  - {c.GetName()}: {c.GetText()}");
            }

            Console.WriteLine();
        }
    }
}