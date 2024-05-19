using UnityEngine;
using UnityEngine.SceneManagement;

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
        Singleton = this;
        SceneManager.sceneLoaded += OnSceneChanged;
        Spawn();
        sprite = template.GetComponent<SpriteRenderer>();
    }

    public void OnSceneChanged(Scene newScene, LoadSceneMode mode)
    {
        if (newScene.name == "Game")
            Spawn();
    }

    public void Spawn()
    {
        Board = new(Menu.n, Menu.m);
        Singleton.SpawnCards();
    }

    public void SpawnCards()
    {
        const float width = 21.2f;
        const float height = 10;
        float xDiff = width / (Board.N + 1);
        float yDiff = height / (Board.M + 1);

        for (int i = 0; i < Board.N; i++)
        {
            for (int j = 0; j < Board.M; j++)
            {
                Debug.Log($"{Board.CardMatrix[i, j]} - ({i}, {j})");

                var newCard = Instantiate(template);
                var component = newCard.GetComponent<CardBehavior>();
                component.Initialize(Board.CardMatrix[i, j]);
                component.Show();

                float x = -11 + xDiff * (i + 1);
                float y = -5 + yDiff * (j + 1);
                newCard.transform.position = new Vector3(x, y, 0);
            }
        }
    }
}
