using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtClickPoint : MonoBehaviour
{

    [SerializeField]
    [Range(0.01f, 0.5f)]
    float interval = 0.1f;

    public Camera mainCam;
    public Transform bulletSpawn;
    public Rigidbody bulletPreFab;
    public float bulletSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LookAtMousePoint());
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Bam");
            Debug.DrawRay(bulletSpawn.transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.magenta, 1f);
            Shoot();   
        }
    }


    void Shoot(){
        Rigidbody bullet = Instantiate(bulletPreFab, bulletSpawn.position, bulletSpawn.rotation);
        Debug.Log("Instantiating");
        bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
    }


    IEnumerator LookAtMousePoint(){
        while(true){
            RaycastHit hit;
            //if(Input.GetMouseButtonDown(0))
            //if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)){
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)){
                transform.LookAt(hit.point);
            }
             yield return new WaitForSeconds(interval);  
        }
    }
}
