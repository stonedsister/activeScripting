using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldController : MonoBehaviour
{
    public float    maxSize = 8,
                    minSize = 4,
                    timeToRecharge = 2,
                    timeToDeplete = 1,
                    timer = 0;

    public bool rBtnIsDown = false;

    MeshRenderer rend;
    Collider col;

    void Start()
    {
        rend = this.GetComponent<MeshRenderer>();
        col = this.GetComponent<Collider>();
    }

    void Update()
    {
        if(timer > timeToDeplete && !(timer > timeToRecharge)){
            if(rBtnIsDown){
                //Use Shield
                rend.enabled = true;
                col.enabled = true;
                this.transform.localScale = Vector3.one * timer * minSize;
                timer -= Time.deltaTime;
            } else {
                timer += Time.deltaTime;
                rend.enabled = false;
                col.enabled = false;
            }
        } else if(timer < 2){
            timer += Time.deltaTime;
            rend.enabled = false;
            col.enabled = false;
        } else if(timer > 2){
            timer = 2;
        }








        // if(rBtnIsDown){
        //     if(timer > timeToRecharge){
        //         rend.enabled = true;
        //         col.enabled = true;
        //         this.transform.localScale = Vector3.one * time * minSize;
        //         time -= Time.deltaTime
        //     } 
        //     else if(timer > timeToDeplete){
        //         // Turn shield on
        //         rend.enabled = true;
        //         col.enabled = true;
        //         this.transform.localScale = Vector3.one * time * minSize;
        //         time -= Time.deltaTime
        //     }
        //     // Otherwise recharge shield
        // } else{
        //     // Recharge shield
        // }
    }
}
