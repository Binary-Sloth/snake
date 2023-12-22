using UnityEngine;

public class SpeedUp : SpeedUpdate
{
    // increase speed
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        multiplier = 1.25f;

        base.OnTriggerEnter2D(other);
    }
}