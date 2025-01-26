using UnityEngine;

public class puffUp : MonoBehaviour
{
    //variable definitions
    float elapsedTime;
    public float puffInterval = 4f;
    public Animator animator;
    SkinnedMeshRenderer skinnedMeshRenderer;
    public Collider2D collider;
    public Behaviour popper;

    // Update is called once per frame
    void Update()
    {
        //check if timer has passed the puff interval
        elapsedTime += Time.deltaTime;
        if (elapsedTime > puffInterval)
        {
            //toggle the grow trigger
            if (animator.GetBool("puff")) {animator.SetBool("puff", false); collider.enabled = false; popper.enabled = false;}
            else {animator.SetBool("puff", true);collider.enabled = true;popper.enabled = true;}

            //reset timer
            elapsedTime = 0f;
            Debug.Log(animator.GetBool("puff"));
        }
    }
}
