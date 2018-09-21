using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public TextAsset textAsset;
    UI ui;
    bool canTalk = false;

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
            if(canTalk)
            {
                ui.hidePrompt("TalkPrompt");
                ui.showPrompt("Dialogue", textAsset);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ui.sendName(transform.parent.name, this);
            ui.showPrompt("TalkPrompt", null);
            canTalk = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.hidePrompt("TalkPrompt");
            canTalk = false;
        }
    }
}
