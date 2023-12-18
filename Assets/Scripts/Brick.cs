using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Brick : Food
{
    // brick should have tag "obstacle"

    private void Awake() {  
        points = 0;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
        {
            // do nothing
        }
}
