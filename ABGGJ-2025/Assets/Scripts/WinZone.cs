using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class WinZone : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

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
        if(PlayerController.Instance is not null) Destroy(PlayerController.Instance.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null) TriggerNextLevel();
        if (PlayerController.Instance is not null) Destroy(PlayerController.Instance.gameObject);
    }
}
