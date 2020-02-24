using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerMovement playerRef;
    private Debugger debugRef;

    // Start is called before the first frame update
    void Start()
    {
        if(playerRef == null) playerRef = GameObject.Find("player").GetComponent<PlayerMovement>();
        debugRef = this.GetComponent<Debugger>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRef.move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            debugRef.ToggleDebug();
        }

    }
}
