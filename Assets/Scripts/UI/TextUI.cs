using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    protected SnakeLetters snake;
    protected string text;

    protected virtual void Awake()
    {
        snake = FindAnyObjectByType<SnakeLetters>();
    }
    protected virtual void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = "";
        
    }

}
