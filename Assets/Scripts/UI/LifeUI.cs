using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LifeUI : TextUI
{
    protected override void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = "0";
    }

    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = snake.lifeCounter.ToString();
    }
}
