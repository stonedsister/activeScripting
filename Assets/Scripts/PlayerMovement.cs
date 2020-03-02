using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float    speed = 30,
                    rotSpeed = 20f,
                    chosenDrag = 0.5f,
                    downForce = 10f;

    public Rigidbody rb;
    private bool isGrounded;
    public int playerHealth;
    public TextMeshPro playerHealthTxt;
    public bool rampGrounded;


    void Start(){
        rb = this.GetComponent<Rigidbody>();
        isGrounded = true;
        playerHealth = 100;
    }


    void Update(){
        if(playerHealth <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        playerHealthTxt.text = $"Health -> {playerHealth}";

        
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
    
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("bullet")){
            playerHealth -= 10;
            Destroy(other.gameObject);
            Debug.Log(playerHealth);
        }
    }
}
