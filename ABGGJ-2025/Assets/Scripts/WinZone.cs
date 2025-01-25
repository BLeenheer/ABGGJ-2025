using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class WinZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TriggerNextLevel()
    {
        Debug.Log("Crab made it! Next Level Triggered!");
        LevelManager.Instance.NextLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null) TriggerNextLevel();
    }
}
