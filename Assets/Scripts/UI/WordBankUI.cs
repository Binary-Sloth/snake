using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordBankUI : TextUI
{
    void Update()
    {
        this.GetComponentInChildren<TextMeshPro>().text = wordManager.wordBankString;
    }
}
