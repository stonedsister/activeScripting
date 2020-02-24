using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    public GameObject debugPanel;   // child = 0 input; 1 = text;
    public bool debugging = false;
    public PlayerMovement playerRef;
    private InputField debugInput;
    public Text debugText;
    

    //public InputField keyNumInput;
    public GateController keyCountRef;

    public Transform    startPos,
                        checkPoint1,
                        checkPoint2,
                        checkPoint3;

    // Start is called before the first frame update
    void Start()
    {
        if(debugPanel == null){
            debugPanel = GameObject.Find("debugPanel");
            
        }

        startPos = GameObject.Find("player").transform;
        /*
        if(debugPanel != null){
            debugInput = debugPanel.transform.GetChild(0).GetComponent<InputField>();
            debugText = debugPanel.transform.GetChild(1).GetComponent<Text>();
        }*/

        debugPanel.SetActive(false);
    }

    public void InputText(string input){
        if(input == "reload scene"){
            Application.LoadLevel(1);
        }
        if(input == "hello"){
            debugText.text = "Hell o.";
        }
    }

    public void changeKey(string input){
        Debug.Log($"Key count -> {keyCountRef.keyCount}");
        keyCountRef.keyCount = int.Parse(input);
        Debug.Log(int.Parse(input) + 2);
        Debug.Log($"Key count -> {keyCountRef.keyCount}");
        //keyCountRef.keyCount = keyCountInt;
        
    }

    public void ResetScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }



    public void ResetPlayer(){
        playerRef.transform.position = startPos.position; 
    }
    public void ToggleDebug(){
        debugging = !debugging;
        debugPanel.SetActive(debugging);
        if(debugging == true){
            Time.timeScale = 0;
        }
        else{
            Time.timeScale = 1;
        }
    }
        

    public void checkOne(){
        playerRef.transform.position = checkPoint1.position;
    }

    public void checkTwo(){
        playerRef.transform.position = checkPoint2.position;
    }

    public void checkThree(){
        playerRef.transform.position = checkPoint3.position;
    }

}
