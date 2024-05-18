using System;
using System.Linq;

public class Card
{

    public int Rank;
    public string Suit;

    // Constructor
    public Card(int r, string s)
    {
        Rank = r;
        Suit = s;
    }

    public string NumberToString()
    {
        if (Rank <= 10)
            return Rank.ToString();

        switch (Rank)
        {
            case 11:
                return "jack";
            case 12:
                return "queen";
            case 13:
                return "king";
            case 1:
                return "ace";
        }

        throw new Exception("problem");
    }

    public override string ToString()
    {
        return $"{NumberToString()}_of_{Suit.ToLower()}";
    }

    public static bool operator ==(Card a, Card b)
        => a.Suit == b.Suit && a.Rank == b.Rank;


    public static bool operator !=(Card a, Card b)
        => a.Suit != b.Suit || a.Rank != b.Rank;
}