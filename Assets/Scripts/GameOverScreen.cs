using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    private UnityEngine.Object[] snakes;

    public void Setup() {
        gameObject.SetActive(true);
        snakes = FindObjectsOfType<Snake>();

        foreach (Snake snake in snakes) {
            Debug.Log(snake);
            if (snake.lifeCounter > 0) {
                string winner = snake.screenName;
                int score = snake.pointCounter;
                Debug.Log(winner);
                Debug.Log(score);
                winnerText.text = winner + " snake wins with " + score.ToString() + " points!";
            }
        }
        

    }
}
