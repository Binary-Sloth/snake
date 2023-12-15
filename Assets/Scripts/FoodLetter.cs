using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoodLetter : Food
{
    public TextMesh textMesh;

    protected override void Start()
    {
        base.Start();
        textMesh = this.GetComponentInChildren<TextMesh>();
        GetRandomLetter();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        GetRandomLetter();
    }

    private void GetRandomLetter()
    {
        char randomLetter = (char)Random.Range('A', 'Z' + 1);
        textMesh.text = randomLetter.ToString();
    }
}
