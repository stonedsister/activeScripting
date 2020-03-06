using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateController : MonoBehaviour
{
    public int keyCount;
    public Rigidbody    gate1, 
                        gate2, 
                        gate3;

    public TextMeshPro keyText;

    
    
    // Start is called before the first frame update
    void Start()
    {
        keyCount = 0;
        keyText.text = $"Keys -> {keyCount}";

    }

    // Update is called once per frame
    void Update()
    {
        if(keyCount >= 9){
            gate3.AddRelativeForce(0,0,-15);
        }
        if(keyCount >= 6){
            gate2.AddRelativeForce(0,5,0);
        }
        if(keyCount >= 3){
            gate1.AddRelativeForce(0,5,0);
        }

        keyText.text = $"Keys -> {keyCount}";
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("key")){
            keyCount += 1;
            Destroy(other.gameObject);
            
        }
    }
}
