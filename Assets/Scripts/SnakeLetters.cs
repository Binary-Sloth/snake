using System.Linq;
using System.IO;
using UnityEngine;


public class SnakeLetters : Snake
{
    // public string currentWord = "";
    // public string wordBank = "";
    // readonly string dictionaryPath = "Assets/Scripts/Dictionaries";


    // public int bonusPoints;

    // private FoodSpawner brickSpawner;
    private WordManager wordManager;

    protected override void Awake()
    {
        base.Awake();
        // brickSpawner = GameObject.FindGameObjectWithTag("BrickSpawner").GetComponent<FoodSpawner>();
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
            // string letter = food.gameObject.GetComponentInChildren<TextMesh>().text;
            // currentWord += letter;
            // bonusPoints += food.gameObject.GetComponent<FoodLetter>().bonusPoints;
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

    // private int LengthBonus(string currentWord, int baseLength = 3, int bonus = 20) 
    // // award bonus points for valid words longer than baseLength characters
    // {
    //     if (currentWord.Length > baseLength) {
    //         return bonus * (currentWord.Length - baseLength);
    //     }

    //     return 0;
    // }

    private void UpdateWords() 
    {
        // if (CheckDictionary(currentWord)) {
        //     // bank word and add bonus points only if it exists in dictionary
        //     wordBank = $"{currentWord} \r\n{wordBank}";
        //     pointCounter += bonusPoints;
        //     pointCounter += LengthBonus(currentWord, baseLength: 3, bonus: 20);
        // }
        
        // else {
        //     // spawn bricks if word does not exist in dictionary
        //     brickSpawner.SpawnFood(foodCount: currentWord.Length);
        // }

        // clear letters in snake
        for (int i = 0; i < wordManager.currentWord.Length; i++) {
            segments[1 + i].gameObject.GetComponentInChildren<TextMesh>().text = "";
        }

        wordManager.BankWord();
        // add bonus points
        pointCounter += wordManager.bonusPoints;

        // // reset bonusPoints counter
        // bonusPoints = 0;
        // // reset currentWord
        // currentWord = "";
    }

    // public bool CheckDictionary(string testWord)
    // {
    //     var files = Directory.GetFiles(dictionaryPath, "*.txt");

    //     foreach (var file in files)
    //     {
    //         var lines = File.ReadAllLines(file);

    //         foreach (var line in lines)
    //         {
    //             var words = line.Split(' ');
    //             if (words.Contains(testWord))
    //             {
    //                 return true;
    //             }
    //         }
    //     }

    //     return false;
    // }
}
