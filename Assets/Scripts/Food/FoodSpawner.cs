using UnityEngine;

public class FoodSpawner : MonoBehaviour
// Spawns food at a random location in the grid area.
// Must be invoked after snakes have spawned (to avoid spawning on top of them)
{
    public Food foodPrefab;
    public GridArea gridArea;

    private Vector2 nullVector2;

    private void Awake()
    // Awake is called once on scene initialisation
    {
       gridArea = FindAnyObjectByType<GridArea>();

       // nullVector2 should have values that will never exist in gridArea.openpositions
       nullVector2 = new Vector2(1000.5f, 1000.5f);
    }

    public void SpawnFood(int foodCount = 1)
    {
        while (foodCount > 0) {
            Vector2 randomPosition = NewPosition();

            if (randomPosition != nullVector2) {
                Instantiate(foodPrefab, randomPosition, Quaternion.identity);
                foodCount -= 1;
            }

            else {
                break;
            }
        }
    }

    public Vector2 NewPosition()
    {
        if (gridArea.openPositions.Count > 0) {
            int i = Mathf.RoundToInt(UnityEngine.Random.Range(0, gridArea.openPositions.Count));

            Vector2 newPosition = gridArea.openPositions[i];
            gridArea.RemoveOpenPosition(newPosition);
        
        return newPosition;
        }

        // if there are no open positions left on the grid, return null
        return nullVector2;


    }
}
  