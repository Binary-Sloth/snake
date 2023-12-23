using System.Linq;
using System.IO;
using UnityEngine;


public class SnakeLetters : Snake
{
    private WordManager wordManager;

    protected override void Awake()
    {
        base.Awake();
        wordManager = FindAnyObjectByType<WordManager>();
    }

    protected override void ResetState()
    {
        // also reset currentWord and bonusPoints
        UpdateWords();
        base.ResetState();
    }

    protected override void Grow(Collider2D food)
    // add food's letter to current word when it is 'eaten'
    {
        base.Grow(food);

        if (food.gameObject.GetComponent<FoodLetter>() != null)
        {
            FoodLetter foodLetter = food.gameObject.GetComponent<FoodLetter>();
            wordManager.AddLetter(foodLetter);

            // Display letter in snake
            string letter = foodLetter.textMesh.text;
            segments[wordManager.currentWord.Length].gameObject.GetComponentInChildren<TextMesh>().text = letter;
        }

    }

    protected override Vector2Int GetInput()
    // 'Bank' current word if the user hits spacebar
    {
        if (Input.GetKeyDown(KeyCode.Space) && wordManager.currentWord != "") {
            UpdateWords();
        }
        return base.GetInput();
    }

    private void UpdateWords() 
    {
        // clear letters in snake
        for (int i = 0; i < wordManager.currentWord.Length; i++) {
            segments[1 + i].gameObject.GetComponentInChildren<TextMesh>().text = "";
        }

        wordManager.BankWord();
        // add bonus points
        pointCounter += wordManager.bonusPoints;

    }
}
