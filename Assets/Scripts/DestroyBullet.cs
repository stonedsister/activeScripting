using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    private int timer = 0;
    public Rigidbody bullet;
    // Start is called before the first frame update
    void Start()
    {
        
        bullet = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnCollisionEnter(Collision other){
        if(other.gameObject != gameObject.CompareTag("smartTurret") || other.gameObject != gameObject.CompareTag("Player")){
            Destroy(this.gameObject);
        }

    }*/
}
