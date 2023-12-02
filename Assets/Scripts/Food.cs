using System;
using System.Collections.Generic;
using UnityEngine;

// Food requires the GameObject to have a BoxCollider2D component
[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private Vector2Int loc;

    private UnityEngine.Object[] snakes;

    private void Awake()
    // Awake is called once on scene initialisation
    {
       snakes = FindObjectsOfType<Snake>();
    }

    private void Start()
    {
        UpdatePosition();
    }

    private Vector2Int RandomizePosition()
    // generate a proposed new location
    {
        Bounds bounds = gridArea.bounds;

        int x = Mathf.RoundToInt(UnityEngine.Random.Range(bounds.min.x, bounds.max.x));
        int y = Mathf.RoundToInt(UnityEngine.Random.Range(bounds.min.y, bounds.max.y));

        return new Vector2Int(x, y);

    }

    private void UpdatePosition()
    {
        Vector2Int new_loc = RandomizePosition();

        // Prevent the food from spawning on the snakes
        foreach (Snake snake in snakes) {
            while (snake.Occupies(new_loc.x, new_loc.y))
            {
                new_loc = RandomizePosition();
                Debug.Log("recalculated position");
            };
        }

        transform.position = new Vector2(new_loc.x, new_loc.y);

    }

    // action when collision occurs
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            UpdatePosition();
        }
    }
}
