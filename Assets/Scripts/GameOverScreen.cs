using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI winnerText;

    private UnityEngine.Object[] snakes;

    public void Setup() {
        gameObject.SetActive(true);
        snakes = FindObjectsOfType<Snake>();

        string winner = null;
        string score = null;
        int maxPoints = 0;

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
    

    public void RestartButton() {
        SceneManager.LoadScene("Snake");
    }

    public void MenuButton() {
        SceneManager.LoadScene("MainMenu");
    }

}
