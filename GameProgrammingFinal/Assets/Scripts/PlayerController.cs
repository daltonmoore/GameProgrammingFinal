using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, turnSpeed;
    Camera camera;
    Animator anim;
    GameObject sword;

	// Use this for initialization
	void Start ()
    {
        sword = GameObject.Find("Sword");
        anim = sword.GetComponent<Animator>();
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        move();
        rotateCamera();
	}

    void move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += moveSpeed * transform.forward * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position += -moveSpeed * transform.forward * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position += -moveSpeed * transform.right * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += moveSpeed * transform.right * Time.deltaTime;
        }

        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Swing01");
        }
    }

    void rotateCamera()
    {
        try
        {
            float yRot = Input.GetAxis("Mouse X") * turnSpeed;
            float xRot = Input.GetAxis("Mouse Y") * turnSpeed;

            Quaternion targetRot = transform.localRotation;
            Quaternion camTargetRot = camera.transform.localRotation;

            targetRot *= Quaternion.Euler(0f, yRot, 0f);
            camTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

            camTargetRot = ClampRotationAroundXAxis(camTargetRot);

            transform.localRotation = targetRot;
            camera.transform.localRotation = camTargetRot;
        }
        catch (Exception e)
        {
            UnityEditor.EditorUtility.DisplayDialog("Error in CameraController update", e.Message, "ok");
            Debug.Break();
        }
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -90, 90);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
}
