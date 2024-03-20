using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    public float dragSpeed = 22;

    private float currentDragSpeed = 22;
    private Vector3 dragOrigin;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.y * currentDragSpeed, 0, -pos.x * currentDragSpeed);

        transform.Translate(move, Space.World);
        dragOrigin = Input.mousePosition;

        currentDragSpeed = dragSpeed * (Camera.main.fieldOfView / 60);
    }
}
