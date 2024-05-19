using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    private SpriteRenderer renderer;
    public Card assignedCard;
    public bool Init { get; private set; }
        
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void OnClick(CardBehavior card)
    {
        if (GameManager.openedCard == null)
        {
            GameManager.openedCard = card;
            return;
        }

        var card2 = GameManager.openedCard;
        GameManager.openedCard = null;

        if (card == card2)
        {
            // oh em gee
        }
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

        Texture2D texture = Resources.Load<Texture2D>($"Deck/{name}");
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, 500, 726), new Vector2(0.25f, 0.25f));
        renderer.sprite = newSprite;
    }
}
