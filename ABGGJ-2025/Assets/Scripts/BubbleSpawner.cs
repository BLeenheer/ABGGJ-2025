using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public float spawnInterval;
    private float time;
    /// <summary>
    /// The bubble to be spawned. This prefab needs the Bubble.cs script attached.
    /// </summary>
    [SerializeField]
    GameObject bubblePrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame. Put your regular logic here.
    void Update()
    {
        //TODO:
        // - Instantiate a bubble at a regular interval. Not every frame, otherwise we'll have hundreds!
        // - Make sure the spawn interval is visible in the inspector so that we can change it without re-writing the code.
        time += Time.deltaTime;
        if (time >= spawnInterval)
        {
            Vector3 spawnerPosition = transform.position;
            Instantiate(bubblePrefab, spawnerPosition, Quaternion.identity);
            time = 0;
        }
    }
}
