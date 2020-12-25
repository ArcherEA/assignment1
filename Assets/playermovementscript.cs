using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playermovementscript : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundcCheck;
    public float groundDistance = 0.4f;//eadius of sphere
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity; 
    public float gravity =-9.81f;
    public float jumpHeight = 10f;

    public int maxhealth=1000;

    public int curhealth=1000;
    public healthbar bar;

    // public float ammo=50f;
    void start()
    {
        
        curhealth=maxhealth;
        bar.SetMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundcCheck.position,groundDistance,groundMask);
        if(isGrounded &&velocity.y<0){
            velocity.y =-10f;
        }
        
        float x= Input.GetAxis("Horizontal");
        //WASD
        float z = Input.GetAxis("Vertical");
        Vector3 move =transform.right*x+transform.forward*z;
        controller.Move(move/10);

        velocity.y += gravity*1.8f*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump");
            velocity.y=Mathf.Sqrt(jumpHeight*-2*gravity);
        }

    }

    private void OnCollisionEnter(Collision other){
        if (other.collider.tag=="bullet"){
            curhealth-=20;
            bar.Sethealth(curhealth);
            if(curhealth<=0)
            {
                // ParticleSystem newexplosion = Instantiate(explosion);
                // newexplosion.transform.position = transform.position;
                // newexplosion.transform.position = transform.position;
                // newexplosion.Play();
                // GameObject newexplosion_audio= Instantiate(explosion_audio,transform.position,Quaternion.identity);
            
                //Destroy(this.gameObject);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

            }

        }
        else if (other.collider.tag=="heal"){
                curhealth+=20;
                bar.Sethealth(curhealth);
                Destroy(other.gameObject);
            }
        else if (other.collider.tag=="goal"){
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                //Destroy(other.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);

            }
            

    }
}
