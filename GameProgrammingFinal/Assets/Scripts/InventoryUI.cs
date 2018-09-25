using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject selected;
    RectTransform rectTransform;
    Canvas canvas;
    bool clicked = false;

    private void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }

    
    private void Update()
    {

    }

    private void OnGUI()
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
        {
            if(Input.GetMouseButtonDown(0))
            {
                clicked = true;
            }
            selected.SetActive(true);
        }
        else
        {
            if(!clicked)
                selected.SetActive(false);
            if (Input.GetMouseButtonDown(0))
                clicked = false;
        }
    }
}
