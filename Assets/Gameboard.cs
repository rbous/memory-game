using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Gameboard
{

    public int N, M;
    public Card[,] CardMatrix;
    Card[] _seenCards = new Card[52];
    int _seenCount;

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
        for (int cardsLeft = N * M / 2; cardsLeft > 0; cardsLeft -= 2)
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
            Random rnd = new Random();
            pos[0] = rnd.Next() % N;
            pos[1] = rnd.Next() % M;
        } while (CardMatrix[pos[0], pos[1]] == null);
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

        Random rnd = new Random();
        string[] suits = { "c", "d", "h", "s" };

        int r = rnd.Next() % 13;
        string s = suits[rnd.Next() % 4];
        return new Card(r, s);
    }
}

