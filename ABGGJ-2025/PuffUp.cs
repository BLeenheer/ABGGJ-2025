using UnityEngine;

[RequireComponent(typeof(Popper))]
[RequireComponent(typeof(Animator))]
public class PuffUp : MonoBehaviour
{
    //variable definitions
    float elapsedTime;
    [SerializeField]
    float puffInterval = 4f;
    Animator animator;
    SkinnedMeshRenderer skinnedMeshRenderer;
    public Collider2D collider;
    Popper popper;

    private void Start()
    {
        popper = GetComponent<Popper>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if timer has passed the puff interval
        elapsedTime += Time.deltaTime;
        if (elapsedTime > puffInterval)
        {
            //toggle the grow trigger
            if (animator.GetBool("puff")) {
                animator.SetBool("puff", false); 
                collider.enabled = false; 
                popper.enabled = false;
            }
            else {
                animator.SetBool("puff", true);
                collider.enabled = true;
                popper.enabled = true;
            }

            //reset timer
            elapsedTime = 0f;
            //Debug.Log(animator.GetBool("puff"));
        }
    }
}
