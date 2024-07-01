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
        {// vraagt de speler om een naam en begint het spel
            Console.WriteLine("Welcome to the Higher/Lower Card Game!");
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Hello, {playerName}, let's start!");
         // Creart het deck
            Deck deck = new Deck();
            deck.Shuffle();
            // een int de de score bij houd
            int score = 0;
            Card previousCard = null;

            while (deck.Cards.Count > 0)
            {
                if (previousCard != null)
                {// laat zien of de wat de kaart is als de niet null is dan kun je kiezen of de volgende kaart
                 // hoger, lager, of het zelfde is dan kijkt hij ook meteen of je het goed hebt of niet
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
                {// als er geen vorige kaart is trekt hij een eerste kaart en word dat de forige kaart
                    previousCard = deck.DrawCard();
                    Console.WriteLine($"First card: {previousCard}");
                }
                Console.WriteLine("Press Esc to quit, or any other key to continue.");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {// als de player op escape drukt eindegt het spel
                    break;
                }

                Console.Clear();
            }// dan word de score geprint en kun je een input geven om het progama af te sluiten
            Console.WriteLine($"Thats it, {playerName}. Your score is: {score}");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

