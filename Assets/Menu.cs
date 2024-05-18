using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject widthSerialize;
    public GameObject heightSerialize;

    private TMP_InputField width;
    private TMP_InputField height;

    void Start()
    {
        width = widthSerialize.GetComponent<TMP_InputField>();
        height = heightSerialize.GetComponent<TMP_InputField>();
    }

    void Update()
    {
    }
    
    public void changeScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
