using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class currentWordUI : TextUI
{
    void Update()
    {
        this.GetComponentInChildren<TextMeshPro>().text = $"Words\r\n<color=#1CF20D>{wordManager.currentWord}";
    }
}
