using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;

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
        Print2DArray(Board.CardMatrix);
    }

    public static void Print2DArray<T>(T[,] matrix)
    {
        StringBuilder builder = new();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                builder.Append(matrix[i, j] + "\t");
            }
            builder.AppendLine();
        }

        Debug.Log(builder.ToString());
    }
}
