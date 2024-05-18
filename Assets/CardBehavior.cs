using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    private SpriteRenderer renderer;
    
    public class Card
    {
        public string suit;
        public int number;

        public string NumberToString()
        {
            if (number <= 10)
                return number.ToString();

            switch (number)
            {
                case 11:
                    return "jack";
                case 12:
                    return "queen";
                case 13:
                    return "king";
                case 14:
                    return "ace";
            }

            throw new Exception("problem");
        }

        public override string ToString()
        {
            return $"{NumberToString()}_of_{suit.ToLower()}";
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Create(Card card)
    {
        Texture2D texture = Resources.Load($"Deck/{card}") as Texture2D;
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, 1024, 1024), new Vector2(1, 1));
        renderer.sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {

    }
}