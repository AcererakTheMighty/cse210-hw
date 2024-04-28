using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");

       Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(5, 501);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You Guessed it!");
            }
        }
    }
}