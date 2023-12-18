using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridArea : MonoBehaviour
{
    private Bounds gameBounds;
    private Snake snake;
    public List<Vector2> openPositions = new List<Vector2>();
    private Vector2 startPosition;



    void Start()
    {
        gameBounds = this.gameObject.GetComponent<BoxCollider2D>().bounds;
        snake = FindObjectOfType<Snake>();
        startPosition = snake.startPosition;
        InitializeOpenPositions();
    }

    private void InitializeOpenPositions()
    {
        for (float x = gameBounds.min.x; x <= gameBounds.max.x; x++) {
            for (float y = gameBounds.min.y; y <= gameBounds.max.y; y++) {
                openPositions.Add(new Vector2(x,y));
            }
        }
        // forbid spawning on snake start position
        openPositions.Remove(snake.startPosition);
    }

    public void RemoveOpenPosition(Vector2 position) 
    {
        if (openPositions.Exists(p => p.x == position.x && p.y == position.y)) {
            openPositions.RemoveAll(p => p.x == position.x && p.y == position.y);
        }
    }

    public void AddOpenPosition(Vector2 position)
    {
        // forbid spawning on snake start position
        if (position != startPosition) {
            openPositions.Add(position);
        }
    }

}
