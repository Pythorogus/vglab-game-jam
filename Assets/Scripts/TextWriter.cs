using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    float timer = 0.025f;
    string[] texts;
    int actualString = 0;
    TMPro.TextMeshProUGUI tmp;
    private IEnumerator writeRoutine;
    bool writing = false;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
        texts = tmp.text.Split("\n");
        tmp.text = "";
        writeRoutine = Write();
        StartCoroutine(writeRoutine);
    }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;
        if(Input.GetMouseButtonUp(0) && actualString < texts.Length)
        {
            if(!writing) {
                if(writeRoutine != null){
                    StopCoroutine(writeRoutine);
                }
                actualString++;
                if(actualString < texts.Length) {
                    tmp.text = "";
                    writeRoutine = Write();
                    StartCoroutine(writeRoutine);
                }
            } else {
                if(writeRoutine != null){
                    StopCoroutine(writeRoutine);
                }
                tmp.text = texts[actualString];
                writing = false;
            }
        }
    }

    IEnumerator Write()
    {
        writing = true;
        if(texts[actualString] == "")
        {
            actualString++;
        }

        foreach (char letter in texts[actualString]){
            tmp.text += letter;
            if(!SoundController.instance.textSound.isPlaying) {
                SoundController.instance.textSound.Play();
            }
            yield return new WaitForSeconds(timer);
        }
        writing = false;
    }
}
