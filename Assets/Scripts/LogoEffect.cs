using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoEffect : MonoBehaviour
{
    #pragma strict
    public Transform gameObjectPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjectPos.transform.position.y < 2) {
 
         gameObject.transform.position += Vector3.up;
     
     }
     
     if (gameObjectPos.transform.position.y == 2) {
         
         gameObject.transform.position += Vector3.down;
         Debug.Log("To High");
         
     }
    }
}
