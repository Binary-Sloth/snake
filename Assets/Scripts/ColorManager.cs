using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    private Color cSuccess;
    private Color cFail;
    private Color cInvincible;
    private Color cDestroyer;
    private Color cRefresh;
    private Color cSpawner;
    private Color cSnake;


    void Start()
    {
        cSuccess = Color.yellow;
        cFail = Color.red;
        cInvincible = Color.white;
        cDestroyer = Color.magenta;
        cRefresh = Color.cyan;
        cSpawner = Color.clear;
        cSnake = new Color(0.114f, 0.953f, 0.058f, 1.000f);

    }

    private IEnumerator ColorPulse(GameObject gameObject, Color altColour, float duration, int pulse, float delay = 0f, bool despawn = false, bool isSnake = false)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        Color originColor;

        // save origin color
        if (isSnake) {
            originColor = cSnake;
        }
        else {
            originColor = sr.color;
        }

        yield return new WaitForSeconds(delay);
        // lerp animation with given duration in seconds
        for (float t = 0; t < 1.0f; t += Time.deltaTime/duration)
        {
            try {
                sr.color = Color.Lerp(altColour, originColor , Mathf.PingPong(t * pulse * 2, 1));
            }
            catch(MissingReferenceException mEx) {
                Debug.Log(mEx);
                // continue ignore in case snake resets and gameObject disappears (for tail segments)
            }
            catch(NullReferenceException nEx) {
                Debug.Log(nEx);
                // continue ignore in case snake resets and gameObject disappears (for tail segments)
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
            catch(MissingReferenceException mEx) {
                Debug.Log(mEx);
                // continue ignore in case snake resets and gameObject disappears (for tail segments)
            }
            catch(NullReferenceException nEx) {
                Debug.Log(nEx);
                // continue ignore in case snake resets and gameObject disappears (for tail segments)
            }
            yield return null;
        }
    }

    private IEnumerator ColorPulse(List<Transform> transforms, Color altColour, float pulseDuration, int pulse, float delay = 0f, bool despawn = false)
    {
        SpriteRenderer sr;

        // save origin color
        Color originColor = Color.clear;

        // delay if desired
        yield return new WaitForSeconds(delay);
        
            for (float t = 0; t < 1.0f; t += Time.deltaTime/pulseDuration)
            {
                foreach (Transform transform in transforms) 
                {
                    try {
                        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
                        sr.color = Color.Lerp(altColour, originColor , Mathf.PingPong(t * pulse * 2, 1));
                    }
                    catch(MissingReferenceException mEx) {
                        Debug.Log(mEx);
                        // continue ignore in case snake resets and gameObject disappears (for tail segments)
                    }
                    catch(NullReferenceException nEx) {
                        Debug.Log(nEx);
                        // continue ignore in case snake resets and gameObject disappears (for tail segments)
                    }
                }
                yield return null;
            }

        // after pulseDuration either delete all items in the list or change them back to their original color

        foreach (Transform transform in transforms) 
        {
            if (despawn) {
                Destroy(transform.gameObject);
            }
            else {
                // restore origin color
                try {
                    sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
                    sr.color = originColor;
                }
            catch(MissingReferenceException mEx) {
                Debug.Log(mEx);
                // continue ignore in case snake resets and gameObject disappears (for tail segments)
            }
            catch(NullReferenceException nEx) {
                Debug.Log(nEx);
                // continue ignore in case snake resets and gameObject disappears (for tail segments)
            }
            }
        }
        yield return null;


    }

    public void ColorPulseSuccess(GameObject gameObject)
    {
        StartCoroutine(ColorPulse(gameObject, cSuccess, duration: 1f, pulse: 2, isSnake: true));
    }

    public void ColorPulseFail(GameObject gameObject)
    {
        StartCoroutine(ColorPulse(gameObject, cFail, duration: 1f, pulse: 2, isSnake: true));
    }

    public void ColorPulseInvincible(List<Transform> transforms, float iduration = 10f)
    // snake highlight colouration in Invincible mode
    {
        float warningPulseTime = iduration * 0.2f;
        float normalPulseTime = iduration - warningPulseTime;
        StartCoroutine(ColorPulse(transforms, cInvincible, normalPulseTime, pulse: (int)normalPulseTime));
        StartCoroutine(ColorPulse(transforms, cInvincible, warningPulseTime, pulse: (int)warningPulseTime * 2, delay: normalPulseTime));
        
    }

    public void ColorPulseDestroyer(List<Transform> transforms, float iduration = 10f)
    // snake highlight colouration in Destroyer mode
    {
        float warningPulseTime = iduration * 0.2f;
        float normalPulseTime = iduration - warningPulseTime;
        StartCoroutine(ColorPulse(transforms, cDestroyer, normalPulseTime, pulse: (int)normalPulseTime));
        StartCoroutine(ColorPulse(transforms, cDestroyer, warningPulseTime, pulse: (int)warningPulseTime * 3, delay: normalPulseTime));
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