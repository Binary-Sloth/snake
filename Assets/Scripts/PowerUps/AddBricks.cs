using UnityEngine;

public class AddBricks : PowerUp
{
    private FoodSpawner brickSpawner;
    private float coverage = 0.01f;

    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        // get brickSpawner
        brickSpawner = GameObject.FindGameObjectWithTag("BrickSpawner").GetComponent<FoodSpawner>();

        // convert 1/10th open grid area to bricks
        int numOpenPositions = brickSpawner.gridArea.openPositions.Count;
        int numBricks = Mathf.Max(Mathf.RoundToInt(numOpenPositions * coverage), 1);
        brickSpawner.SpawnFood(numBricks);
        
        // destroy powerup
        base.OnTriggerEnter2D(other);
    }
}