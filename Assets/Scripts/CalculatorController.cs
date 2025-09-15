using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculatorController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] private string resultString;
    private static CalculatorController instance;
    public static CalculatorController Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("CalculatorController is NULL");
            }
            return instance;
        }

    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        displayText.text = "0";
    }

    public void AppendString(string character)
    {
        if (displayText.text == "0")
        {
            resultString = character;
        }
        else
        {
            resultString += character;
        }
        UpdateDisplay();
    }

    public void ClearString()
    {
        resultString = "0";
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (displayText != null)
        {   
            displayText.text = resultString;
        }
    }
}

