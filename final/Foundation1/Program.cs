using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create videos and add comments
        Video video1 = new Video("How to Cook Pasta", "Chef John", 600);
        video1.AddComment(new Comment("Alice", "Great recipe!"));
        video1.AddComment(new Comment("Bob", "Tried it and loved it!"));
        video1.AddComment(new Comment("Charlie", "My kids enjoyed it too."));

        Video video2 = new Video("Yoga for Beginners", "Yoga with Adriene", 1200);
        video2.AddComment(new Comment("Dave", "Very relaxing session."));
        video2.AddComment(new Comment("Eve", "Perfect for a morning routine."));
        video2.AddComment(new Comment("Faythe", "I feel so much better after this."));

        Video video3 = new Video("DIY Home Office Setup", "Tech Guru", 900);
        video3.AddComment(new Comment("Grace", "Thanks for the tips!"));
        video3.AddComment(new Comment("Heidi", "Just what I needed."));
        video3.AddComment(new Comment("Ivan", "My office looks amazing now."));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Iterate through the list of videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Name { get; private set; }
    public string Text { get; private set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}