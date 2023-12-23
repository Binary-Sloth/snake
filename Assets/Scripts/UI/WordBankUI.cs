using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WordBankUI : TextUI
{
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = wordManager.wordBankString;
    }
}
