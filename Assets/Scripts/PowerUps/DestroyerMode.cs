using UnityEngine;

public class DestroyerMode : InvulnerableMode
{
    // action when collision occurs
    protected override void OnTriggerEnter2D(Collider2D other)
    {      
        destroyerMode = true;
        base.OnTriggerEnter2D(other);
    }
}