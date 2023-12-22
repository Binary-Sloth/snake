using UnityEngine;

public class SpeedUpdate : PowerUp
{
    protected float multiplier = 1f;

    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        if (other.CompareTag("Player")) {
            SnakeLetters snake = other.gameObject.GetComponent<SnakeLetters>();

            // set maximum snake speed to 25
            if (snake.speed * snake.speedMultiplier * multiplier > 25f) {
                multiplier = 25f / (snake.speed * snake.speedMultiplier);
            }
            // set minimum snake speed to 1
            else if (snake.speed * snake.speedMultiplier * multiplier < 1f) {
                multiplier = 1f / (snake.speed * snake.speedMultiplier);
            }

            // apply speed multiplier
            snake.speedMultiplier *= multiplier;
            snake.SetDeltaTime(); 
        }
        
        // destroy powerup
        base.OnTriggerEnter2D(other);
    }
}