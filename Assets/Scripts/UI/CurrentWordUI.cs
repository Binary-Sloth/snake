using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class currentWordUI : TextUI
{
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = wordManager.currentWord;
    }
}
