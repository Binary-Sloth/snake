using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameOverScreen GameOverScreen;

    private readonly int initialFoodCount = 10;

    // pause snake movement if game is inactive
    public bool gameActive;

    
    private void Start()
    {        
        PowerUpSpawner powerUpSpawner = FindAnyObjectByType<PowerUpSpawner>();
        FoodSpawner letterSpawner = GameObject.FindWithTag("LetterSpawner").GetComponent<FoodSpawner>();

        gameActive = false;

        letterSpawner.SpawnFood(initialFoodCount);


        StartCoroutine(powerUpSpawner.SpawnPowerupCoroutine(15, 30, 1));

    }
    

    public void GameOver() {
        gameActive = false;
        GameOverScreen.Setup();
    }
}
