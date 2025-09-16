using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculatorController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] private string resultString;
    private static CalculatorController instance;

    string[] operators = { "+", "-", "/", "*", ".","x", "" };
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

        bool isOperator = Array.IndexOf(operators, character) >= 0;
        if (displayText.text == "0" || string.IsNullOrEmpty(resultString))
        {
            if (isOperator)
            {
                return;
            }

            resultString = character;
        }
        else
        {
            bool lastCharIsOperator = false;
            if (resultString.Length > 0)
            {
                var lastChar = resultString[resultString.Length - 1].ToString();
                lastCharIsOperator = Array.IndexOf(operators, lastChar) >= 0;
            }

            if (isOperator && lastCharIsOperator)
            {
                return;
            }

            if (character == ".")
            {
                int lastOperatorIndex = -1;
                for (int i = resultString.Length - 1; i >= 0; i--)
                {
                    if (Array.IndexOf(operators, resultString[i].ToString()) >= 0)
                    {
                        lastOperatorIndex = i;
                        break;
                    }
                }

                string lastNumber = lastOperatorIndex == -1 ? resultString : resultString.Substring(lastOperatorIndex + 1);

                if (lastNumber.Contains("."))
                {
                    return;
                }
            }
            resultString += character;
        }
        UpdateDisplay();
    }

    public void ClearString()
    {
        resultString = "0";
        UpdateDisplay();
    }

    public void RemoveLastCharacter()
    {
        if(!string.IsNullOrEmpty(resultString) || resultString.Length > 0)
        {
            resultString = resultString.Substring(0, resultString.Length - 1);
            if(string.IsNullOrEmpty(resultString))
            {
                resultString = "0";
            }
            else 
            {
                UpdateDisplay();
            }
        }
    }
   public void CalculateResult()
   {
        try
        {
            string expression = resultString.Replace("x", "*");
            var dataTable = new System.Data.DataTable();
            var value = dataTable.Compute(expression, "");
            resultString = Convert.ToDouble(value).ToString();
        }
        catch (Exception e)
        {
            Debug.LogError("Error in calculation: " + e.Message);
            resultString = "Error";
        }
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

