using UnityEngine;

// Food requires the GameObject to have a BoxCollider2D component
[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public int points = 10;
    protected FoodSpawner foodSpawner;
    protected ColorManager colorManager;

    protected virtual void Start()
    {
        foodSpawner = GameObject.FindWithTag("LetterSpawner").GetComponent<FoodSpawner>();
        colorManager = FindAnyObjectByType<ColorManager>();
    }

    // action when collision occurs
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            transform.position = foodSpawner.NewPosition();
        }
    }
}
