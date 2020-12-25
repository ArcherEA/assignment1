using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float FireRate =20f;
    public float lastFired;
    public float lastfired;
    public float lifeDuration=2f;
    public float speed=300f;
    public ParticleSystem flash;
    public Camera fpscamera;
    public GameObject img;
    public GameObject crosshair;
    //private float lifeTimer;

    private AudioSource shooting_sound;

    // Start is called before the first frame update
    void Start()
    {
        //lifeTimer =lifeDuration;
        shooting_sound=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray=fpscamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit ;
        Vector3 targetPoint ;
        
        if (Physics.Raycast(ray, out hit,100f))
        {
            targetPoint = hit.point;
            
            crosshair.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            MeshRenderer[] allChildren = crosshair.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer child in allChildren)
            {
                child.material.SetColor("_Color", Color.green);
            }
            crosshair.transform.position=targetPoint;//new Vector3(crosshair.transform.position.x,crosshair.transform.position.y,hit.transform.position.z);
            if(hit.transform.gameObject.tag=="enemy"){
                img.GetComponent<Image>().color = new Color32(255,255,225,255);
            }
            else{img.GetComponent<Image>().color = new Color32(0,0,0,100);}
        }
        else{
            targetPoint = ray.GetPoint( 10 ) ;
            crosshair.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
            MeshRenderer[] allChildren = crosshair.GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer child in allChildren)
            {
                child.material.SetColor("_Color", Color.red);
            }
            crosshair.transform.position=targetPoint;
            img.GetComponent<Image>().color = new Color32(0,0,0,100);
        }
        if(Input.GetMouseButton(0)&&pausemenu.isGamePaused == false)
        {
            if(Time.time-lastfired>1/FireRate){
                lastfired=Time.time;
                flash.Play();
                shooting_sound.Play();
                GameObject newBullet = Instantiate(bullet);
                newBullet.transform.position = transform.position;
                newBullet.transform.position = transform.position+transform.forward;
                newBullet.GetComponent<Rigidbody>().velocity =(targetPoint -newBullet.transform.position)* speed;
                Debug.Log(newBullet.GetComponent<Rigidbody>().velocity);
                //newBullet.transform.position = transform.position+transform.up;
                //newBullet.GetComponent<Rigidbody>().velocity = transform.up*100;
                
            }
        }
        
    }
}
