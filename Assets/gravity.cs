using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    private ParticleSystem ps;
    public float grav = 9.81f;
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }  

    void Update()
    {
        var main = ps.main;
        main.gravityModifier = grav;
        if(ps)
        {
            if(!ps.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
