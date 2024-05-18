using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject template;
    public SpriteRenderer sprite;

    public CardBehavior openedCard;
    public void OnClick(CardBehavior card)
    {
        if (openedCard == null)
        {
            openedCard = card;
            return;
        }

        var card2 = openedCard;
        openedCard = null;
        if (card == openedCard)
        {
            // oh em gee
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = template.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
