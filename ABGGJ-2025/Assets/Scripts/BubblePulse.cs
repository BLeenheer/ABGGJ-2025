using UnityEngine;

public class BubblePulse : MonoBehaviour
{
    Vector3 intitialScale;
    [SerializeField]
    float effect = 1.2f, pulseSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intitialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = intitialScale + (Vector3.one * Mathf.Sin(Time.time * pulseSpeed) * effect);
    }
}
