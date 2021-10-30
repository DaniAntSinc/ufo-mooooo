using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOFloat : MonoBehaviour
{
    float amplitudeY = 0.5f;
    float omegaY = 1;
    float index;
    public void Update()
    {
        index += Time.deltaTime;
        float y = Mathf.Abs(amplitudeY * Mathf.Sin(omegaY * index));
        transform.localPosition = new Vector3(0, y, 0);
    }
}
