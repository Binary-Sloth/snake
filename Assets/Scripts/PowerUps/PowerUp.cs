using TMPro.Examples;
using UnityEngine;

public class PowerUp : Food
{
    
    protected string displayText;
    // powerup duration on screen
    private float liveTime = 25f;
    // warning colors start after liveTime, powerup despawns after despawnTime
    private float despawnTime = 5f;

    [SerializeField] protected GameObject floatingTextPrefab;

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
        if(floatingTextPrefab)
            {
                
                GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
                TextMesh textMesh = prefab.GetComponentInChildren<TextMesh>();
                textMesh.text = displayText;
                textMesh.color = this. GetComponent<SpriteRenderer>().color;
                textMesh.fontStyle = FontStyle.Italic;

            }
        Destroy(this.gameObject);
    }
}