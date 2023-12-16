using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;

public class SnakeLetters : Snake
{
    private string currentWord = "";
    private List<string> wordBank = new List<string>();
    string dictionaryPath = "Assets/Scripts/Dictionaries";

    protected override void Grow(Collider2D food)
    // add food's letter to current word when it is 'eaten'
    {
        base.Grow(food);
        string letter = food.gameObject.GetComponentInChildren<TextMesh>().text;
        currentWord += letter;
        Debug.Log($"currentWord: {currentWord}");
    }

    protected override Vector2Int GetInput()
    // 'Bank' current word if the user hits spacebar
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentWord != "") {
            
            if (CheckDictionary(currentWord)) {
                wordBank.Add(currentWord);
                Debug.Log($"Banked: {currentWord}");
            }
            
            else {
                Debug.Log($"{currentWord} is not in the dictionary");
            }
            currentWord = "";
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
