using System;
using System.Collections.Generic;
using UnityEngine;

// Food requires the GameObject to have a BoxCollider2D component
[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public int points = 10;
    protected FoodSpawner foodSpawner;
    private GridArea gridArea;

    protected virtual void Start()
    {
        foodSpawner = FindObjectOfType<FoodSpawner>();
        gridArea = FindObjectOfType<GridArea>();
    }

    // action when collision occurs
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            // gridArea.AddOpenPosition(transform.position);
            transform.position = foodSpawner.NewPosition();
        }
    }
}
