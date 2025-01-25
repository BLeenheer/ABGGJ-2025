using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool bubbleEnabled;
    [SerializeField]
    GameObject bubble;

    [SerializeField]
    float floatForce = 10f, moveForce = 10f, popForce = 20f;
    [SerializeField]
    float moveSpeed = 10f, maxVelocity = 20f;

    Rigidbody2D rb2D;
    CircleCollider2D circleCollider;
    BoxCollider2D boxCollider;

    Vector2 movement;
    bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        SetBubble();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bubbleEnabled)
            {
                BubblePop();
            } else
            {
                BubbleEnter();
            }
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (bubbleEnabled)
        {
            rb2D.AddForce(Vector2.up * floatForce);
            rb2D.AddForce(movement * moveForce * Time.deltaTime);
        } else
        {
            if (isGrounded)
            {
                rb2D.AddForce(movement * moveForce * Time.deltaTime * Vector2.right);
            }
        }
    }

    public void BubbleEnter()
    {
        bubbleEnabled = true;
        SetBubble();
    }


    public void BubblePop()
    {
        bubbleEnabled = false;
        rb2D.SetRotation(0f);
        rb2D.angularVelocity = 0f;
        rb2D.AddForce(popForce * Vector2.up);
        SetBubble();
    }

    void SetBubble()
    {
        bubble.SetActive(bubbleEnabled);
        //boxCollider.enabled = !bubbleEnabled;
        //circleCollider.enabled = bubbleEnabled;
    }

    /// <summary>
    /// What happens when the crab hits a damaging object
    /// </summary>
    public void Injure()
    {
        //TODO: Play bubble pop or injury sound
        if (bubbleEnabled)
        {
            BubblePop();
        } else
        {
            Kill();
        }
    }

    public void Kill()
    {
        //TODO: Play death sound
        LevelManager.Instance.RespawnPlayer();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = (collision.gameObject.transform.tag == "Ground");
    }
}
