using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    protected SnakeLetters snake;
    protected WordManager wordManager;
    protected string text;

    protected virtual void Awake()
    {
        snake = FindAnyObjectByType<SnakeLetters>();
        wordManager = FindAnyObjectByType<WordManager>();
    }
    protected virtual void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = "";
        
    }

}
