using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardHandler : MonoBehaviour
{

    private Dictionary<KeyCode,string> keyValuePairs = new Dictionary<KeyCode, string>
    {
        { KeyCode.KeypadPlus , "+"},
        { KeyCode.KeypadMinus , "-"},
        { KeyCode.KeypadDivide , "/"},
        { KeyCode.KeypadMultiply , "*"},
        { KeyCode.KeypadPeriod , "."},
        { KeyCode.Plus , "+"},
        { KeyCode.Minus , "-"},
        { KeyCode.Slash, "/"},
        { KeyCode.Asterisk , "*"},
        { KeyCode.Period , "."},
        { KeyCode.Equals,"="},
        { KeyCode.KeypadEnter,"="}
    };
   
    void Update()
    {
        HandleKeyboardInput();
    }

    public void HandleKeyboardInput()
    {
        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                CalculatorController.Instance.AppendString(i.ToString());
                return;
            }

            if (Input.GetKeyDown(KeyCode.Keypad0 + i))
            {
                CalculatorController.Instance.AppendString(i.ToString());
                return;
            }
        }

        foreach (var pair in keyValuePairs)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                if (pair.Value == "=")
                {
                    CalculatorController.Instance.CalculateResult();
                }
                else
                {
                    CalculatorController.Instance.AppendString(pair.Value);
                }
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            CalculatorController.Instance.RemoveLastCharacter();
        }
    }
}
