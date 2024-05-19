using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject widthSerialize;
    public GameObject heightSerialize;
    public GameObject errorPanel;
    public GameObject errorMessage;
    public TMP_Text errorTitle;

    private TMP_InputField width;
    private TMP_InputField height;

    public static int n;
    public static int m;

    void Start()
    {
        width = widthSerialize.GetComponent<TMP_InputField>();
        height = heightSerialize.GetComponent<TMP_InputField>();
        errorPanel.SetActive(false);
    }

    public void changeScene()
    {
        if (!int.TryParse(width.text, out n) || !int.TryParse(height.text, out m) || n <= 0 || m <= 0)
        {
            OpenErrorPanel("Please enter valid numbers for height & width (non-decimal/non-negative.)");
            return;
        }

        if (n > 13 || m > 4)
        {
            OpenErrorPanel("Maximum numbers passed for width/height\n\nWidth: 13\nHeight: 4");
            return;
        }

        if ((n * m) % 2 != 0)
        {
            OpenErrorPanel("Total number of cards must be even.");
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

    public void OpenErrorPanel(string message, string title = "Error")
    {
        errorPanel.SetActive(true);
        errorMessage.GetComponent<TMP_Text>().text = message;
        errorTitle.text = title;
    }

    public void CloseErrorPanel()
        => errorPanel.SetActive(false);

    public void ProcessOk()
    {
        if (errorTitle.text != "Error")
        {
            Application.Quit(0);
            return;
        }

        CloseErrorPanel();
    }

    public void CloseGame()
        => OpenErrorPanel("Are you sure you want to close the game?", "Confirm");
}
