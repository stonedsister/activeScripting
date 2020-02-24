using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioClip error;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            audioSource.PlayOneShot(error);
        }

        
    }
}
