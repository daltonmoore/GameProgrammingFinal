using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillars : MonoBehaviour
{
    GameObject pillar;
    Vector3 targetPos;
    bool entered = false;

	// Use this for initialization
	void Start ()
    {
        getPillar();
	}

    private void Update()
    {
        if (entered && pillar.transform.position.y < 4)
        {
            raise();
        }
    }

    void getPillar()
    {
        string pillarNumber;
        if (name.Length == 11)
            pillarNumber = name.Substring(9, 1);
        else
            pillarNumber = name.Substring(9, 2);
        pillar = GameObject.Find("Pillar (" + pillarNumber + ")");

        targetPos = pillar.transform.position + new Vector3(0, 4, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            entered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            lower();
        }
    }

    void raise()
    {
        pillar.transform.position = Vector3.MoveTowards(pillar.transform.position, targetPos, 20 * Time.deltaTime);
    }

    void lower()
    {
        //pillar.transform.Translate(0, -4, 0);
    }
}
