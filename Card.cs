using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaartenSpel
{
    public class Card
    {// houd bij welke type kaart het is en de soort kaart
        public Suits CardSuit { get; }
        public string Rank { get; }

        private static readonly Dictionary<string, int> RankValues = new()
        {
            {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10},
            {"Jack", 11}, {"Queen", 12}, {"King", 13}, {"Ace", 14}
        };

        public Card(Suits suit, string rank)
        {
            CardSuit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Rank} of {CardSuit}";
        }

        public int CompareTo(Card other)
        {
            return RankValues[Rank].CompareTo(RankValues[other.Rank]);
        }

        public static bool operator >(Card c1, Card c2)
        {
            return c1.CompareTo(c2) > 0;
        }

        public static bool operator <(Card c1, Card c2)
        {
            return c1.CompareTo(c2) < 0;
        }
    }
}
