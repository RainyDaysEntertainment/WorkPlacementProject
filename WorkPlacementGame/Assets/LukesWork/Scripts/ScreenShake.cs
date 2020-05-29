using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float strength)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0;

        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1) * strength;
            float y = Random.Range(-1, 1) * strength;

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(x, y, originalPosition.z), Time.deltaTime * 50);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;
    }
}
