using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTest : MonoBehaviour
{

    [SerializeField]
    [Range(0.05f, 2f)]
    float interval = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LookForPlayer());
    }
    
    IEnumerator LookForPlayer()
    {
        while(true)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 10,out hit, 10f))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green, .5f);
                if(hit.transform.gameObject.CompareTag("Player"))
                {
                    Debug.Log("I have found the player!");
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green, .5f);
                }          
                else
                {
                    Debug.Log("I have found something!");
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.blue, .5f);
                }      
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.red, .5f);
            }
            yield return new WaitForSeconds(interval);
        }
    }


}
