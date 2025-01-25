using UnityEngine;

/// <summary>
/// Makes an object pulse like an air-filled bubble
/// </summary>
public class BubblePulse : MonoBehaviour
{
    Vector3 intitialScale;
    /// <summary>
    /// The amount of change the pulse makes to the bubble's size.
    /// </summary>
    [SerializeField]
    float effect = 1.2f;
    /// <summary>
    /// The rate at which the bubble pulses
    /// </summary>
    [SerializeField]
    float pulseSpeed = 1f;

    float offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Grabs the initial scale so that all the math can be done relative to it.
        intitialScale = transform.localScale;
        
        //Random offset is to avoid all bubbles appearing to pulse at the same times if they use the same settings.
        offset = Random.Range(-10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        //Uses a Sin wave to oscilate between bigger and smaller sizes. Unscaled Time is unaffected by time scale and therefore keeps functioning on pause.
        transform.localScale = intitialScale + (Vector3.one * (Mathf.Sin((Time.unscaledTime + offset) * pulseSpeed) * effect));
    }
}
