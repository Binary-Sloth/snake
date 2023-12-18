using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    private void Start()
    {
        FoodSpawner letterSpawner = GameObject.FindWithTag("LetterSpawner").GetComponent<FoodSpawner>();

        letterSpawner.SpawnFood(10);
    }
    public GameOverScreen GameOverScreen;

    public void GameOver() {
        GameOverScreen.Setup();
    }
}
