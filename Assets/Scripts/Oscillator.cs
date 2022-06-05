using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;

     float movementFactor;
    // Start is called before the first frame update

    [SerializeField] float period = 2f;
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
    
        const float tau = Mathf.PI * 2;
        float rawSineWave = 3 * Mathf.Sin(cycles * tau);

        movementFactor = (rawSineWave + 1f) / 2f;

        Vector3 offset = movementVector + new Vector3(movementFactor, movementFactor, 0);
        Vector3 endPosition = startingPosition + offset;
        transform.position = endPosition;
    }
}
