using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spin : MonoBehaviour
{
    [Tooltip("The degrees per second that the object should spin.")]
    [Range(-360,360)]
    public float spinSpeed = 60f;
    public float jumpForce = 10f;
    [Range(-5, -500)]
    public float downForce = -20f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public List<Transform> spawnPoints;
    public float timer = 0, spawnTimerMin = .5f, spawnTimerMax = 1.5f;

    public GameObject obstaclePrefab;

    public List<Transform> cloudSpawnPoints;
    public float cloudSpawnMin = 1f, cloudSpawnMax = 5f;

    public GameObject cloudPrefab;


    private Rigidbody rb;
    private bool isGrounded = true;
    private float playerHeight;
    private float score = 0;


    // Start is called before the first frame update
    // Start initializes program, Start would happen even if you start in the middle somewhere
    void Start()
    {
        StartCoroutine(SpawnCloud());
        Debug.Log("I exist!!");
        rb = this.GetComponent<Rigidbody>();
        playerHeight = this.transform.localScale.y;

        // Gives player 2 seconds before obstacles appear
        timer = 2;
        highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("High Score").ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        // Restarts game by reloading the level and setting time.timescale to 1
        if(Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }

        // Spin the object at a certain speed around the y-axis
        this.transform.Rotate(0, spinSpeed * Time.deltaTime, 0);

        // If the player presses "jump", addforce to the y-axis
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddRelativeForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        // Crouch & Un-Crouch
        // If the player presses down, crouch, change player height to 1/2
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, playerHeight * 0.5f, this.transform.localScale.z); //(x, y, z)
        }
        // un-crouch when player lets go of DownArrow, set height back to original value
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, playerHeight, this.transform.localScale.z); //(x, y, z)
        }

        // To make object fall faster, if object isn't grounded, add downward force
        if (!isGrounded)
        {
            rb.AddForce(0, downForce, 0);
        }

        // Add 10 points to score every second
        score += Time.deltaTime * 10;
        // update scoreText with score
        scoreText.text = "Score: " + score.ToString("0");

        // Spawn obstacles at random intervals and random heights
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
        }

        // Move obstacles along the x-axis toward player

    }

    void SpawnObstacle()
    {
        timer = Random.Range(spawnTimerMin, spawnTimerMax);
        Instantiate(obstaclePrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
    }
    IEnumerator SpawnCloud()
    {
        while(true)
        {
            Instantiate(cloudPrefab, cloudSpawnPoints[Random.Range(0, cloudSpawnPoints.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(cloudSpawnMin, cloudSpawnMax));
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Platform")
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;

            if (score > PlayerPrefs.GetFloat("High Score"))
            {
                Debug.Log("New High Score!");
                PlayerPrefs.SetFloat("High Score", score); 
            }
            highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("High Score").ToString("0");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Platform")
        {
            isGrounded = false;
        }
    }
}
