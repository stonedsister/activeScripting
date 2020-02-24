using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeetLaunch : MonoBehaviour
{
    public int rDir = 50;
    public turretLookAtEnemy refTurret;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Launch(){
        while(true){
            Fire();
            yield return new WaitForSeconds(1f);
        }
    }

    void Fire(){
        GameObject pigeon = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Rigidbody rb = pigeon.AddComponent<Rigidbody>();
        pigeon.GetComponent<Renderer>().material.color = Random.ColorHSV();
        pigeon.transform.position = this.transform.position;
        pigeon.transform.Rotate(Random.Range(-rDir,rDir), Random.Range(-rDir,rDir), Random.Range(-rDir,rDir));
        rb.AddRelativeForce(pigeon.transform.up * 50, ForceMode.Impulse);
        refTurret.pigeon = rb;
    }
}
