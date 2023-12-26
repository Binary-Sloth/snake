using System;
using System.Collections;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    private Color cSuccess;
    private Color cFail;
    private Color cInvincible;
    private Color cDestroyer;
    private Color cRefresh;
    private Color cSpawner;


    void Start()
    {
        cSuccess = Color.yellow;
        cFail = Color.red;
        cInvincible = Color.white;
        cDestroyer = Color.magenta;
        cRefresh = Color.cyan;
        cSpawner = Color.clear;
    }

    public IEnumerator ColorPulse(GameObject gameObject, Color altColour, float duration, int pulse, float delay = 0f, bool despawn = false)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        // save origin color
        Color originColor = sr.color;

        yield return new WaitForSeconds(delay);
        // lerp animation with given duration in seconds
        for (float t = 0; t < 1.0f; t += Time.deltaTime/duration)
        {
            try {
                sr.color = Color.Lerp(altColour, originColor , Mathf.PingPong(t * pulse * 2, 1));
            }
            catch(MissingReferenceException ex) {
                // ignore in case snake resets and gameObject disappears (for tail segments)
            }
            yield return null;
        }

        if (despawn) {
            Destroy(gameObject);
        }
        else {
        // restore origin color
            try {
                sr.color = originColor;
            }
            catch(MissingReferenceException ex) {
                // ignore in case snake resets (for tail segments)
            }
            yield return null;
        }
    }

    public void ColorPulseSuccess(GameObject gameObject)
    {
        StartCoroutine(ColorPulse(gameObject, cSuccess, duration: 1f, pulse: 2));
    }

    public void ColorPulseFail(GameObject gameObject)
    {
        StartCoroutine(ColorPulse(gameObject, cFail, duration: 1f, pulse: 2));
    }

    public void ColorPulseInvincible(GameObject gameObject, float iduration = 10f)
    // snake highlight colouration in Invincible mode
    {
        gameObject = gameObject.GetComponentInChildren<SpriteRenderer>().gameObject;
        StartCoroutine(ColorPulse(gameObject, cInvincible, iduration, pulse: (int)iduration));
    }

    public void ColorPulseDestroyer(GameObject gameObject, float iduration = 10f)
    // snake highlight colouration in Destroyer mode
    {
        gameObject = gameObject.GetComponentInChildren<SpriteRenderer>().gameObject;
        StartCoroutine(ColorPulse(gameObject, cDestroyer, iduration, pulse: (int)iduration));
    }

    public void ColorPulseRefresh(GameObject gameObject)
    // to be used when refreshing (rerandomising) letters
    {
        StartCoroutine(ColorPulse(gameObject, cRefresh, duration: 1f, pulse: 1));
    }

    public void ColorPulseSpawner(GameObject gameObject)
    // flashing when spawning objects
    {
        StartCoroutine(ColorPulse(gameObject, cSpawner, duration: 1f, pulse: 1));
    }

    public void ColorPulseDeSpawn(GameObject gameObject, float pulseDuration = 1f, float delay = 0f)
    // destroy gameObject after a delay and colorpulse of duration seconds
    {
        int numPulses = (int) pulseDuration;
        StartCoroutine(ColorPulse(gameObject, cSpawner, duration: pulseDuration, pulse: numPulses, delay: delay, despawn: true));
    }
}