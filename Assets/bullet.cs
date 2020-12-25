using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifeDuration =20f;
    private float lifeTimer;
    public ParticleSystem hiteffect;

    // public ParticleSystem explosion;

    // public GameObject explosion_audio;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;

    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer<=0f){
            Destroy(this.gameObject);
        }
        //transform.position += transform.forward*speed*Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other){
        ParticleSystem newhiteffect = Instantiate(hiteffect);
        newhiteffect.transform.position = transform.position;
        newhiteffect.Play();
        // if (other.collider.tag=="enemy"){
        //     ParticleSystem newexplosion = Instantiate(explosion);
        //     newexplosion.transform.position = other.collider.transform.position;
        //     newexplosion.transform.position = other.collider.transform.position;
        //     newexplosion.Play();
        //     GameObject newexplosion_audio= Instantiate(explosion_audio,other.collider.transform.position,Quaternion.identity);
        //     Destroy(other.collider.gameObject);
        //     Destroy(this.gameObject);

        // }
        Destroy(this.gameObject);
    }
}
