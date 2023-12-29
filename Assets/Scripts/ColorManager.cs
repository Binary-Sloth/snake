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


    void Start()
    {
        cSuccess = Color.yellow;
        cFail = Color.red;
        cInvincible = Color.white;
        cDestroyer = Color.magenta;
        cRefresh = Color.cyan;
        cSpawner = Color.clear;
    }

    private IEnumerator ColorPulse(GameObject gameObject, Color altColour, float duration, int pulse, float delay = 0f, bool despawn = false)
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
            catch(MissingReferenceException ex) {
                // ignore in case snake resets (for tail segments)
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
                    sr = transform.GetChild(0).GetComponent<SpriteRenderer>();

                        try {
                            sr.color = Color.Lerp(altColour, originColor , Mathf.PingPong(t * pulse * 2, 1));
                        }
                        catch(MissingReferenceException ex) {
                            // continue ignore in case snake resets and gameObject is destroyed (for tail segments)
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
                sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
                // restore origin color
                try {
                    sr.color = originColor;
                }
                catch(MissingReferenceException ex) {
                    // ignore in case snake resets (for tail segments)
                }
            }
        }
        yield return null;


    }

    public void ColorPulseSuccess(GameObject gameObject)
    {
        StartCoroutine(ColorPulse(gameObject, cSuccess, duration: 1f, pulse: 2));
    }

    public void ColorPulseFail(GameObject gameObject)
    {
        StartCoroutine(ColorPulse(gameObject, cFail, duration: 1f, pulse: 2));
    }

    public void ColorPulseInvincible(List<Transform> transforms, float iduration = 10f)
    // snake highlight colouration in Invincible mode
    {
        StartCoroutine(ColorPulse(transforms, cInvincible, iduration, pulse: (int)iduration));
    }

    public void ColorPulseDestroyer(List<Transform> transforms, float iduration = 10f)
    // snake highlight colouration in Destroyer mode
    {
        StartCoroutine(ColorPulse(transforms, cDestroyer, iduration, pulse: (int)iduration));
        StartCoroutine(ColorPulse(transforms[0].gameObject, cDestroyer, iduration, pulse: (int)iduration));
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