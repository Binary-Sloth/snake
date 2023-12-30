using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LifeUI : TextUI
{
    // void Start()
    // {
    //     this.GetComponentInChildren<TextMeshPro>().text = "Life <color=#1CF20D>3";
    // }

    void Update()
    {
        string life = snake.lifeCounter.ToString();
        this.GetComponentInChildren<TextMeshPro>().text =  $"Life <color=#1CF20D>{life}";
    }
}
