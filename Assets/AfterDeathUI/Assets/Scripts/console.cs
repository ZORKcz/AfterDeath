using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class console : MonoBehaviour
{
    public TMP_Text outputText;
    //public TextMeshPro inputText;
    public TMP_InputField inputField;
    void Start()
    {
        outputText.text = "Enter code";
    }


    void Update()
    {
        
    }
    public void ConsoleInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            outputText.text += "\n" + inputField.text;
            inputField.text = "";
        }

    }
}
