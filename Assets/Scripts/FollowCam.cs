using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;

    public float height = 10, distance = 20, speed = 10;

    public bool debug = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is called AFTER EVERY once per frame
    void LateUpdate()
    {
        this.transform.LookAt(target);

        float distanceFromTarget = Vector3.Distance(this.transform.position, target.position);

        if(debug) Debug.Log("Distance from target = " +  distanceFromTarget);

        if(distanceFromTarget > distance)
        {
            this.transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
            // reset
            this.transform.position = new Vector3(transform.position.x, height, transform.position.z);
        }
        
    }
}
