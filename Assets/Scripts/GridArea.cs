using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridArea : MonoBehaviour
{
    private Bounds gameBounds;
    public List<Vector2> openPositions = new List<Vector2>();


    void Start()
    {
        gameBounds = this.gameObject.GetComponent<BoxCollider2D>().bounds;
        InitializeOpenPositions();
        // foreach (Vector2 position in unoccupiedPositions) {
        //     Debug.Log($"{position.x}, {position.y}");
        // }
    }

    private void InitializeOpenPositions()
    {
        Debug.Log($"min x: {gameBounds.min.x} \r\n max x: {gameBounds.max.x}");
        Debug.Log($"min y: {gameBounds.min.y} \r\n max y: {gameBounds.max.y}");
        for (float x = gameBounds.min.x; x <= gameBounds.max.x; x++) {
            for (float y = gameBounds.min.y; y <= gameBounds.max.y; y++) {
                openPositions.Add(new Vector2(x,y));
            }
        }
    }

    public void RemoveOpenPosition(Vector2 position) 
    {
        openPositions.RemoveAll(p => p.x == position.x && p.y == position.y);
    }

    public void AddOpenPosition(Vector2 position)
    {
        openPositions.Add(position);
    }

}
