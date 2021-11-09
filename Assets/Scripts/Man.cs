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

    public void PlayDislikeAnimation()
    {
        animator.SetTrigger("dislike");
    }

    public void PlayOkAnimation()
    {
        animator.SetTrigger("like");
    }

    public void PlayLikeAnimation()
    {
        animator.SetTrigger("like");
    }

    public void PlayLoveAnimation()
    {
        animator.SetTrigger("like");
    }
}
