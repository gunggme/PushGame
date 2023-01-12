using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private float xRotate, xRotateMove;
    public float rotateSpeed = 500.0f;

    void Update()
    {
        xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
        //xRotate = transform.eulerAngles.x + xRotateMove; 

        xRotate += xRotateMove;

        xRotate = Mathf.Clamp(xRotate, -90, 90); // 위, 아래 고정

        transform.eulerAngles = new Vector3(xRotate, transform.eulerAngles.y, 0);
    }
}
