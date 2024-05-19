using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject widthSerialize;
    public GameObject heightSerialize;

    private TMP_InputField width;
    private TMP_InputField height;

    public static int n;
    public static int m;

    void Start()
    {
        width = widthSerialize.GetComponent<TMP_InputField>();
        height = heightSerialize.GetComponent<TMP_InputField>();
    }

    public void changeScene()
    {
        // Error Checking
        // Check if n, m are numbers
        if (!int.TryParse(width.text, out n) || !int.TryParse(height.text, out m))
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

        SceneManager.LoadScene("Game");
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
