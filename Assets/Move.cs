﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float movementSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move obstacles on the x-axis towards player
        transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);
    }
}
