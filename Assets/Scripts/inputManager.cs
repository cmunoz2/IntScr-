using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputManager : MonoBehaviour
{
    private Debugger debugRef;

    public playerMovement playerRef;

    private ShieldController shield;
    // Start is called before the first frame update
    void Start()
    {
        if (playerRef == null) playerRef = GameObject.Find("Player").GetComponent<playerMovement>();
        
        debugRef = this.GetComponent<Debugger>();

        shield  = playerRef.transform.GetChild(3).GetComponent<ShieldController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRef.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(Input.GetKeyDown(KeyCode.Alpha1)) debugRef.ToggleDebug();

        if(Input.GetKeyDown(KeyCode.Mouse1)) shield.rBtnIsDown = true;
        if(Input.GetKeyUp(KeyCode.Mouse1)) shield.rBtnIsDown = false;
    }
}
