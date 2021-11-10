using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayDislikeAnimation(float delay)
    {
        StartCoroutine(Anim("dislike", delay));
    }

    public void PlayOkAnimation(float delay)
    {
        
    }

    public void PlayLikeAnimation(float delay)
    {
        StartCoroutine(Anim("like", delay));
    }

    public void PlayLoveAnimation(float delay)
    {
        StartCoroutine(Anim("like", delay));
    }

    IEnumerator Anim(string trigger, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger(trigger);
        yield return null;
    }
}
