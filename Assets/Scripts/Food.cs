using System;
using System.Collections.Generic;
using UnityEngine;

// Food requires the GameObject to have a BoxCollider2D component
[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public int points = 10;
    protected FoodSpawner foodSpawner;

    protected virtual void Start()
    {
        foodSpawner = FindObjectOfType<FoodSpawner>();
    }

    // action when collision occurs
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            transform.position = foodSpawner.NewPosition();
        }
    }
}
