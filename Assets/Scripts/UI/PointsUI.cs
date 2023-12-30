using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointsUI : TextUI
{
    // void Start()
    // {
    //     this.GetComponentInChildren<TextMeshPro>().text = "Score <color=#1CF20D>0";
    // }

    void Update()
    {
        string points = snake.pointCounter.ToString();
        this.GetComponentInChildren<TextMeshPro>().text =  $"Score <color=#1CF20D>{points}";
    }
}
