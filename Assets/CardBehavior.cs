using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Card assignedCard;
    [NonSerialized] public bool Revealed;
    public bool Init { get; private set; }
    public static bool Waiting;

    public void OnMouseDown()
    {
        if (Waiting || (GameManager.openedCard == this) || Revealed)
            return;

        Show();

        if (GameManager.openedCard == null)
        {
            GameManager.openedCard = this;
            return;
        }

        var card2 = GameManager.openedCard;
        GameManager.openedCard = null;
        GameManager.Attempts += 1;
        GameManager.Singleton.attemptsText.text = $"Turns: <b>{GameManager.Attempts}";

        if (assignedCard == card2.assignedCard)
        {
            Revealed = true;
            card2.Revealed = true;

            GameManager.Points += 1;
            GameManager.Singleton.pointsText.text = $"Points: <b>{GameManager.Points}";

            if (GameManager.cards.Count(x => x.Revealed) >= GameManager.Board.M * GameManager.Board.N)
                GameManager.Singleton.OpenMessage("Game Finished", $"Statistics\n\nWidth: {GameManager.Board.M}\nHeight: {GameManager.Board.N}\nPairs Found: {GameManager.Points}\nTurns: {GameManager.Attempts}");

            return;
        }

        StartCoroutine(HideCard(this, card2));
    }

    public IEnumerator HideCard(CardBehavior card1, CardBehavior card2)
    {
        Waiting = true;
        yield return new WaitForSeconds(1.5f);
        Waiting = false;
        card1.Hide();
        card2.Hide();
    }

    public void Initialize(Card card)
    {
        Init = true;
        assignedCard = card;
    }

    public void Show()
        => ChangeTexture(assignedCard.ToString());

    public void Hide()
        => ChangeTexture("back");

    public void ChangeTexture(string name)
    {
        if (!Init)
        {
            Debug.LogError("Attempt to change card texture when not init");
            return;
        }

        if (sprite == null)
            sprite = gameObject.GetComponent<SpriteRenderer>();

        Texture2D texture = Resources.Load<Texture2D>($"Deck/{name}");
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, 500, 726), new Vector2(0.25f, 0.25f));
        sprite.sprite = newSprite;
    }
}
