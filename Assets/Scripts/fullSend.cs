using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullSend : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-spin.obstacleSpeed * Time.deltaTime,0,0);
    }
}
