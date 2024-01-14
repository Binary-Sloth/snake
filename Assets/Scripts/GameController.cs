using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] StartScreen startScreen;
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] GridArea gridArea;
    [SerializeField] PowerUpSpawner powerUpSpawner;
    [SerializeField] FoodSpawner letterSpawner;

    [SerializeField] int initialFoodCount = 10;

    // pause snake movement if game is inactive
    public bool gameActive;

    
    private void Start()
    {        
        gameActive = true;
        
        CheckInitialItems();

        StartCoroutine(powerUpSpawner.SpawnPowerupCoroutine(waitMin: 15, waitMax: 30, powerUpCount: 1));
        gameActive = false;
        letterSpawner.SpawnFood(initialFoodCount);
        startScreen.gameObject.SetActive(true);
        gameOverScreen.gameObject.SetActive(false);
    }
    

    private void CheckInitialItems()
    // remove positions of starting items of the screen from gridArea.OpenPositions
    {
       Food[] foods = FindObjectsByType<Food>(FindObjectsSortMode.None);

       foreach (Food food in foods) {
            gridArea.RemoveOpenPosition(food.GetComponent<Transform>().position);
       }
    }

    public void GameOver() {
        gameActive = false;
        gameOverScreen.Setup();
        this.GetComponent<AudioSource>().mute = true;
        gameOverScreen.GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
