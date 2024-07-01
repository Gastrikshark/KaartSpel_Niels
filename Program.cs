namespace KaartenSpel
{
    using System;
    using System.Collections.Generic;
    // Enum voor de verschilen tussen de 4 tiepes kaarten
    public enum Suits
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Higher/Lower Card Game!");
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Hello, {playerName}, let's start!");

            Deck deck = new Deck();
            deck.Shuffle();

            int score = 0;
            Card previousCard = null;

            while (deck.Cards.Count > 0)
            {
                if (previousCard != null)
                {
                    Console.WriteLine($"Previous card: {previousCard}");
                    Console.Write("Will the next card be (h)igher, (l)ower, or the same (s)uit? ");
                    char guess = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    Card currentCard = deck.DrawCard();
                    Console.WriteLine($"Next card: {currentCard}");

                    bool correctGuess = (guess == 'h' && currentCard > previousCard) ||
                                        (guess == 'l' && currentCard < previousCard) ||
                                        (guess == 's' && currentCard.CardSuit == previousCard.CardSuit);

                    if (correctGuess)
                    {
                        Console.WriteLine("Correct guess!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Wrong guess.");
                    }

                    previousCard = currentCard;
                }
                else
                {
                    previousCard = deck.DrawCard();
                    Console.WriteLine($"First card: {previousCard}");
                }
                Console.WriteLine("Press Esc to quit, or any other key to continue.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Clear();
            }
            Console.WriteLine($"Thats it, {playerName}. Your score is: {score}");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

