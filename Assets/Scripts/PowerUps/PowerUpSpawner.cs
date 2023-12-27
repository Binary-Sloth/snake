using System.Collections;
using UnityEngine;

public class PowerUpSpawner : FoodSpawner
// spawns random powerups
{
    private GameController gameController;
    private PowerUp[] powerUps;

    private void Start()
    {
        powerUps = FindObjectsByType<PowerUp>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        gameController = FindAnyObjectByType<GameController>();
    }

    public IEnumerator SpawnPowerupCoroutine(float waitMin, float waitMax, int powerUpCount)
    {
        while (gameController.gameActive) {
            SpawnPowerUps(powerUpCount);
            float waitTime = Random.Range(waitMin, waitMax);
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void SpawnPowerUps(int powerUpCount = 1)
    {
        while (powerUpCount > 0) {

            int i = Random.Range(0, powerUps.Length);
            Vector2 randomPosition = NewPosition();

            if (randomPosition != nullVector2) {
                Instantiate(powerUps[i], randomPosition, Quaternion.identity).gameObject.SetActive(true);               
                powerUpCount -= 1;
            }

        else {
            break;
        }
    }   


    }


}