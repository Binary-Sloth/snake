using UnityEngine;

public class AddLetter : PowerUp
{
    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // default: spawn one new letter
        foodSpawner.SpawnFood(foodCount: 1, colorEffect: true);

        // destroy powerup
        base.OnTriggerEnter2D(other);
    }
}
