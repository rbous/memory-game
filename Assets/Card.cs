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
        if (Rank <= 10 && Rank != 1)
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
        var text = $"{NumberToString()}_of_{Suit.ToLower()}";

        if (Rank > 10)
            text += "2";

        return text;
    }

    /// <summary>
    /// fanum taxes
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Card a, Card b)
    {
        // Check if both are null
        if (a is null && b is null) return true;

        // Check if one is null
        if (a is null || b is null) return false;

        // Compare the fields
        return a.Rank == b.Rank && a.Suit == b.Suit;
    }

    public static bool operator !=(Card a, Card b)
        => !(a == b);
}