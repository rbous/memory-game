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
        const int width = 23;
        const int height = 10;
        float xDiff = (float)width / (Board.N + 1);
        float yDiff = (float)height / (Board.M + 1);

        for (int i = 0; i < Board.N; i++)
        {
            for (int j = 0; j < Board.M; j++)
            {
                var newCard = Instantiate(template);
                var component = newCard.GetComponent<CardBehavior>();
                component.Initialize(Board.CardMatrix[i, j]);
                component.Show();

                float x = (float)-23 / 2 + xDiff * (i + 1);
                float y = -5 + yDiff * (j + 1);
                newCard.transform.position = new Vector3(x, y, 0);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
