using System.Linq;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System;

public class WordManager : MonoBehaviour
{
    public string currentWord = "";

    private List<string> wordBankList = new();
    public string wordBankString = "";
    readonly string dictionaryPath = "Assets/Scripts/Dictionaries";

    public int bonusPoints;
    private int bonusPointCounter;

    private FoodSpawner brickSpawner;

    // bonus points for each letter beyond baseLength characters in a valid word
    private int baseLength = 3;
    private int perLetterBonus = 20;
    // penalty on bonus points for each repetition of a banked word
    private float repeatPenalty = 0.8f;

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

    public void BankWord() 
    {
        if (InDictionary(currentWord)) {
            // bank word and add bonus points only if it exists in dictionary
            bonusPointCounter += LengthBonus(currentWord, baseLength, perLetterBonus);
            // apply repeat penalty
            int repeats = CountOccurrences(currentWord);
            bonusPointCounter = Mathf.RoundToInt(bonusPointCounter * (float)Math.Pow(repeatPenalty, repeats));

            // output final bonus
            bonusPoints = bonusPointCounter;
            
            // add word to wordBank
            wordBankList.Add(currentWord);
            wordBankString = $"{currentWord} \r\n{wordBankString}";
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

    public bool InDictionary(string testWord)
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

    private int CountOccurrences(string testWord)
    // count occurrences of currentWord in wordBankList
    {
        int count = wordBankList.Count(s => s == testWord);

        return count;
    }

}