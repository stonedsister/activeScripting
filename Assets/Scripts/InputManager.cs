using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerMovement playerRef;
    private Debugger debugRef;
    private shieldController shield;

    // Start is called before the first frame update
    void Start()
    {
        if(playerRef == null) playerRef = GameObject.Find("player").GetComponent<PlayerMovement>();
        debugRef = this.GetComponent<Debugger>();
        shield = playerRef.transform.GetComponentsInChildren<shieldController>()[0];
        // playerRef.transfrom.GetChild(4).GetComponent<ShieldController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRef.move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            debugRef.ToggleDebug();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            shield.rBtnIsDown = true;
        }
        if(Input.GetKeyUp(KeyCode.Mouse1)){
            shield.rBtnIsDown = false;
        }

    }
}
