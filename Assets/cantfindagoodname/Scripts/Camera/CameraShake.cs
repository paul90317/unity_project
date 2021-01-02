using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public IEnumerator shakeCamera(float duration, float magnitude)
    {
        Vector2 originalPosition = transform.localPosition;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.localPosition = new Vector2(Random.Range(-1f, 1f)*magnitude, Random.Range(-1f, 1f)*magnitude);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }
}
