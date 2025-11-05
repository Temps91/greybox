using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EyeBlink : MonoBehaviour
{
    public Image blackScreen;
    public float blinkDuration = 0.2f; 

    public IEnumerator Blink()
    {
        float t = 0;
        while (t < blinkDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / blinkDuration);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        t = 0;
        while (t < blinkDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / blinkDuration);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}