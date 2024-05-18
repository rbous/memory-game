using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    private SpriteRenderer renderer;
    public Card assignedCard;
    public bool init;
        
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(Card card)
    {
        init = true;
        assignedCard = card;
    }

    public void Show()
        => ChangeTexture(assignedCard.ToString());

    public void Hide()
        => ChangeTexture("back");

    public void ChangeTexture(string name)
    {
        if (!init)
        {
            Debug.LogError("Attempt to change card texture when not init");
            return;
        }

        Texture2D texture = Resources.Load($"Deck/{name}") as Texture2D;
        Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, 1024, 1024), new Vector2(1, 1));
        renderer.sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {



    }
}
