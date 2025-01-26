using UnityEngine;

public class Popper : MonoBehaviour
{
    /// <summary>
    /// Overrides collision behaviour when disabled. The triggers are still called even when the component is disabled.
    /// </summary>
    [HideInInspector]
    public bool popEnabled;
    public bool popAndKill = false;

    private void Awake()
    {
        popEnabled = this.enabled;
    }

    private void OnDisable()
    {
        popEnabled = false;
    }

    private void OnEnable()
    {
        popEnabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Popper Trigger Enter");
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null && popEnabled) {
            if (popAndKill)
            {
                playerController.Kill();
            }
            else {
                playerController.Injure();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null && popEnabled)
        {
            if (popAndKill)
            {
                playerController.Kill();
            }
            else
            {
                playerController.Injure();
            }
        }
    }
}
