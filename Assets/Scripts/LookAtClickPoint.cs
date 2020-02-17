using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtClickPoint : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 2f)]
    float interval = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LookAtMousePoint());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.magenta, 2f);
            Shoot();
        }
    }

    public Transform bulletSpawn;
    public Rigidbody bulletPrefab;
    public float bulletSpeed = 50;

    void Shoot()
    {
        Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);
    }
    IEnumerator LookAtMousePoint()
    {
        while(true)
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, 5))
            {
                transform.LookAt(hit.point);
            }  
            yield return new WaitForSeconds(interval);
        }
    }
}
