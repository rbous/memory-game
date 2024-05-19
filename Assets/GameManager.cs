using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject template;
    [NonSerialized] public SpriteRenderer sprite;
    public static GameManager Singleton;
    public static Gameboard Board;
    public static CardBehavior openedCard;
    public TMP_Text pointsText;
    public TMP_Text attemptsText;
    public GameObject messagePanel;
    public TMP_Text titleText;
    public TMP_Text messageText;
    public static List<CardBehavior> cards = new();
    public static int Points = 0;
    public static int Attempts = 0;


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
        Points = 0;
        Attempts = 0;

        foreach (var card in cards)
            DestroyImmediate(card);

        cards.Clear();

        Board = new(Menu.n, Menu.m);
        SpawnCards();
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
                component.Hide();

                float x = -11 + xDiff * (i + 1);
                float y = -5 + yDiff * (j + 1);
                newCard.transform.position = new Vector3(x, y, 0);
                cards.Add(component);
            }
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.K))
        {
            foreach (var card in cards)
                card.Show();
        }
    }

    public void GoBack()
        => OpenMessage("Return Menu", "Go back to the menu and lose all progress?");

    public void OpenMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenMessage(string title, string message)
    {
        messagePanel.SetActive(true);
        titleText.text = title;
        messageText.text = message;
    }

    public void CloseMessage()
    {
        messagePanel.SetActive(false);
    }
}
