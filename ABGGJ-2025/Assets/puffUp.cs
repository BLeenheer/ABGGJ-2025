using UnityEngine;

public class puffUp : MonoBehaviour
{
    float elapsedTime;
    public float puffInterval = 2f;
    bool growTrigger = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > puffInterval)
        {
            elapsedTime = 0f;
            Debug.Log("trigger");
        }
    }
}
