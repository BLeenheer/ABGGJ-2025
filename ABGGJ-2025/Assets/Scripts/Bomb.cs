using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Bomb : Popper
{
    /// <summary>
    /// Force applied by the explosion
    /// </summary>
    [SerializeField]
    float force = 1f;

    [SerializeField]
    GameObject explosionPrefab;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bomb Trigger Enter");
        if (collision != null)
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
            if (playerController != null)
            {
                //PlayerController.Instance.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 2f);
                Instantiate(explosionPrefab, transform.position, transform.parent.rotation);
                Destroy(this.gameObject);
            }
        }
        //TODO Play Explosion sound
    }
}
