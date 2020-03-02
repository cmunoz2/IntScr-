using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadTurret : MonoBehaviour
{
    public Rigidbody target;

    public float bulletSpeed = 30f, fireInterval = 1f;

    [Range(0,1)]
    public float leadAmount = .5f;

    private Transform bulletSpawn;
     //bn

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = this.transform.GetChild(1);
        StartCoroutine(Fire());
       
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform.position + (target.velocity * leadAmount));
        Debug.DrawRay(bulletSpawn.position, bulletSpawn.forward * 50, Color.blue);
    }

    IEnumerator Fire()
    {
        while(true)
        {
            // if raycast hits player...
            GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
            bullet.transform.localScale = Vector3.one * 0.2f;
            Rigidbody rb = bullet.AddComponent<Rigidbody>();
            rb.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(fireInterval);
        }
    }
}
