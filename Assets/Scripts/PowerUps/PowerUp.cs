using UnityEngine;

public class PowerUp : Food
{
    // powerup duration on screen
    private float liveTime = 25f;
    // warning colors start after liveTime, powerup despawns after despawnTime
    private float despawnTime = 5f;

    protected override void Start()
    {
        base.Start();
        // set points for each powerup
        points = 0;

        // Destroy after timer seconds
        colorManager.ColorPulseDeSpawn(this.gameObject, pulseDuration: despawnTime, delay: liveTime);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}