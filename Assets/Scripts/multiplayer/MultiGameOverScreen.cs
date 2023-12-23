using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiGameOverScreen : GameOverScreen
{
    private UnityEngine.Object[] snakes;

    public override void Setup() {
        base.Setup();

        bool draw = false;

        snakes = FindObjectsOfType<Snake>();


        int maxPoints = -100000; // arbitrary low number

        foreach (Snake snake in snakes) {
            if (snake.pointCounter > maxPoints) {
                maxPoints = snake.pointCounter;
                ProcessSnake(snake);
            }
            else if (snake.pointCounter == maxPoints) {
                draw = true;
            }
            Destroy(snake);
        }

        if (draw) {
            winnerText.text = $"It's a draw! {score} points each!";
        }
        else {
            winnerText.text = $"{winnerName} snake wins with {score} points!";
        }
    }

}
