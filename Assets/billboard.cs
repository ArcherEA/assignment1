using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{
    public Transform cam;
   

    // Update is called once per frame
    void LateUpdate()
    {
        if (cam!=null)
        {
            transform.LookAt(transform.position+cam.forward);
        }
    }
}
