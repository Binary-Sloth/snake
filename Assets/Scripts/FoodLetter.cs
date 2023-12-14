using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodLetter : Food
{
    protected override void Start()
    {
        foodSpawner = FindObjectOfType<FoodLetterSpawner>();

    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        foodSpawner.RandomiseFood();
        this.GetComponentInChildren<TextMesh>().text = foodSpawner.foodPrefab.GetComponentInChildren<TextMesh>().text;


    }
}
