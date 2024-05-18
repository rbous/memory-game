using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject widthSerialize;
    public GameObject heightSerialize;
    public static Gameboard Board;

    private TMP_InputField width;
    private TMP_InputField height;
    

    void Start()
    {
        width = widthSerialize.GetComponent<TMP_InputField>();
        height = heightSerialize.GetComponent<TMP_InputField>();
    }

    public void changeScene()
    {
        // Error Checking
        // Check if n, m are numbers
        if (!int.TryParse(width.text, out int n) || !int.TryParse(height.text, out int m))
        {
            Debug.Log("err");
            // TODO: add error message
            return;
        }
        // Check if there is an even number of cards
        if ((n * m) % 2 != 0)
        {
            Debug.Log("err");
            // TODO: add error message
            return;
        }
        
        // Testing
        Board = new(n, m);
        Debug.Log(Board.CardMatrix.ToString());
    }
}
