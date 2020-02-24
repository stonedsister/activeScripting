using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spin : MonoBehaviour
{
    [Tooltip("The degress per second that the object should spin")]
    [Range(-360, 360)]
    public float spinSpeed = 60f;
    public float jumpForce = 10f;
    public bool isGrounded = true;
    [Range(-5, -500)]
    public float downForce = -20;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI hiScoreText;
    private float playerHeight;
    private float score = 0;
    private float scoreModuloCheck;
    private float obstacleSpeedCheck;
    public static float obstacleSpeed;

    public GameObject deathScreen;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip fakeApplause;
    public AudioClip squish;
    public AudioClip joyScream;
    public AudioClip silencer;


    public List<Transform> spawnPoints;
    public List<Transform> cloudSpawnPoints;
    public float timer = 0, spawnTimerMin = 0.5f, spawnTimerMax = 1.5f;
    public float cloudSpawnMin = 2f, cloudSpawnMax = 5f;
    public GameObject obstaclePreFab;
    public GameObject cloudPreFab;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        Time.timeScale = 1;
        Debug.Log("I exist");
        rb = this.GetComponent<Rigidbody>();
        playerHeight = this.transform.localScale.y;

        //  Give the player a 2 second breather
        timer = 2;
        deathScreen.SetActive(false);
        hiScoreText.text = $"High score = {PlayerPrefs.GetFloat("High score").ToString("0")}";
        StartCoroutine(SpawnCloud());
        obstacleSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //  Spin the object at a certain speed around the y axis
        this.transform.Rotate(0, spinSpeed * Time.deltaTime, 0);

        //  If the player presses jump, add force
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
            rb.AddRelativeForce(0, jumpForce, 0, ForceMode.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }

        //  If the player presses down, crouch, change player height to 0.5
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            this.transform.localScale =  new Vector3(this.transform.localScale.x, playerHeight * 0.5f, this.transform.localScale.z);
        }

        if(Input.GetKeyUp(KeyCode.DownArrow)){
            this.transform.localScale =  new Vector3(this.transform.localScale.x, playerHeight, this.transform.localScale.z);
        }

        //  To make object fall faster, if !grounded add downward force
        if(!isGrounded){
            rb.AddForce(0, downForce, 0);
        }

        // Add 10 points to score every second
        score += Time.deltaTime * 10;
        //  Update scoreText with Score
        scoreText.text = "Score: " + score.ToString("0");
        scoreModuloCheck = score % 100;
        obstacleSpeedCheck = score % 10;

        

        if(scoreModuloCheck < 1){
            Debug.Log("modulo == 0");
            audioSource.PlayOneShot(silencer);
        }

        if(obstacleSpeedCheck < 1){
            obstacleSpeed += 0.5f;
        }

        //  Spawn obstacles at random intervals and random heights
        if(timer > 0){
            timer -= Time.deltaTime;
        }
        else{
            SpawnObstacle();
        }

    }

    void SpawnObstacle(){
        timer = Random.Range(spawnTimerMin, spawnTimerMax);
        Instantiate(obstaclePreFab, spawnPoints[Random.Range(0,spawnPoints.Count)].position, Quaternion.identity);

    }

    IEnumerator SpawnCloud()
    {
        while (true)
        {
            Instantiate(cloudPreFab, cloudSpawnPoints[Random.Range(0, cloudSpawnPoints.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(cloudSpawnMin, cloudSpawnMax));
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "platform"){
            isGrounded = true;
            audioSource.PlayOneShot(squish);
        }

        if(other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("obstacle hit");
            Time.timeScale = 0;
            deathScreen.SetActive(true);
            if(score > PlayerPrefs.GetFloat("High score"))
            {
                Debug.Log("High score if entered");
                PlayerPrefs.SetFloat("High score", score);
            }

            highScoreText.text = $"High score = {PlayerPrefs.GetFloat("High score").ToString("0")}";

            if(score < 500){
                audioSource.PlayOneShot(fakeApplause);
                audioSource.PlayOneShot(joyScream, 0.3f);
            }
            

        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.name == "platform"){
            isGrounded = false;
        }

    }
}
