using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class Explosion : MonoBehaviour
{
    [SerializeField]
    AudioClipSet AudioClipSet;
    [SerializeField]
    float fadeSpeed = 0.5f, scaleMultiplier = 2f;
    float fadeProgress = 0f;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(AudioClipSet.GetRandom(), transform.position);
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.Rotate(0, 0, Random.Range(0, 360));
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeProgress < 1f)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(1, 0, fadeProgress));
            gameObject.transform.localScale = Vector3.Lerp(Vector3.one * scaleMultiplier, Vector3.one, fadeProgress);
            fadeProgress += Time.deltaTime * fadeSpeed;
        } else
        {
            Destroy(gameObject);
        }
    }
}
