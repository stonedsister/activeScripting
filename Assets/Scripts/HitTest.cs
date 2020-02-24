using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTest : MonoBehaviour
{
    [SerializeField]
    [Range(0.05f, 2f)]
    float interval = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LookForPlayer());    
    }

    void Update(){
        RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f)){
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20, Color.green);
                if(hit.transform.gameObject.CompareTag("Player")){
                    Debug.Log("I have found the player");
                }
                else{
                    if(hit.transform.gameObject.CompareTag("Intruder")){
                        Debug.Log("I have found an intruder");
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20, Color.black);
                    }
                    Debug.Log("I have found something");
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20, Color.blue);
                }
            }        
            else{
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20, Color.red);
            }
    }
        
    /*
    IEnumerator LookForPlayer(){
        while(true){
            yield return new WaitForSeconds(interval);
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 10, out hit, 10f)){
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green);
                if(hit.transform.gameObject.CompareTag("Player")){
                    Debug.Log("I have found the player");
                }
                else{
                    if(hit.transform.gameObject.CompareTag("Intruder")){
                        Debug.Log("I have found an intruder");
                        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.black);
                    }
                    Debug.Log("I have found something");
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.blue);
                }
            }        
            else{
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red);
            }
            
        }
    }*/
}
