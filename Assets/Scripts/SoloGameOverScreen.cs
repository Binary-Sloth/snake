using UnityEngine;

public class SoloGameOverScreen : GameOverScreen
{
    public Snake snake;

    public override void Setup() {
        base.Setup();
        ProcessSnake(snake);

        winnerText.text = $"You got {score} points!";

    }

}
