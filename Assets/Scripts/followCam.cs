using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public Transform target;
    public float    height = 10,
                    distance = 20,
                    speed = 10;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.LookAt(target);

        // distance takes in one vector3 and a second Vector3 and returns the difference in a float
        float distanceFromTarget = Vector3.Distance(this.transform.position, target.position);

        //if(debug) Debug.Log($"Distance = {distanceFromTarget}");
        
        if(distanceFromTarget > distance){
            this.transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
            this.transform.position = new Vector3(transform.position.x, height, transform.position.z);
        }
    }
}
