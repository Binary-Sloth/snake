using UnityEngine;

public class PowerUp : Food
{
    // powerup duration on screen
    private float duration = 30f;

    protected override void Start()
    {
        base.Start();
        // set points for each powerup
        points = 0;

        // Destroy after duration seconds
        Destroy(this.gameObject, duration);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}