using UnityEngine;

/// <summary>
/// Bubble that floats upwards and puts the player back inside a bubble when hit.
/// </summary>
public class Bubble : MonoBehaviour
{
    public float floatSpeed, bubbleLifeTime;
    private int frameCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO:
        //- Bubble must float upwards at a constant rate. DONE
        //- Show the speed in the inspector so we can modify it without changing the code. DONE
        //- Use a method that allows the bubble to be affected by external forces.
        //- Bubble must 'pop' after a certain amount of lifetime or when it hits something. 
        frameCount++;
        Vector2 floatAmount = new Vector2(0, floatSpeed) * Time.deltaTime;
        transform.Translate(floatAmount, Space.World);
        if (frameCount >= bubbleLifeTime)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //TODO:
        //Copy the logic from either the KillZone or the WinZone to make the player's bubble turn on.
        //Play a pop sound (waiting on audio)
        //Destroy this bubble when it collides with anything.
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null) playerController.BubbleEnter();
        Destroy(this.gameObject);
    }
}
