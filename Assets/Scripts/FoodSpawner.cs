using UnityEngine;

public class FoodSpawner : MonoBehaviour
// Spawns food at a random location in the grid area.
// Must be invoked after snakes have spawned (to avoid spawning on top of them)
{
    public Food foodPrefab;
    public GridArea gridArea;

    private UnityEngine.Object[] snakes;

    private void Awake()
    // Awake is called once on scene initialisation
    {
       snakes = FindObjectsOfType<Snake>();
       gridArea = FindObjectOfType<GridArea>();
    }

    public void SpawnFood(int foodCount)
    {
        while (foodCount > 0) {
            Vector2 randomPosition = NewPosition();
            Instantiate(foodPrefab, randomPosition, Quaternion.identity);
            foodCount -= 1;
        }
    }

    public Vector2 NewPosition()
    {
        int i = Mathf.RoundToInt(UnityEngine.Random.Range(0, gridArea.openPositions.Count));

        Vector2 newPosition = gridArea.openPositions[i];
        gridArea.RemoveOpenPosition(newPosition);
        
        return newPosition;

    }
}
  