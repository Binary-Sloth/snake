using UnityEngine;

public class FoodSpawner : MonoBehaviour
// Spawns food at a random location in the grid area.
// Must be invoked after snakes have spawned (to avoid spawning on top of them)
{
    public int foodCount = 5;
    public Food foodPrefab;
    public BoxCollider2D gridArea;

    private UnityEngine.Object[] snakes;
    private Bounds bounds;

    private void Awake()
    // Awake is called once on scene initialisation
    {
       snakes = FindObjectsOfType<Snake>();
       bounds = gridArea.bounds;
    }

    private void Start()
    {
        while (foodCount > 0) {
            Vector2 randomPosition = NewPosition();
            Instantiate(foodPrefab, randomPosition, Quaternion.identity);
            foodCount -= 1;
        }

    }

    private Vector2Int RandomPosition()
    // generate a proposed new location in the game grid
    {
        int x = Mathf.RoundToInt(UnityEngine.Random.Range(bounds.min.x, bounds.max.x));
        int y = Mathf.RoundToInt(UnityEngine.Random.Range(bounds.min.y, bounds.max.y));

        return new Vector2Int(x, y);
    }

    public Vector2 NewPosition()
    {
        Vector2Int new_loc = RandomPosition();

        // Prevent the food from spawning on the snakes
        foreach (Snake snake in snakes) {
            while (snake.Occupies(new_loc.x, new_loc.y))
            {
                new_loc = RandomPosition();
            };
        }

        return new Vector2(new_loc.x, new_loc.y);

    }
}
  