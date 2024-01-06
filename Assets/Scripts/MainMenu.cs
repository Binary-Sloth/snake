using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CanvasRenderer instructionsScreen;

    void Start()
    {
        instructionsScreen.gameObject.SetActive(false);
    }

    public void ExitButton() {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartLetters() {
        SceneManager.LoadScene("SnakeLetters");
    }

    public void StartLettersAmy() {
        SceneManager.LoadScene("SnakeLettersAmy");
    }

    public void ShowInstructions() {
        instructionsScreen.gameObject.SetActive(true);
    }

    public void CloseInstructions() {
        instructionsScreen.gameObject.SetActive(false);
    }
}
