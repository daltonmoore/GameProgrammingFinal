using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCameraMove : MonoBehaviour
{
    public GameObject holder;
    public float moveSpeed;
    public float rotateSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.W))
        {
            holder.transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            holder.transform.position += -transform.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            holder.transform.position += -transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            holder.transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(-rotateSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(rotateSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            holder.transform.Rotate(0, -rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            holder.transform.Rotate(0, rotateSpeed, 0);
        }
    }
}
