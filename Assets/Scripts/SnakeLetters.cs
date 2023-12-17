using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using TMPro;

public class SnakeLetters : Snake
{
    private string currentWord = "";
    private string wordBank = "";
    string dictionaryPath = "Assets/Scripts/Dictionaries";

    public TextMeshProUGUI currentWordUI;
    public TextMeshProUGUI wordBankUI;

    protected override void Start()
    {
        base.Start();
        currentWordUI.text = currentWord;
        wordBankUI.text = wordBank;
    }

    protected override void Grow(Collider2D food)
    // add food's letter to current word when it is 'eaten'
    {
        base.Grow(food);
        string letter = food.gameObject.GetComponentInChildren<TextMesh>().text;
        currentWord += letter;
        currentWordUI.text = currentWord;
    }

    protected override Vector2Int GetInput()
    // 'Bank' current word if the user hits spacebar
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentWord != "") {
            
            if (CheckDictionary(currentWord)) {
                wordBank = $"{currentWord} \r\n{wordBank}";
                wordBankUI.text = wordBank;
                Debug.Log($"Banked: {currentWord}");
            }
            
            else {
                Debug.Log($"{currentWord} is not in the dictionary");
            }

            currentWord = "";
            currentWordUI.text = currentWord;
        }
        return base.GetInput();
    }

    public bool CheckDictionary(string testWord)
    {
        var files = Directory.GetFiles(dictionaryPath, "*.txt");

        foreach (var file in files)
        {
            var lines = File.ReadAllLines(file);

            foreach (var line in lines)
            {
                var words = line.Split(' ');

                if (words.Contains(testWord))
                {
                    return true;
                }
            }
        }

        return false;
    }

}
