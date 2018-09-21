using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    UI ui;
    bool canOpen = false;

	// Use this for initialization
	void Start ()
    {
        ui = UI.getInstance();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.E))
        {
            if(canOpen)
            {
                //Enter building
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ui.sendName(transform.parent.name, this);
            ui.showPrompt("OpenDoor", null);
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            ui.hidePrompt("OpenDoor");
            canOpen = false;
        }
    }
}
