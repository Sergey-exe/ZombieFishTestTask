using TMPro;
using UnityEngine;

public class UITextChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void ChangeInt(int value)
    {
        _text.text = value.ToString();
    }
}