using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorIsMovingWoah : MonoBehaviour
{
    public bool isOn = false;

    // Intensity of the earthquake (adjust for how subtle you want it)
    public float intensity = 0.1f;

    // Frequency of movement changes
    public float shakeFrequency = 0.05f;
    public bool isReady = true;
    private Vector3 originalPosition;

    private void Update()
    {
        if(isOn && isReady)
        {
            isReady = false;
            originalPosition = transform.localPosition;
            StartCoroutine(StartEarthquake());
        }
    }

    public void ShakeNow(bool onOrOff)
    {
        isOn = onOrOff;
    }

    IEnumerator StartEarthquake()
    {
        
        // Generate random values for the X and Y axis within the intensity range
        float xOffset = Random.Range(-intensity, intensity);
        float yOffset = Random.Range(-intensity, intensity);

            // Apply the small offset to the object's position
        transform.localPosition = new Vector3(
            originalPosition.x + xOffset,
            originalPosition.y + yOffset,
            originalPosition.z);

         // Wait for a short duration before changing the movement
         yield return new WaitForSeconds(shakeFrequency);


        // Reset position after the earthquake effect
        transform.localPosition = originalPosition;
        isReady = true;
    }
}
