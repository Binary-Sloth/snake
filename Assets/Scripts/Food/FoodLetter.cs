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
    private string letterDataPath;
    public int bonusPoints;

    protected override void Start()
    {
        base.Start();
        letterDataPath = "Assets/Resources/LetterValues.csv";
        textMesh = this.GetComponentInChildren<TextMesh>();
        GetRandomLetter();
    }

    private void OnTriggerExit2D()
    {
        GetRandomLetter();
    }

    public void GetRandomLetter()
    // csv column 0 = letter, column 1 = probability, column 2 = points
    {
        string[] lines = File.ReadAllLines(letterDataPath);
        lines = lines.Skip(1).ToArray(); // skip header
        string[] letters = lines.Select(line => line.Split(',')[0]).ToArray();
        float[] probabilities = lines.Select(line => float.Parse(line.Split(',')[1])).ToArray();
        int[] letterPoints = lines.Select(line => int.Parse(line.Split(',')[2])).ToArray();

        float randomValue = Random.value;
        float cumulativeProbability = 0.0f;

        for (int i = 0; i < letters.Length; i++)
        {
            cumulativeProbability += probabilities[i];
            if (randomValue <= cumulativeProbability)
            {
                textMesh.text = letters[i][0].ToString();
                bonusPoints = letterPoints[i];
                return;
            }
        }
        // last letter
        textMesh.text = letters[letters.Length - 1][0].ToString();
        bonusPoints = letterPoints[letters.Length - 1];
    }
}