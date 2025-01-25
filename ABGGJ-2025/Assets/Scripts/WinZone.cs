using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class WinZone : MonoBehaviour
{
    /// <summary>
    /// Loads the next level
    /// </summary>
    void TriggerNextLevel()
    {
        Debug.Log("Crab made it! Next Level Triggered!");
        LevelManager.Instance.NextLevel();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null) TriggerNextLevel();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null) TriggerNextLevel();
    }
}
