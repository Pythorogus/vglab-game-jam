using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    float timer = 1f;
    string[] texts;
    int actualString = 0;
    TMPro.TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
        texts = tmp.text.Split("\n");
        tmp.text = "";
        StartCoroutine(Write());
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    IEnumerator Write()
    {
        foreach (char letter in texts[actualString]){
            tmp.text += letter;
            SoundController.instance.textSound.Play();
            yield return new WaitForSeconds(timer);
        }
    }
}
