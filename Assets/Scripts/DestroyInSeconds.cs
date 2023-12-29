
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] private float durationInSeconds = 0.8f;

    void Start()
    {
        Destroy(this.gameObject, durationInSeconds);
    }
}