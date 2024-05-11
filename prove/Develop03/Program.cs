using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Scripture john316 = new Scripture("John 3:16", "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");

        john316.Display();

        Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
        string input = Console.ReadLine();

        while (!john316.AllWordsHidden() && input.ToLower() != "quit")
        {
            Console.Clear();

            john316.HideRandomWords();

            john316.Display();

            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            input = Console.ReadLine();
        }
    }
}
class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }
    public string GetFormattedReference()
    {
        if (StartVerse == EndVerse)
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }
}
class Scripture
{
    private Reference reference;
    private List<string> words;
    private HashSet<int> hiddenIndices;
    public Scripture(string reference, string text)
    {
        string[] parts = reference.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
        string book = parts[0];
        int chapter = int.Parse(parts[1]);
        string[] verseParts = parts[2].Split('-');
        int startVerse = int.Parse(verseParts[0]);
        int endVerse = startVerse;
        if (verseParts.Length > 1)
        {
            endVerse = int.Parse(verseParts[1]);
        }

        this.reference = new Reference(book, chapter, startVerse, endVerse);
        words = text.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        hiddenIndices = new HashSet<int>();
    }

    public void Display()
    {
        Console.WriteLine($"Reference: {reference.GetFormattedReference()}");
        foreach (var word in words)
        {
            if (hiddenIndices.Contains(words.IndexOf(word)))
            {
                Console.Write("***** ");
            }
            else
            {
                Console.Write($"{word} ");
            }
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int numWordsToHide = random.Next(1, words.Count / 2); 
        for (int i = 0; i < numWordsToHide; i++)
        {
            int index = random.Next(0, words.Count);
            hiddenIndices.Add(index);
        }
    }
      public bool AllWordsHidden()
    {
        return hiddenIndices.Count == words.Count;
    }
}