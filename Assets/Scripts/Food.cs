using System;
using System.Collections.Generic;
using UnityEngine;

// Food requires the GameObject to have a BoxCollider2D component
[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public int points = 10;
    private FoodSpawner foodSpawner;

    private void Start()
    {
        foodSpawner = FindObjectOfType<FoodSpawner>();
    }

    // action when collision occurs
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            transform.position = foodSpawner.NewPosition();
        }
    }
}
