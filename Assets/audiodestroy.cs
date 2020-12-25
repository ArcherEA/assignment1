using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiodestroy : MonoBehaviour
{
    private AudioSource aus ;
    
 
    void Start () {
            aus = GetComponent<AudioSource>();
            aus.Play();
    }
    
    void Update () {
        
        if(!aus.isPlaying)
        {
            Destroy(gameObject);
        }
        

    }
}
