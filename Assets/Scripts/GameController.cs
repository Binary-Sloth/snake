using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private readonly int initialFoodCount = 10;

    private void Start()
    {
        FoodSpawner letterSpawner = GameObject.FindWithTag("LetterSpawner").GetComponent<FoodSpawner>();

        letterSpawner.SpawnFood(initialFoodCount);
    }
    public GameOverScreen GameOverScreen;

    public void GameOver() {
        GameOverScreen.Setup();
    }
}
