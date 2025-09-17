using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static double Calculate(string calString)
    {
        if(calString == null) return 0;

        List<string> tokens = Tokenize(calString);

        tokens = ProcessString(tokens, new HashSet<string> { "*", "/" });
        tokens = ProcessString(tokens, new HashSet<string> { "+", "-" });

        return double.Parse(tokens[0]);
    }

    public static List<string> Tokenize(string calString)
    {
        List<string> tokens = new List<string>();
        string number = "";
        foreach (char c in calString)
        {
            if (char.IsDigit(c) || c == '.')
            {
                number += c;
            }
            else if ("+-*/".Contains(c))
            {
                if (number != "")
                {
                    tokens.Add(number);
                    number = "";
                }
                tokens.Add(c.ToString());
            }
            else
            {
                if (number != "")
                {
                    tokens.Add(number);
                    number = "";
                }
                tokens.Add(c.ToString());
            }
        }
        if (number != "")
        {
            tokens.Add(number);
        }
        return tokens;
    }

    private static List<string> ProcessString(List<string> tokens, HashSet<string> ops)
    { 
       List<string> result = new List<string>();
       double currentvalue = double.Parse(tokens[0]);

        for(int i = 1; i < tokens.Count; i+=2)
        {
                string op = tokens[i];
                double nextValue = double.Parse(tokens[i+1]);

                if(ops.Contains(op))
                {
                    switch(op)
                    {
                         case "*":
                            currentvalue *= nextValue;
                            break;
                         case "/":
                            currentvalue /= nextValue;
                            break;
                        case "+":
                        currentvalue += nextValue;
                            break;
                        case "-":
                        currentvalue -= nextValue;
                            break;
                    }
                }
                else
                {
                    result.Add(currentvalue.ToString());
                    result.Add(op);
                    currentvalue = nextValue;
                }
        }
        result.Add(currentvalue.ToString());
        return result;
    }
}
