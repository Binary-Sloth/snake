using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartClassic() {
        SceneManager.LoadScene("Snake");
    }

    public void StartLetters() {
        SceneManager.LoadScene("SnakeLetters");
    }
}
