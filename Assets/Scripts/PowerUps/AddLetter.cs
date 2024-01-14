using UnityEngine;

public class AddLetter : PowerUp
{

    private void Awake()
    {
        displayText = "Add Letter!";
    }

    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // default: spawn one new letter
        foodSpawner.SpawnFood(foodCount: 1, colorEffect: true);
        foodSpawner.GetComponent<AudioSource>().Play();

        // destroy powerup
        base.OnTriggerEnter2D(other);
    }
}
