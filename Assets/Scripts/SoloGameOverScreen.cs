using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloGameOverScreen : GameOverScreen
{
    Snake snake;

    public override void Setup() {
        base.Setup();
        processSnake(snake);

        winnerText.text = $"You got {score} points!";

    }

}
