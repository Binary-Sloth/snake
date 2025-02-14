using Unity.VisualScripting;
using UnityEngine;

public class AddBricks : PowerUp
{
    private FoodSpawner brickSpawner;
    private float coverage = 0.01f;
    
    private void Awake()
    {
        displayText = "Spawn Bricks!";
    }

    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        // get brickSpawner
        brickSpawner = GameObject.FindGameObjectWithTag("BrickSpawner").GetComponent<FoodSpawner>();

        // convert coverage fraction of open grid area to bricks
        int numOpenPositions = brickSpawner.gridArea.openPositions.Count;
        int numBricks = Mathf.Max(Mathf.RoundToInt(numOpenPositions * coverage), 1);
        brickSpawner.SpawnFood(numBricks, colorEffect: true);
        brickSpawner.GetComponent<AudioSource>().Play();
        
        // destroy powerup
        base.OnTriggerEnter2D(other);
    }
}