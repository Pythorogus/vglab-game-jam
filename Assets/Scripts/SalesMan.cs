using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesMan : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayShowAnimation(float delay)
    {
        StartCoroutine(Anim("show", delay));
    }

    IEnumerator Anim(string trigger, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger(trigger);
        yield return null;
    }
}
