using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    private float times;

    private void Update()
    {
        times += Time.deltaTime;

        if (times >= 5)
        {
            Destroy(gameObject);
        }
    }
}
