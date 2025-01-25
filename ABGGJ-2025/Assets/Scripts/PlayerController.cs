using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool bubbleEnabled;
    [SerializeField]
    GameObject bubble;

    [SerializeField]
    float floatForce = 10f, moveForce = 10f, popForce = 20f, jumpForce = 200f;
    [SerializeField]
    float moveSpeed = 10f, maxVelocity = 20f;
    [SerializeField]
    float immunityDuration = 1f, doubleJumpDuration = 1f;

    Rigidbody2D rb2D;
    CircleCollider2D circleCollider;
    BoxCollider2D boxCollider;

    Vector2 movement;
    bool isGrounded = false, isImmune = false, dblJumpEnabled = false;

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
        //If you hit the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Bubble debugging!
            //if (bubbleEnabled)
            //{
            //    BubblePop();
            //} else
            //{
            //    BubbleEnter();
            //}

            //Jump! Only if on the ground and 
            if (!bubbleEnabled && (isGrounded || dblJumpEnabled)) {
                if (isGrounded)
                {
                    StartCoroutine(DoubleJump());
                    rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
                else
                {
                    if (dblJumpEnabled)
                    {
                        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                        dblJumpEnabled = false;
                    }
                }

            }
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (bubbleEnabled)
        {
            if (rb2D.linearVelocity.magnitude < maxVelocity) rb2D.AddForce(Vector2.up * floatForce);
            if (rb2D.linearVelocity.magnitude < maxVelocity) rb2D.AddForce(movement * moveForce * Time.deltaTime);
        } else
        {
            //Only allow movement if the crab is on the ground.
            if (isGrounded && movement.magnitude > 0.1)
            {
                //if(rb2D.linearVelocity.magnitude < maxVelocity) rb2D.AddForce(movement * moveSpeed * Time.deltaTime * Vector2.right);
                rb2D.MovePosition(
                    new Vector2(transform.position.x, transform.position.y) + (movement * moveSpeed * Time.deltaTime * Vector2.right));
            } else
            {
                if (rb2D.linearVelocity.magnitude < maxVelocity) rb2D.AddForce(movement * moveForce * Time.deltaTime * Vector2.right);
            }
        }
    }

    public void BubbleEnter()
    {
        isGrounded = false;
        bubbleEnabled = true;
        SetBubble();
        rb2D.angularVelocity = 0f;
        rb2D.AddForce(popForce * Vector2.up);
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
        rb2D.freezeRotation = !bubbleEnabled;
    }

    /// <summary>
    /// What happens when the crab hits a damaging object
    /// </summary>
    public void Injure()
    {
        //TODO: Play bubble pop or injury sound
        if (bubbleEnabled)
        {
            StartCoroutine(Immunity());
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
        Debug.Log("Crab Killed!");
        Destroy(this.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.transform.CompareTag("Ground")) isGrounded = true;
        //Debug.Log("Grounded: " +  isGrounded);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.transform.CompareTag("Ground")) isGrounded = false;
        //Debug.Log("Grounded: " + isGrounded);
    }

    IEnumerator Immunity()
    {
        isImmune = true;
        yield return new WaitForSeconds(immunityDuration);
        isImmune = false;
    }

    IEnumerator DoubleJump()
    {
        dblJumpEnabled = true;
        yield return new WaitForSeconds (doubleJumpDuration);
        dblJumpEnabled = false;
    }
}
