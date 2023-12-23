using System.Linq;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class WordManager : MonoBehaviour
{
    public string currentWord = "";

    private List<string> wordBankList = new();
    public string wordBankString = "";
    readonly string dictionaryPath = "Assets/Scripts/Dictionaries";

    public int bonusPoints;
    private int bonusPointCounter;

    private FoodSpawner brickSpawner;

    private void Start()
    {
        brickSpawner = GameObject.FindGameObjectWithTag("BrickSpawner").GetComponent<FoodSpawner>();
    }

    public void AddLetter(FoodLetter foodLetter)
    {
        string letter = foodLetter.textMesh.text;
        currentWord += letter;
        bonusPointCounter += foodLetter.bonusPoints;
    }

    private int LengthBonus(string currentWord, int baseLength = 3, int bonus = 20) 
    // award bonus points for valid words longer than baseLength characters
    {
        if (currentWord.Length > baseLength) {
            return bonus * (currentWord.Length - baseLength);
        }
        else {
            return 0;
        }
    }

    public bool CheckDictionary(string testWord)
    {
        var files = Directory.GetFiles(dictionaryPath, "*.txt");

        foreach (var file in files) {
            var lines = File.ReadAllLines(file);

            foreach (var line in lines) {
                var words = line.Split(' ');
                if (words.Contains(testWord)) {
                    return true;
                }
            }
        }
        return false;
    }

    public void BankWord() 
    {
        if (CheckDictionary(currentWord)) {
            // bank word and add bonus points only if it exists in dictionary
            wordBankList.Add(currentWord);
            wordBankString = $"{currentWord} \r\n{wordBankString}";
            bonusPointCounter += LengthBonus(currentWord, baseLength: 3, bonus: 20);
            bonusPoints = bonusPointCounter;
        }
        
        else {
            bonusPoints = 0;
            // spawn bricks if word does not exist in dictionary
            brickSpawner.SpawnFood(foodCount: currentWord.Length);

        }

        // reset bonusPoints counter
        bonusPointCounter = 0;
        // reset currentWord
        currentWord = "";
    }

}