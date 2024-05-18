using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject template;
    public SpriteRenderer sprite;
    public static GameManager Singleton;
    public static Gameboard Board;
    public static CardBehavior openedCard;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("awake");
        Debug.Log("awake2");
        Singleton = this;
        sprite = template.GetComponent<SpriteRenderer>();
    }

    public void SpawnCards()
    {
        foreach (var card in Board.CardMatrix)
        {
            var newCard = Instantiate(template);
            var component = newCard.GetComponent<CardBehavior>();
            component.Initialize(card);
            //todo: set newCard pos
            component.Show();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
