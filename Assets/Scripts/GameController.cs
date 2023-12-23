using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private readonly int initialFoodCount = 10;

    // pause snake movement if game is inactive
    public bool gameActive;

    private void Start()
    {        
        PowerUpSpawner powerUpSpawner = FindAnyObjectByType<PowerUpSpawner>();
        FoodSpawner letterSpawner = GameObject.FindWithTag("LetterSpawner").GetComponent<FoodSpawner>();

        gameActive = true;

        if (gameActive) {
            letterSpawner.SpawnFood(initialFoodCount);
        }

        StartCoroutine(powerUpSpawner.SpawnPowerupCoroutine(15, 30, 1));

    }
    public GameOverScreen GameOverScreen;

    public void GameOver() {
        gameActive = false;
        GameOverScreen.Setup();
    }
}
