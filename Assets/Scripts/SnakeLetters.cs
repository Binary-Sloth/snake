using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeLetters : Snake
{
    private string currentWord = "";

    private List<string> wordBank = new List<string>();

    protected override void Grow(Collider2D food)
    {
        base.Grow(food);
        string letter = food.gameObject.GetComponentInChildren<TextMesh>().text;
        currentWord += letter;
        Debug.Log($"currentWord: {currentWord}");
    }

    protected override Vector2Int GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentWord != "") {
            wordBank.Add(currentWord);
            currentWord = "";

            foreach (string word in wordBank)
            {
                Debug.Log($"Banked: {word}");
            }
        }
        return base.GetInput();
    }


}
