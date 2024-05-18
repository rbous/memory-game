using System;

namespace MemoryGame {

    public class Card {
        int rank;
        char suit;

        // Constructor
        Card(int r, char s) {
            rank = r;
            suit = s;
        }
    }


    public class Gameboard {

        int n, m;
        Card[n, m] cardMatrix;
        Card[] seenCards = new Card[52];
        int seenCount;
        
        // Constructor
        Gameboard(int i, int j) {
            n = i;
            m = j;
            seenCount = 0;
            cardMatrix = new Card[n, m];
            generateMatrix();
        }

        // Create all cards
        void generateMatrix() {
            for (int cardsLeft = n * m / 2; cardsLeft > 0; cardsLeft -= 2) {
                Card card = createCard();
                int[2] pos1 = emptyPosition();
                cardMatrix[pos1[0], pos1[1]] = card;
                int[2] pos2 = emptyPosition();
                cardMatrix[pos2[0], pos2[1]] = card;
            }
        }

        // Helper function to find an empty position
        private int[2] emptyPosition() {
            int[2] pos;
            do {
                Random rnd = new Random();
                pos[0] = rnd.Next() % n;
                pos[1] = rnd.Next() % m;
            } while (cardMatrix[pos[0], pos[1]] == null);
            return pos;
        }

        // Helper function to create a card that was not seen yet
        private Card createCard() {
            do {
                Card card = randomCard();
            } while (seenCards.Contains(card));
            seenCards[seenCount] = card;
            seenCount++;
            return card;
        }

        // Helper function to randomly generate a card value (Card.position == null)
        private Card randomCard() {

            Card card = new Card();
            Random rnd = new Random();
            char[] suits = {'c', 'd', 'h', 's'};

            card.rank = rnd.Next() % 13;
            card.suit = suits[rnd.Next() % 4];
            return card;
        }
    }
}

