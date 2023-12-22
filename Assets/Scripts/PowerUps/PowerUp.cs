using UnityEngine;

public class PowerUp : Food
{
    // common features for all powerups

    protected override void Start()
    {
        base.Start();
        // deduct points if powerUp is used
        points = -100;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}