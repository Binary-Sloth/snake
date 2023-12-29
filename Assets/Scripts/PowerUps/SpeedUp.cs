using UnityEngine;

public class SpeedUp : SpeedUpdate
{
    private void Awake()
    {
        displayText = "Speed Up!";
    }
    // increase speed
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        multiplier = 1.25f;

        base.OnTriggerEnter2D(other);
    }
}