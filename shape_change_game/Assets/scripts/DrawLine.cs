using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class DrawLine : MonoBehaviour
{
    public LineRenderer linie;
    [HideInInspector]
    public GameObject mousePointer;

    private void Start()
    {
        mousePointer = GameObject.Find("MousePointer");
    }
    //    -----------------------------------    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

}