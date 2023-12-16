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

    private void OnTriggerExit2D()
    {
        GetRandomLetter();
    }

    private void GetRandomLetter()
    {
        char randomLetter = (char)Random.Range('A', 'Z' + 1);
        textMesh.text = randomLetter.ToString();
    }
}