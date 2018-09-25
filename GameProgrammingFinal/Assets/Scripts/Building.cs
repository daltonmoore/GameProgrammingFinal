using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string sceneToLoad;
    PlayerController pc;
    UI ui;
    bool canOpen = false;

	// Use this for initialization
	void Start ()
    {
        ui = UI.getInstance();
        pc = PlayerController.getInstance();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.E))
        {
            if(canOpen)
            {
                //Enter building
                pc.setSceneToLoad(sceneToLoad);
                pc.setCanEnter(true);
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
