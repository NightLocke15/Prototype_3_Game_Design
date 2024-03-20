using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 initialPosition;

    [Range(0,2)]
    public float shakeIntensity;

    private bool shaking = false;

    private float waitingTime = 0;

    private void Start()
    {
        cameraTransform = GetComponent<Transform>();
        initialPosition = cameraTransform.localPosition;
    }

    private void Update()
    {
        if (waitingTime > 0 && !shaking)
        {
            StartCoroutine(ShakingScreen());
        }
    }

    public void Shake(float time)
    {
        if (time > 0)
        {
            waitingTime += time;
        }
    }

    IEnumerator ShakingScreen()
    {
        shaking = true;

        var StartTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < StartTime + waitingTime)
        {
            var randomPosition = new Vector3(Random.Range(-1, 1) * shakeIntensity, Random.Range(-1, 1) * shakeIntensity, initialPosition.z);
            cameraTransform.localPosition = randomPosition;

            yield return null;
        }

        waitingTime = 0;
        cameraTransform.localPosition = initialPosition;
        shaking = false;
    }
}
