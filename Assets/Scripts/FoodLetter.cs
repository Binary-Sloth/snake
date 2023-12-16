using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// for GetRandomCapitalLetterFromCSV()
using System.IO;
using System.Linq;

public class FoodLetter : Food
{
    public TextMesh textMesh;

    protected override void Start()
    {
        base.Start();
        textMesh = this.GetComponentInChildren<TextMesh>();
        GetRandomLetter();
    }

    private void OnTriggerExit2D()
    {
        GetRandomLetter();
    }

    private void GetRandomLetter()
    {
        char randomLetter = (char)Random.Range('A', 'Z' + 1);
        textMesh.text = randomLetter.ToString();
    }

    private char GetRandomCapitalLetter()
    // from Bing
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        float[] probabilities = {0.1f, 0.2f, 0.3f, 0.05f, 0.05f, 0.1f, 0.1f, 0.05f, 0.05f, 0.05f};
        float randomValue = Random.value;
        float cumulativeProbability = 0.0f;
        for (int i = 0; i < letters.Length; i++)
        {
            cumulativeProbability += probabilities[i];
            if (randomValue <= cumulativeProbability)
            {
                return letters[i];
            }
        }
        return letters[letters.Length - 1];
    }

    private char GetRandomCapitalLetterFromCSV(string filePath)
    // Bing
    {
        string[] lines = File.ReadAllLines(filePath);
        string[] letters = lines.Select(line => line.Split(',')[0]).ToArray();
        float[] probabilities = lines.Select(line => float.Parse(line.Split(',')[1])).ToArray();
        float randomValue = UnityEngine.Random.value;
        float cumulativeProbability = 0.0f;
        for (int i = 0; i < letters.Length; i++)
        {
            cumulativeProbability += probabilities[i];
            if (randomValue <= cumulativeProbability)
            {
                return letters[i][0];
            }
        }
        return letters[letters.Length - 1][0];
    }


}