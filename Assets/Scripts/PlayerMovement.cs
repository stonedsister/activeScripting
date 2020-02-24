using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float    speed = 30,
                    rotSpeed = 20f,
                    chosenDrag = 0.5f,
                    downForce = 10f;

    public Rigidbody rb;
    private bool isGrounded;


    void Start(){
        rb = this.GetComponent<Rigidbody>();
        isGrounded = true;
    }
    public void move(float h, float v){
        if(isGrounded){
            // Horizontal rotates the car around y axis
            //Vertical moves car foward and back on zed axis
            
            rb.AddRelativeForce(0,0,v * speed);
            rb.AddRelativeTorque(0,h * rotSpeed,0);
            rb.drag = chosenDrag;
        }

        else{
            rb.AddRelativeForce(0,0,v);
        }
        
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.CompareTag("ground")){
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("restart")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("ground")){
            isGrounded = false;
        }
    }
}
