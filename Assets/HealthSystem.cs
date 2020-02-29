using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class HealthSystem : MonoBehaviour
 {
     public float health = 50;
     public float damage = -10;
     public playerMovement playerRef;

     private bool dead = false;

     // Start is called before the first frame update
     void Start()
     {
        
     }

     // Update is called once per frame
     void Update()
     {
         //If player is hit...
         if()
         {
             health += damage;
         }
       
         if (health <= 0)
         {
             dead = true;
         }
         if (dead == true)
         {
             ResetPlayer();
             dead = false;
         }
     }
     public void ResetPlayer()
     {
        playerRef.transform.position = Vector3.up * 3;
        playerRef.transform.rotation = Quaternion.identity; 
    }
 }
