using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpTest : MonoBehaviour
{

    public Transform pointA, pointB;
    public AnimationCurve curve;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timer < 1){
            this.transform.position = Vector3.Lerp(pointA.position, pointB.position, /*timer*/curve.Evaluate(timer));
            timer += Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            timer = 0;
        }

        //this.transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.Sin(Time.time));
    }
}
