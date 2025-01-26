using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null) playerController.Kill();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null) playerController.Kill();
    }
}
