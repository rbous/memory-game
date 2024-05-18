using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
}
