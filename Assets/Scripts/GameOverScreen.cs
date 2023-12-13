using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    private UnityEngine.Object[] snakes;

    public void Setup() {
        gameObject.SetActive(true);
        snakes = FindObjectsOfType<Snake>();

        foreach (Snake snake in snakes) {
            snake.gameActive = false;
            if (snake.lifeCounter > 0) {
                string winner = snake.screenName;
                string score = snake.pointCounter.ToString();
                Color snakeColor = snake.GetComponent<SpriteRenderer>().color;
                winnerText.color = snakeColor;
                winnerText.text = $"{winner} snake wins with {score} points!";
            }
            Destroy(snake);

        }
        

    }

    public void RestartButton() {
        SceneManager.LoadScene("Snake");
    }

}
