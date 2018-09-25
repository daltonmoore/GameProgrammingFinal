using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Category : MonoBehaviour
{
    public GameObject selected;
    public GameObject page;
    RectTransform rectTransform;
    bool clicked = false;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        page.SetActive(clicked);
	}

    private void OnGUI()
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
        {
            if(Input.GetMouseButtonDown(0))
            {
                clicked = true;
            }
            selected.SetActive(true);
        }
        else
        {
            if (!clicked)
                selected.SetActive(false);
            if (Input.GetMouseButtonDown(0))
                clicked = false;
        }
    }
}
