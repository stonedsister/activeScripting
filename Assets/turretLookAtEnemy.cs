using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class turretLookAtEnemy : MonoBehaviour
{
    public Transform target;
    public Rigidbody bulletPreFab;
    public Transform bulletSpawn;
    public Transform origin;
    //public Rigidbody pigeon;
    public Rigidbody player;
    [Range(0,1)]
    public float leadAmount = .5f;
    public int turretHealth;
    public TextMeshPro turretHealthTxt;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
        turretHealth = 30;
        turretHealthTxt.text = $"{turretHealth}";
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.LookAt(pigeon.transform.position + (pigeon.velocity * leadAmount));
        this.transform.LookAt(player.transform.position + (player.velocity * leadAmount));
        Debug.DrawRay(bulletSpawn.transform.position, bulletSpawn.forward * 100, Color.red);
        turretHealthTxt.text = $"{turretHealth}";
        if(turretHealth <= 0){
            Destroy(this.gameObject);
        }
    }

    IEnumerator Fire(){
        while(true){
            yield return new WaitForSeconds(2.0f);
            Rigidbody bullet = Instantiate(bulletPreFab, bulletSpawn.position,bulletSpawn.rotation);
            bullet.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
            
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("playerBullet")){
            turretHealth -= 10;
            Destroy(other.gameObject);
        }
    }
}
