using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    private Debugger debugRef;

    public playerMovement playerRef;
    // Start is called before the first frame update
    void Start()
    {
        if (playerRef == null) playerRef = GameObject.Find("Player").GetComponent<playerMovement>();
        debugRef = this.GetComponent<Debugger>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRef.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetKeyDown(KeyCode.Alpha1)) debugRef.ToggleDebug();
    }
}
