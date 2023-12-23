using UnityEngine;

public class InvulnerableMode : PowerUp
{
    // invulnerability duration in seconds
    private readonly float duration = 10f;
    protected bool destroyerMode = false;

    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        if (other.CompareTag("Player")) {
            SnakeLetters snake = other.gameObject.GetComponent<SnakeLetters>();
            snake.StartCoroutine(snake.GoInvulnerable(duration, destroyerMode));
        }
        
        // destroy powerup
        base.OnTriggerEnter2D(other);
    }
}