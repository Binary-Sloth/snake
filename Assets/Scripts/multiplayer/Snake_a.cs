using System.Collections.Generic;
using UnityEngine;

public class Snake_a : Snake
{    
    protected Vector2Int input_key;

    protected override Vector2Int GetInput() 
    // Enable different derived classes to get input differently
    {
        
        // only allow y movement if snake is pointing in x direction
        if (direction.x != 0) 
        {
            if (Input.GetKeyDown(KeyCode.W)) {
                input_key = Vector2Int.up;
            } else if (Input.GetKeyDown(KeyCode.S)) {
                input_key = Vector2Int.down;
            }
        } 
        // only allow x movement if snake is pointing in y direction
        else if (direction.y != 0)
        {
            if (Input.GetKeyDown(KeyCode.A)) {
                input_key = Vector2Int.left;
            } else if (Input.GetKeyDown(KeyCode.D)) {
                input_key = Vector2Int.right;
            }
        }

        return input_key;
    }

}
