using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYATTACK : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float FireRate =100f;
    public float lastfired;
    public float speed=100f;
    public ParticleSystem flash;
    public LayerMask ground;
    private AudioSource shooting_sound;

    // Start is called before the first frame update
    void Start()
    {   
        player=GameObject.FindGameObjectWithTag ("Player");
        shooting_sound=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        // if(Input.GetMouseButton(0)&&pausemenu.isGamePaused == false)
        // {
            if(Time.time-lastfired>1/FireRate&&player!=null){
                lastfired=Time.time;
                flash.Play();
                shooting_sound.Play();
                GameObject newBullet = Instantiate(bullet);
                newBullet.transform.position = transform.position;
                newBullet.transform.position = transform.position+transform.forward;
                newBullet.GetComponent<Rigidbody>().velocity =( player.transform.position -newBullet.transform.position)* speed;
                Debug.Log(newBullet.GetComponent<Rigidbody>().velocity);
                //newBullet.transform.position = transform.position+transform.up;
                //newBullet.GetComponent<Rigidbody>().velocity = transform.up*100;
            }
        // }
        
    }
}
