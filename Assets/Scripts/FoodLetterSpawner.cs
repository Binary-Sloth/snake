using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLetterSpawner : FoodSpawner
{
    public override void RandomiseFood()
    {
        foodPrefab.GetComponentInChildren<TextMesh>().text = GetRandomLetter();
    }

    private string GetRandomLetter()
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        int index = UnityEngine.Random.Range(0, alphabet.Length);
        return alphabet[index].ToString();
    }


}
