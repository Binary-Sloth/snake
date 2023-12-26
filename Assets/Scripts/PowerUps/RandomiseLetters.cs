using UnityEngine;

public class RandomiseLetters : PowerUp
{
    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        // get random letter
        FoodLetter[] letters = FindObjectsByType<FoodLetter>(FindObjectsSortMode.None);

        // get color manager
        ColorManager colorManager = FindAnyObjectByType<ColorManager>();
        
        foreach (FoodLetter letter in letters)
        {
            letter.GetRandomLetter();
            colorManager.ColorPulseRefresh(letter.gameObject);

        }
        
        // destroy powerup
        base.OnTriggerEnter2D(other);
    }
}