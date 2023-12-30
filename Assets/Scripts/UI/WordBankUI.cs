using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class WordBankUI : TextUI
{
    Vector2 startPosition;
    TextMeshPro textbox;

    void Start()
    {
        startPosition = new Vector2(
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y)
        );
        
        TextMeshPro textbox = this.GetComponentInChildren<TextMeshPro>();
    }
    
    void Update()
    {
        textbox = this.GetComponentInChildren<TextMeshPro>();
        textbox.text = wordManager.wordBankString;

        if (textbox.isTextOverflowing) {
            transform.position = startPosition + new Vector2(2, 0);
        }
    }
}
