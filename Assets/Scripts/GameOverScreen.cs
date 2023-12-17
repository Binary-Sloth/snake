using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public string currentScene;
    public TextMeshProUGUI winnerText;

    public int score = 0;
    protected string winnerName ;

    public virtual void Setup() {
        gameObject.SetActive(true);
        winnerText.text = $"{winnerName} got {score} points!";
        // Deactivate and destroy snake(s)
    }
    

    public void RestartButton() {
        SceneManager.LoadScene(currentScene);
    }

    public void MenuButton() {
        SceneManager.LoadScene("MainMenu");
    }

    protected void processSnake(Snake snake) {
        // delete snake and extract info
        snake.gameActive = false;
        winnerName = snake.screenName;
        score = snake.pointCounter;
        Color snakeColor = snake.GetComponent<SpriteRenderer>().color;
        winnerText.color = snakeColor;
    }

}
