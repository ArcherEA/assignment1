using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA_CONTROLLER : MonoBehaviour
{
    float xRotation=0f;
    //float yRotation=0f;
    float mouseSenstivity=10f;
    public Transform playerBody;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSenstivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSenstivity*Time.deltaTime;
        playerBody.Rotate(Vector3.up*mouseX*10);
        //yRotation -= 10*mouseX;
        xRotation -= 10*mouseY;

        xRotation=Mathf.Clamp(xRotation,-90,45);
        
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);

    }
}
