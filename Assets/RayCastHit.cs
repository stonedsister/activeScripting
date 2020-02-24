using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastHit : MonoBehaviour
{

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 2f)){
            rb.isKinematic = true;
            Debug.DrawRay(transform.position, Vector3.down * 2, Color.green, Time.deltaTime);
        }

        else{
            Debug.DrawRay(transform.position, Vector3.down * 2 /*Vector3.down * hit.distance*/, Color.red, Time.deltaTime);
        }
    }
}
