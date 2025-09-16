using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum IconType
{
    None,
    Number,
    Operator,
    Decimal,
    Equal,
    Clear
}
public class IconButton : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] Button iconButton;
    [SerializeField] IconType Type =IconType.None;
    [SerializeField] string Icon;   
    void Awake()
    {
        if (iconButton == null)
        {
            iconButton = GetComponent<Button>();
        }
        iconButton.onClick.RemoveAllListeners();
        iconButton.onClick.AddListener(OnIconButtonClicked);
    }

    public void OnIconButtonClicked()
    {
        Debug.Log("Icon Button Clicked: " + Icon);
        switch (Type)
        {
            case IconType.Number:
                CalculatorController.Instance.AppendString(Icon);
                break;
            case IconType.Operator:
                CalculatorController.Instance.AppendString(Icon);
                break;
            case IconType.Decimal:
                CalculatorController.Instance.AppendString(Icon);
                break;
            case IconType.Equal:
                CalculatorController.Instance.CalculateResult();
                break;
            case IconType.Clear:
                CalculatorController.Instance.ClearString();
                break;
            default:
                Debug.LogWarning("IconType is None or not set.");
                break;
        }
    }

}
