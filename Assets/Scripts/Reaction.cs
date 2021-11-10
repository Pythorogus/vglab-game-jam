using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour
{
    Sprite sprite;
    SpriteRenderer spriteRenderer;
    float yOrigin;
    private IEnumerator fadeAnim;
    public Sprite[] reactionArray;

    void Start()
    {
        reactionArray = Resources.LoadAll<Sprite>("Images/Sprites/reaction");
        yOrigin = transform.position.y;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.color = new Color(1, 1, 1, 0);
    }

    public void PlayDislikeAnimation(float delay)
    {
        AudioClip sound = (AudioClip) Resources.Load("Sounds/reaction_low");
        spriteRenderer.sprite = reactionArray[0];
        FadeIn(delay, sound);
    }

    public void PlayOkAnimation(float delay)
    {
        AudioClip sound = (AudioClip) Resources.Load("Sounds/reaction_mid");
        spriteRenderer.sprite = reactionArray[1];
        FadeIn(delay, sound);
    }

    public void PlayLikeAnimation(float delay)
    {
        AudioClip sound = (AudioClip) Resources.Load("Sounds/reaction_mid");
        spriteRenderer.sprite = reactionArray[2];
        FadeIn(delay, sound);
    }

    public void PlayLoveAnimation(float delay)
    {
        AudioClip sound = (AudioClip) Resources.Load("Sounds/reaction_high");
        spriteRenderer.sprite = reactionArray[3];
        FadeIn(delay, sound);
    }
    
    void FadeIn(float delay, AudioClip sound)
    {
        if(fadeAnim != null){
            StopCoroutine(fadeAnim);
        }
        fadeAnim = FadeInUpAnim(0.25f, 0.01f, delay, sound);
        StartCoroutine(fadeAnim);
    }

    IEnumerator FadeInUpAnim(float time, float distance, float delay, AudioClip sound)
    {
        spriteRenderer.material.color = new Color(1, 1, 1, 0);
        transform.position = new Vector2(transform.position.x, yOrigin);
        yield return new WaitForSeconds(delay);

        SoundController.instance.reactionSound.PlayOneShot(sound);

        for (float i = 0; i <= 1; i += Time.deltaTime / time)
        {
            spriteRenderer.material.color = new Color(1, 1, 1, i);
            transform.position = new Vector2(transform.position.x, transform.position.y + distance);
            yield return null;
        }
        
        yield return new WaitForSeconds(0.5f);

        for (float i = 1; i > 0; i -= Time.deltaTime / time)
        {
            spriteRenderer.material.color = new Color(1, 1, 1, i);
            transform.position = new Vector2(transform.position.x, transform.position.y + distance / 2);
            yield return null;
        }
    }
}
