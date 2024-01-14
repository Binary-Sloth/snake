using UnityEngine;

// Food requires the GameObject to have a BoxCollider2D component
[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public int points = 10;
    [SerializeField] protected FoodSpawner foodSpawner;
    [SerializeField] protected ColorManager colorManager;

    protected virtual void Start()
    {
        if (!foodSpawner)
            {foodSpawner = GameObject.FindWithTag("LetterSpawner").GetComponent<FoodSpawner>();}
        if (!colorManager)
            {colorManager = FindAnyObjectByType<ColorManager>().GetComponent<ColorManager>();}
    }

    // action when collision occurs
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            transform.position = foodSpawner.NewPosition();
        }
    }
}
