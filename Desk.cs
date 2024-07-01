using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaartenSpel
{
    public class Deck
    {
        public List<Card> Cards { get; }

        public Deck()
        {
            Cards = new List<Card>();
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (string rank in ranks)
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                (Cards[i], Cards[j]) = (Cards[j], Cards[i]);
            }
        }

        public Card DrawCard()
        {
            if (Cards.Count == 0) throw new InvalidOperationException("No cards left in the deck");
            Card drawnCard = Cards[0];
            Cards.RemoveAt(0);
            return drawnCard;
        }
    }
}