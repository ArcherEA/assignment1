using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{   public Transform player;
public float moveSpeed = 1f;
private Rigidbody rb;

public int maxhealth=100;

public int curhealth;

public ParticleSystem explosion;

public GameObject explosion_audio;

public healthbar bar;

// public ParticleSystem explosion;

// public GameObject explosion_audio;

private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        curhealth=maxhealth;
        bar.SetMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null){
            Vector3 direction =player.position -transform.position;
            float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
            rb.rotation =  Quaternion.Euler(0f,angle,0f);
            direction.Normalize();
            movement = direction;
        }

    }
    void FixedUpdate(){
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction){
        rb.MovePosition(transform.position+(direction*moveSpeed*Time.deltaTime));
    }

    private void OnCollisionEnter(Collision other){
        if (other.collider.tag=="bullet"){
            curhealth-=20;
            bar.Sethealth(curhealth);
            if(curhealth<=0)
            {
                ParticleSystem newexplosion = Instantiate(explosion);
                newexplosion.transform.position = transform.position;
                newexplosion.transform.position = transform.position;
                newexplosion.Play();
                GameObject newexplosion_audio= Instantiate(explosion_audio,transform.position,Quaternion.identity);
            
                Destroy(this.gameObject);
            }

        }
    }
}
