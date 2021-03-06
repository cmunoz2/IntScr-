﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class HealthSystem_Turret : MonoBehaviour
 {
     public float health = 50;
     public float damage = 10;

     private bool dead = false;

     // Start is called before the first frame update
     void Start()
     {
        
     }

     // Update is called once per frame
     void Update()
     {
       
         if (health <= 0)
         {
             dead = true;
         }
         if (dead == true)
         {
             DestroyGameObject();
         }
     }
    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "bulletPrefab(Clone)")
        {
            health -= damage;
        }
    }
 }
