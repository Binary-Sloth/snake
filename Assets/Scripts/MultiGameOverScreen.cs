using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiGameOverScreen : GameOverScreen
{
    private UnityEngine.Object[] snakes;

    public override void Setup() {
        base.Setup();

        snakes = FindObjectsOfType<Snake>();

        string winner = null;
        string score = null;
        int maxPoints = -100000;

        foreach (Snake snake in snakes) {
            snake.gameActive = false;
            if (snake.pointCounter > maxPoints) {
                winner = snake.screenName;
                score = snake.pointCounter.ToString();
                Color snakeColor = snake.GetComponent<SpriteRenderer>().color;
                winnerText.color = snakeColor;
            }
            Destroy(snake);
        }

        winnerText.text = $"{winner} snake wins with {score} points!";

    }

}
