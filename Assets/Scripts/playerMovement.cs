using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      

public class playerMovement : MonoBehaviour
{
    public float speed = 30, 
                rotSpeed = 15f,
                chosenDrag = 0.5f,
                downForce = 10f;
    private Rigidbody rb;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        isGrounded = true;
    }


    public void Move(float h, float v)
    {
        if(isGrounded)
        {
            rb.AddRelativeForce(0, 0, v * speed);
            rb.AddRelativeTorque(0, h * rotSpeed, 0);
            rb.drag = chosenDrag;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            Debug.Log("Grounded");
            isGrounded = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("ground"))
        {
            Debug.Log("NOT grounded");
            isGrounded = false;
        }

    }
}
