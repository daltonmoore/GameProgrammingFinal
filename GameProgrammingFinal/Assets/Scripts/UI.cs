using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private static UI instance;
    public GameObject TalkPrompt, DialogueOverlay, OpenDoorPrompt, PickUpPrompt;
    public Text talkPromptText, dialogueText, openDoorPromptText, pickUpText;
    public bool inDialog = false;

    string[] lines;
    int curLine;
    int endLine;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        TalkPrompt.SetActive(false);
        DialogueOverlay.SetActive(false);
        OpenDoorPrompt.SetActive(false);
        PickUpPrompt.SetActive(false);
    }

    private void Update()
    {
        if(inDialog)
        {
            Time.timeScale = 0;
            dialogueText.text = lines[curLine];
            

            /*if(Input.GetKeyDown(KeyCode.Space))
            {
                curLine++;
                if(curLine > endLine)
                {
                    DialogueOverlay.SetActive(false);
                    Time.timeScale = 1;
                    inDialog = false;
                }
            }*/
        }
    }

    public static UI getInstance()
    {
        return instance;
    }

    public void sendName<T>(string name, T objType)
    {
        if (objType is NPCDialogue)
            talkPromptText.text = "E to talk to " + name;
        else if (objType is Building)
            openDoorPromptText.text = "E to enter " + name;
        else if(objType is PlayerController)
        {

        }
    }

    public void showPrompt (string obj, TextAsset textAsset)
    {
        switch (obj)
        {
            case "TalkPrompt":
                TalkPrompt.SetActive(true);
                break;
            case "Dialogue":
                DialogueOverlay.SetActive(true);
                StartDialog(textAsset);
                break;
            case "OpenDoor":
                OpenDoorPrompt.SetActive(true);
                break;
        }
    }

    public void hidePrompt (string obj)
    {
        switch (obj)
        {
            case "TalkPrompt":
                TalkPrompt.SetActive(false);
                break;
            case "OpenDoor":
                OpenDoorPrompt.SetActive(false);
                break;
        }
    }

    void StartDialog(TextAsset textAsset)
    {
        lines = textAsset.text.Split('\n');
        curLine = 0;
        endLine = lines.Length - 1;
        inDialog = true;
    }
}

