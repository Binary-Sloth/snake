using UnityEngine;

public class SpeedDown : SpeedUpdate
{

    // reduce speed
    protected override void OnTriggerEnter2D(Collider2D other)
    {       
        multiplier = 0.8f;

        base.OnTriggerEnter2D(other);
    }
}