using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeetLauncher : MonoBehaviour
{
    public float rDir = 30;
    public float interval = 1f;
    public float launchPower = 15f;

    public LeadTurret refTurret;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Launch());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        
    }

    IEnumerator Launch() 
    {
        while(true)
        {
            Fire();
            yield return new WaitForSeconds(interval);
        }
    }

    void Fire() 
    {
        GameObject pidgeon = GameObject.CreatePrimitive (PrimitiveType.Cube);
        pidgeon.GetComponent<Renderer>().material.color = Random.ColorHSV();
        Rigidbody rb = pidgeon.AddComponent<Rigidbody>();
        pidgeon.transform.position = this.transform.position;
        pidgeon.transform.Rotate(Random.Range(-rDir,rDir), Random.Range(-rDir,rDir), Random.Range(-rDir,rDir));
        rb.AddRelativeForce(pidgeon.transform.up * launchPower, ForceMode.Impulse);
        refTurret.target = rb;
    }
}
