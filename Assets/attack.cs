using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class attack : MonoBehaviour
{
    public float lookRadius = 1f;
    public float attackDistance=20f;
    Transform target;
    //public NavMeshAgent agent;
    public healthbar bar;
    public int maxhealth=100;

    public int curhealth;
    public GameObject gun;
    public GameObject fort2;
    public ParticleSystem explosion;
    public GameObject healobject;

    public GameObject explosion_audio;

    // Start is called before the first frame update
    void Start()
    {
        curhealth=maxhealth;
        bar.SetMaxHealth(maxhealth);
        target = GameObject.FindGameObjectWithTag ("Player").transform;
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position,transform.position);
        
        if (distance<=lookRadius)
        {
            FaceTarget();

            if(distance<=attackDistance)
            {
                
                gun.GetComponent<ENEMYATTACK>().enabled=true;
                
            }
            if(distance>attackDistance)
            {
                
                // if(gun.GetComponent<ENEMYATTACK>().enabled!=false)
                // {
                    gun.GetComponent<ENEMYATTACK>().enabled=false;
                // }
            }

        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position -transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,direction.y,direction.z));
        fort2.transform.rotation=Quaternion.Slerp(fort2.transform.rotation,lookRotation,Time.deltaTime*5f);
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
                GameObject newhealobject= Instantiate(healobject,transform.position,Quaternion.identity);
                GameObject newexplosion_audio= Instantiate(explosion_audio,transform.position,Quaternion.identity);
                Destroy(this.gameObject);
            }

        }
    }
    // void OnDrawGizmosSeleted()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position,lookRadius);
    // }
}
