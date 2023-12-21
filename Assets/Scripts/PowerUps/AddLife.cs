
using UnityEngine;

// create powerup base class (which inherits from Food?)
// create powerup spawner that is timer based (inherit from FoodSpawner)

public class AddLife : Food
{
    private Snake snake;

    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            snake = other.gameObject.GetComponent<Snake>();
            snake.lifeCounter += 1;
        }

        Destroy(this.gameObject);
    }
}
