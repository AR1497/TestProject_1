using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePoint : MonoBehaviour
{
    public LineRenderer line;

    private void Start()
    {
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKeyDown(KeyCode.A))
        {
            Vector2 currentPoint = GetWarldCoordinate(Input.mousePosition);
            Debug.Log(currentPoint);
            line.positionCount++;
            line.SetPosition(line.positionCount - 1, currentPoint);
        }    
    }

    private Vector2 GetWarldCoordinate(Vector3 mousePosition)
    {
        Vector2 mousePoint = new Vector3(mousePosition.x, mousePosition.y, 1);
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
