using UnityEngine;

public class RandomiseLetters : PowerUp
{
    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        // get random letter
        FoodLetter[] letters = FindObjectsByType<FoodLetter>(FindObjectsSortMode.None);
        
        foreach (FoodLetter letter in letters)
        {
            letter.GetRandomLetterFromCSV(letter.letterDataPath);
        }
        
        // destroy powerup
        base.OnTriggerEnter2D(other);
    }
}