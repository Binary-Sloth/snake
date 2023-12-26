using UnityEngine;

public class RemoveLetter : PowerUp
{
    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        // get random letter
        FoodLetter[] letters = FindObjectsByType<FoodLetter>(FindObjectsSortMode.None);
        FoodLetter letter = letters[0];

        // remove it
        foodSpawner.gridArea.AddOpenPosition(letter.gameObject.transform.position);
        
        colorManager.ColorPulseDeSpawn(letter.gameObject, pulseDuration: 1f);
        
        // destroy powerup
        base.OnTriggerEnter2D(other);
    }
}