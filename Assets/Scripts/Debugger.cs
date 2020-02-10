using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    public GameObject debugPanel;

    private InputField debugInput;
    private Text debugText;
    private bool debugging = false;
    // Start is called before the first frame update
    void Start()
    {
        if(debugPanel == null)
        {
            debugPanel = GameObject.Find("debugPanel");
        }
        if(debugPanel != null)
        {
            debugInput = debugPanel.transform.GetChild(0).GetComponent<InputField>();
            debugText = debugPanel.transform.GetChild(1).GetComponent<Text>();
        }
        debugPanel.SetActive(false);
    }

    public void ToggleDebug()
    {
        debugging = !debugging;
        debugPanel.SetActive(debugging);
    }

    public void InputText(string input)
    {
        if(input == "reload scene")
        {
            Application.LoadLevel(0);
        }
        else if(input == "hello")
        {
            debugText.text = "Hell o";
        }
        //else if input == half time
        // time.timescale = aksdkasdkhask
    }

    public playerMovement playerRef;

    public void ResetPlayer()
    {
        playerRef.transform.position = Vector3.up * 3;
        playerRef.transform.rotation = Quaternion.identity; 
    }

}
