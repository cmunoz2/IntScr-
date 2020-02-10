using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOld : MonoBehaviour
{
    public float speed = 10, rotSpeed = 5f, chosenDrag = 0.5f, downForce = 10f;
    private Rigidbody rb;
    private bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }


    public void Move(float h, float v)
    {
        if(isGrounded)
        {
            rb.AddRelativeForce(0, 0, v * speed * Time.deltaTime);
            rb.AddRelativeTorque(0, h * rotSpeed * Time.deltaTime, 0);
            rb.drag = chosenDrag;
        }
        else
        {
            rb.drag = 0f;
            rb.AddRelativeForce(0, -downForce, 0);
        }

    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.CompareTag("Grounded"))
        {
            Debug.Log("Ground");
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Grounded"))
        {
            Debug.Log("no Groundddd");
            isGrounded = false;
        }
    }
}
