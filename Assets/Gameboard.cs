using System;
using System.Linq;

public class Gameboard
{
    public int N, M;
    Card[] _seenCards = new Card[52];
    int _seenCount;
    public static Random rnd = new System.Random();
    public Card[,] CardMatrix;

    // Constructor
    public Gameboard(int n, int m)
    {
        N = n;
        M = m;
        _seenCount = 0;
        CardMatrix = new Card[N, M];
        GenerateMatrix();
    }

    // Create all cards
    void GenerateMatrix()
    {
        for (int cardsLeft = N * M / 2; cardsLeft > 0; cardsLeft--)
        {
            Card card = CreateCard();
            int[] pos1 = EmptyPosition();
            CardMatrix[pos1[0], pos1[1]] = card;
            int[] pos2 = EmptyPosition();
            CardMatrix[pos2[0], pos2[1]] = card;
        }
    }

    // Helper function to find an empty position
    private int[] EmptyPosition()
    {
        int[] pos = new int[2];
        do
        {
            pos[0] = rnd.Next(0, N);
            pos[1] = rnd.Next(0, M);
        } while (CardMatrix[pos[0], pos[1]] != null);
        return pos;
    }

    // Helper function to create a card that was not seen yet
    private Card CreateCard()
    {
        Card card;
        do
        {
            card = RandomCard();
        } while (_seenCards.Contains(card));
        _seenCards[_seenCount] = card;
        _seenCount++;
        return card;
    }

    // Helper function to randomly generate a card value (Card.position == null)
    private Card RandomCard()
    {
        string[] suits = { "clubs", "diamonds", "hearts", "spades" };

        int r = rnd.Next(1, 14);
        string s = suits[rnd.Next(0, 4)];
        return new Card(r, s);
    }
}

