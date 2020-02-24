using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretLookAtEnemy : MonoBehaviour
{
    public Transform target;
    public Rigidbody bulletPreFab;
    public Transform bulletSpawn;
    public Transform origin;
    public Rigidbody pigeon;
    public GameObject block;
    [Range(0,1)]
    public float leadAmount = .5f;
    // Start is called before the first frame update
    void Start()
    {
        

        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(pigeon.transform.position + (pigeon.velocity * leadAmount));
        Debug.DrawRay(bulletSpawn.transform.position, bulletSpawn.forward * 100, Color.red);
    }

    IEnumerator Fire(){
        while(true){
            yield return new WaitForSeconds(0.3f);
            Rigidbody bullet = Instantiate(bulletPreFab, bulletSpawn.position,bulletSpawn.rotation);
            bullet.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
        }
    }    
}
